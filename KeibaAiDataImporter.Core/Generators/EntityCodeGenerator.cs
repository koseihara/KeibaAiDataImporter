using System.Text;

namespace KeibaAiDataImporter.Core.Generators
{
    /// <summary>
    /// JvStructInfo から Entity C#クラスファイルを生成する
    /// </summary>
    public class EntityCodeGenerator
    {
        private const string Namespace = "KeibaAiDataImporter.Core.Entities";

        /// <summary>
        /// 全構造体のEntityファイルを指定ディレクトリに生成
        /// </summary>
        public void GenerateEntityFiles(List<JvStructInfo> structs, string outputDir)
        {
            Directory.CreateDirectory(outputDir);

            foreach (var info in structs)
            {
                string className = $"{info.RecordId}Entity"; // クラス名はEntity付き（C#慣例）
                string code = GenerateEntityCode(info, className);
                string filePath = Path.Combine(outputDir, $"{className}.cs");
                File.WriteAllText(filePath, code, Encoding.UTF8);
            }
        }

        /// <summary>
        /// 単一のEntityクラスコードを生成
        /// </summary>
        private string GenerateEntityCode(JvStructInfo info, string className)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using KeibaAiDataImporter.Core.Utils;");
            sb.AppendLine("using System.Text.Json;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine($"namespace {Namespace}");
            sb.AppendLine("{");
            sb.AppendLine($"    /// <summary>");
            sb.AppendLine($"    /// {info.StructName} — Auto-generated entity");
            sb.AppendLine($"    /// </summary>");
            sb.AppendLine($"    public class {className} : JvEntity");
            sb.AppendLine("    {");

            // プロパティ宣言
            foreach (var field in info.FlattenedFields)
            {
                string propName = SanitizePropertyName(field.FieldName);
                sb.AppendLine($"        public string {propName} {{ get; private set; }} = string.Empty;");
            }

            sb.AppendLine();
            sb.AppendLine("        public override void SetData(byte[] buffer)");
            sb.AppendLine("        {");
            sb.AppendLine("            var span = new ReadOnlySpan<byte>(buffer);");
            sb.AppendLine("            base.ParseHeader(span);");
            sb.AppendLine();

            // パースコード生成
            foreach (var field in info.FlattenedFields)
            {
                string propName = SanitizePropertyName(field.FieldName);
                if (field.IsJsonArray)
                {
                    sb.AppendLine($"            var list_{propName} = new List<string>();");
                    sb.AppendLine($"            for (int i = 0; i < {field.ArrayCount}; i++)");
                    sb.AppendLine($"            {{");
                    sb.AppendLine($"                list_{propName}.Add(FixedLengthParser.ReadString(span, {field.Offset} + (i * {field.ArrayStride}), {field.Length}));");
                    sb.AppendLine($"            }}");
                    sb.AppendLine($"            {propName} = JsonSerializer.Serialize(list_{propName});");
                }
                else
                {
                    sb.AppendLine($"            {propName} = FixedLengthParser.ReadString(span, {field.Offset}, {field.Length});");
                }
            }

            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        /// <summary>
        /// プロパティ名をC#識別子として安全にする
        /// </summary>
        private static string SanitizePropertyName(string name)
        {
            // C#予約語との衝突を避ける
            var reserved = new HashSet<string> { "class", "event", "object", "string", "int", "long", "short", "byte", "double", "float", "decimal", "bool", "char" };
            if (reserved.Contains(name.ToLower()))
            {
                return $"@{name}";
            }
            return name;
        }
    }
}
