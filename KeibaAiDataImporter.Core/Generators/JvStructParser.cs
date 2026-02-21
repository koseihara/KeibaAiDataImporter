using System.Text.RegularExpressions;

namespace KeibaAiDataImporter.Core.Generators
{
    /// <summary>
    /// JVData_Struct.cs を正規表現で解析し、構造体・フィールド情報を抽出するパーサー
    /// </summary>
    public class JvStructParser
    {
        // MidB2S(ref bBuff, offset, length) — 文字列フィールド
        private static readonly Regex MidB2SRegex = new(
            @"(\w+)\s*=\s*MidB2S\s*\(\s*ref\s+bBuff\s*,\s*(\d+)\s*,\s*(\d+)\s*\)",
            RegexOptions.Compiled);

        // MidB2B(ref bBuff, offset, length) — サブ構造体
        private static readonly Regex MidB2BRegex = new(
            @"(\w+)(?:\.SetDataB\s*\(\s*MidB2B\s*\(\s*ref\s+bBuff\s*,\s*(\d+)\s*,\s*(\d+)\s*\))",
            RegexOptions.Compiled);

        // 配列のMidB2S: field[i] = MidB2S(ref bBuff, base + (stride * i), length)
        private static readonly Regex ArrayMidB2SRegex = new(
            @"(\w+)\s*\[\s*\w+\s*\]\s*=\s*MidB2S\s*\(\s*ref\s+bBuff\s*,\s*(\d+)\s*\+\s*\(\s*(\d+)\s*\*\s*\w+\s*\)\s*,\s*(\d+)\s*\)",
            RegexOptions.Compiled);

        // 配列のMidB2B: field[i].SetDataB(MidB2B(ref bBuff, base + (stride * i), length))
        private static readonly Regex ArrayMidB2BRegex = new(
            @"(\w+)\s*\[\s*\w+\s*\]\s*\.SetDataB\s*\(\s*MidB2B\s*\(\s*ref\s+bBuff\s*,\s*(\d+)\s*\+\s*\(\s*(\d+)\s*\*\s*\w+\s*\)\s*,\s*(\d+)\s*\)",
            RegexOptions.Compiled);

        // forループ: for (int i = 0; i < N; i++) or for (i = 0; i < N; i++)
        private static readonly Regex ForLoopRegex = new(
            @"for\s*\(\s*(?:int\s+)?\w+\s*=\s*0\s*;\s*\w+\s*<\s*(\d+)\s*;",
            RegexOptions.Compiled);

        // 構造体定義: public struct XXX
        private static readonly Regex StructDefRegex = new(
            @"public\s+struct\s+(\w+)",
            RegexOptions.Compiled);

        // フィールド宣言: public TYPE fieldName;  (型情報の取得用)
        private static readonly Regex FieldDeclRegex = new(
            @"public\s+(\w+(?:\[\])?)\s+(\w+)\s*;",
            RegexOptions.Compiled);

        /// <summary>
        /// JVData_Struct.cs をパースしてJV_構造体の情報を返す
        /// </summary>
        public List<JvStructInfo> Parse(string csFilePath)
        {
            var lines = File.ReadAllLines(csFilePath);
            var allStructs = ParseAllStructs(lines);
            var results = new List<JvStructInfo>();

            foreach (var kvp in allStructs)
            {
                if (!kvp.Key.StartsWith("JV_")) continue;

                var info = new JvStructInfo
                {
                    StructName = kvp.Key,
                    RecordId = ExtractRecordId(kvp.Key),
                };

                // フラット展開
                info.FlattenedFields = FlattenFields(kvp.Value, allStructs, "");
                results.Add(info);
            }

            return results;
        }

        /// <summary>
        /// 構造体名からレコードID（2文字）を抽出
        /// JV_RA_RACE → RA, JV_SE_RACE_UMA → SE, JV_H1_HYOSU → H1
        /// </summary>
        private static string ExtractRecordId(string structName)
        {
            // JV_ を除去し、アンダースコアで分割して最初の部分を取得
            var parts = structName.Substring(3).Split('_');
            return parts.Length > 0 ? parts[0] : structName;
        }

        /// <summary>
        /// ファイル内のすべての構造体を解析してフィールド情報を取得
        /// </summary>
        private Dictionary<string, List<StructFieldInfo>> ParseAllStructs(string[] lines)
        {
            var structs = new Dictionary<string, List<StructFieldInfo>>();
            // フィールド宣言から型情報を取得するための辞書
            var fieldTypeMap = new Dictionary<string, Dictionary<string, string>>();

            string? currentStruct = null;
            bool inSetDataB = false;
            int braceDepth = 0;
            int currentForCount = 0;
            var currentFields = new List<StructFieldInfo>();
            var currentFieldTypes = new Dictionary<string, string>();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                // 構造体定義の開始
                var structMatch = StructDefRegex.Match(line);
                if (structMatch.Success)
                {
                    if (currentStruct != null)
                    {
                        structs[currentStruct] = currentFields;
                        fieldTypeMap[currentStruct] = currentFieldTypes;
                    }
                    currentStruct = structMatch.Groups[1].Value;
                    currentFields = new List<StructFieldInfo>();
                    currentFieldTypes = new Dictionary<string, string>();
                    inSetDataB = false;
                    braceDepth = 0;
                    continue;
                }

                if (currentStruct == null) continue;

                // フィールド宣言を収集（型情報）
                var fieldDeclMatch = FieldDeclRegex.Match(line);
                if (fieldDeclMatch.Success && !inSetDataB)
                {
                    string typeName = fieldDeclMatch.Groups[1].Value;
                    string fieldName = fieldDeclMatch.Groups[2].Value;
                    currentFieldTypes[fieldName] = typeName;
                }

                // SetDataB メソッドの開始検出
                if (line.Contains("SetDataB") && (line.Contains("byte[]") || line.Contains("string")))
                {
                    inSetDataB = true;
                    braceDepth = 0;
                    currentForCount = 0;
                    continue;
                }

                if (!inSetDataB) continue;

                // ブレース深度の追跡
                braceDepth += line.Count(c => c == '{');
                braceDepth -= line.Count(c => c == '}');

                if (braceDepth <= 0 && line.Contains("}"))
                {
                    inSetDataB = false;
                    continue;
                }

                // forループの検出
                var forMatch = ForLoopRegex.Match(line);
                if (forMatch.Success)
                {
                    currentForCount = int.Parse(forMatch.Groups[1].Value);
                    continue;
                }

                // 配列MidB2S: field[i] = MidB2S(ref bBuff, base + (stride * i), length)
                var arrB2SMatch = ArrayMidB2SRegex.Match(line);
                if (arrB2SMatch.Success)
                {
                    currentFields.Add(new StructFieldInfo
                    {
                        FieldName = arrB2SMatch.Groups[1].Value,
                        Offset = int.Parse(arrB2SMatch.Groups[2].Value),
                        Length = int.Parse(arrB2SMatch.Groups[4].Value),
                        ArrayCount = currentForCount > 0 ? currentForCount : 1,
                        ArrayStride = int.Parse(arrB2SMatch.Groups[3].Value),
                    });
                    continue;
                }

                // 配列MidB2B: field[i].SetDataB(MidB2B(...))
                var arrB2BMatch = ArrayMidB2BRegex.Match(line);
                if (arrB2BMatch.Success)
                {
                    string fieldName = arrB2BMatch.Groups[1].Value;
                    string? subType = null;
                    if (currentFieldTypes.TryGetValue(fieldName, out var ft))
                    {
                        subType = ft.TrimEnd('[', ']');
                    }

                    currentFields.Add(new StructFieldInfo
                    {
                        FieldName = fieldName,
                        Offset = int.Parse(arrB2BMatch.Groups[2].Value),
                        Length = int.Parse(arrB2BMatch.Groups[4].Value),
                        ArrayCount = currentForCount > 0 ? currentForCount : 1,
                        ArrayStride = int.Parse(arrB2BMatch.Groups[3].Value),
                        SubStructName = subType,
                    });
                    continue;
                }

                // 通常のMidB2S
                var b2sMatch = MidB2SRegex.Match(line);
                if (b2sMatch.Success)
                {
                    currentFields.Add(new StructFieldInfo
                    {
                        FieldName = b2sMatch.Groups[1].Value,
                        Offset = int.Parse(b2sMatch.Groups[2].Value),
                        Length = int.Parse(b2sMatch.Groups[3].Value),
                    });
                    continue;
                }

                // 通常のMidB2B (サブ構造体)
                var b2bMatch = MidB2BRegex.Match(line);
                if (b2bMatch.Success)
                {
                    string fieldName = b2bMatch.Groups[1].Value;
                    // ドット区切りの場合、最初の部分を取得
                    if (fieldName.Contains('.'))
                    {
                        fieldName = fieldName.Split('.')[0];
                    }

                    string? subType = null;
                    if (currentFieldTypes.TryGetValue(fieldName, out var ft))
                    {
                        subType = ft;
                    }

                    currentFields.Add(new StructFieldInfo
                    {
                        FieldName = fieldName,
                        Offset = int.Parse(b2bMatch.Groups[2].Value),
                        Length = int.Parse(b2bMatch.Groups[3].Value),
                        SubStructName = subType,
                    });
                    continue;
                }
            }

            // 最後の構造体を保存
            if (currentStruct != null)
            {
                structs[currentStruct] = currentFields;
                fieldTypeMap[currentStruct] = currentFieldTypes;
            }

            return structs;
        }

        /// <summary>
        /// フィールドをフラット展開する（サブ構造体を再帰的に展開）
        /// JVData_Struct.cs のオフセットは1始まりなので、0始まりに変換する
        /// </summary>
        private List<StructFieldInfo> FlattenFields(
            List<StructFieldInfo> fields,
            Dictionary<string, List<StructFieldInfo>> allStructs,
            string prefix)
        {
            var result = new List<StructFieldInfo>();

            foreach (var field in fields)
            {
                string fullName = string.IsNullOrEmpty(prefix)
                    ? field.FieldName
                    : $"{prefix}_{field.FieldName}";

                if (field.SubStructName != null && allStructs.ContainsKey(field.SubStructName))
                {
                    // サブ構造体を再帰展開
                    var subFields = allStructs[field.SubStructName];

                    if (field.ArrayCount > 1)
                    {
                        // 配列のサブ構造体を1つのJSONとして扱う
                        int baseOffset = field.Offset - 1; // 0始まりに変換
                        var expanded = FlattenSubStructAsArray(subFields, allStructs, fullName, baseOffset, field.ArrayCount, field.ArrayStride);
                        result.AddRange(expanded);
                    }
                    else
                    {
                        // 単体のサブ構造体
                        int baseOffset = field.Offset - 1; // 0始まりに変換
                        var expanded = FlattenSubStruct(subFields, allStructs, fullName, baseOffset);
                        result.AddRange(expanded);
                    }
                }
                else if (field.ArrayCount > 1 && field.SubStructName == null)
                {
                    // 文字列配列を1つのJSONにする
                    result.Add(new StructFieldInfo
                    {
                        FieldName = fullName,
                        Offset = field.Offset - 1, // 0始まりに変換
                        Length = field.Length,
                        Prefix = prefix,
                        IsJsonArray = true,
                        ArrayCount = field.ArrayCount,
                        ArrayStride = field.ArrayStride
                    });
                }
                else
                {
                    // 通常の文字列フィールド
                    result.Add(new StructFieldInfo
                    {
                        FieldName = fullName,
                        Offset = field.Offset - 1, // 0始まりに変換
                        Length = field.Length,
                        Prefix = prefix,
                    });
                }
            }

            return result;
        }

        /// <summary>
        /// サブ構造体を指定ベースオフセットで展開する
        /// サブ構造体のSetDataBは自身のbBuff[1..N]を使うため、
        /// 親のオフセット + サブフィールドのオフセット(0始まり) で最終オフセットを計算
        /// </summary>
        private List<StructFieldInfo> FlattenSubStruct(
            List<StructFieldInfo> subFields,
            Dictionary<string, List<StructFieldInfo>> allStructs,
            string prefix,
            int baseOffset)
        {
            var result = new List<StructFieldInfo>();

            foreach (var sf in subFields)
            {
                string fullName = $"{prefix}_{sf.FieldName}";

                if (sf.SubStructName != null && allStructs.ContainsKey(sf.SubStructName))
                {
                    // さらにネストしたサブ構造体
                    var nestedFields = allStructs[sf.SubStructName];

                    if (sf.ArrayCount > 1)
                    {
                        int nestedBase = baseOffset + (sf.Offset - 1);
                        result.AddRange(FlattenSubStructAsArray(nestedFields, allStructs, fullName, nestedBase, sf.ArrayCount, sf.ArrayStride));
                    }
                    else
                    {
                        int nestedBase = baseOffset + (sf.Offset - 1);
                        result.AddRange(FlattenSubStruct(nestedFields, allStructs, fullName, nestedBase));
                    }
                }
                else if (sf.ArrayCount > 1 && sf.SubStructName == null)
                {
                    result.Add(new StructFieldInfo
                    {
                        FieldName = fullName,
                        Offset = baseOffset + (sf.Offset - 1),
                        Length = sf.Length,
                        Prefix = prefix,
                        IsJsonArray = true,
                        ArrayCount = sf.ArrayCount,
                        ArrayStride = sf.ArrayStride
                    });
                }
                else
                {
                    result.Add(new StructFieldInfo
                    {
                        FieldName = fullName,
                        Offset = baseOffset + (sf.Offset - 1),
                        Length = sf.Length,
                        Prefix = prefix,
                    });
                }
            }

            return result;
        }

        private List<StructFieldInfo> FlattenSubStructAsArray(
            List<StructFieldInfo> subFields,
            Dictionary<string, List<StructFieldInfo>> allStructs,
            string prefix,
            int baseOffset,
            int parentArrayCount,
            int parentArrayStride)
        {
            var result = new List<StructFieldInfo>();

            foreach (var sf in subFields)
            {
                string fullName = $"{prefix}_{sf.FieldName}";

                if (sf.SubStructName != null && allStructs.ContainsKey(sf.SubStructName))
                {
                    // さらにネストしたサブ構造体
                    var nestedFields = allStructs[sf.SubStructName];
                    int nestedBase = baseOffset + (sf.Offset - 1);
                    // 親のArrayCount/Strideを引き継いでJSON配列に
                    result.AddRange(FlattenSubStructAsArray(nestedFields, allStructs, fullName, nestedBase, parentArrayCount, parentArrayStride));
                }
                else
                {
                    result.Add(new StructFieldInfo
                    {
                        FieldName = fullName,
                        Offset = baseOffset + (sf.Offset - 1),
                        Length = sf.Length,
                        Prefix = prefix,
                        IsJsonArray = true,
                        ArrayCount = parentArrayCount,
                        ArrayStride = parentArrayStride
                    });
                }
            }

            return result;
        }
    }
}
