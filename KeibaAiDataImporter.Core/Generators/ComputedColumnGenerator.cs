using System.Text;

namespace KeibaAiDataImporter.Core.Generators
{
    /// <summary>
    /// JvStructInfoからAI用の計算列（race_id, kaisai_date, make_date等）を
    /// 追加するALTER TABLE SQLを生成する
    /// </summary>
    public class ComputedColumnGenerator
    {
        // RACE_ID サブ構造体のフラット化後フィールド名パターン
        private static readonly string[] RaceIdFields = { "id_Year", "id_MonthDay", "id_JyoCD", "id_Kaiji", "id_Nichiji" };
        private static readonly string[] RaceIdWithRaceNum = { "id_Year", "id_MonthDay", "id_JyoCD", "id_Kaiji", "id_Nichiji", "id_RaceNum" };

        // YMD サブ構造体のフラット化後パターン（Year/Month/Day）
        private static readonly string[] YmdSuffixes = { "_Year", "_Month", "_Day" };

        /// <summary>
        /// 全構造体に対してAI用計算列のALTER TABLE SQLを生成する
        /// </summary>
        public string GenerateComputedColumns(List<JvStructInfo> structs)
        {
            var sb = new StringBuilder();
            sb.AppendLine("-- AI-friendly computed columns");
            sb.AppendLine($"-- Generated at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine();

            // RecordIdが重複する場合、DDLと同じく最後の定義が有効なのでそちらのみ処理
            var deduped = structs
                .GroupBy(s => s.RecordId)
                .Select(g => g.Last())
                .ToList();

            foreach (var info in deduped)
            {
                string tableName = info.RecordId;
                var fieldNames = info.FlattenedFields
                    .Where(f => !f.IsJsonArray)
                    .Select(f => f.FieldName)
                    .ToHashSet();
                var alterStatements = new List<string>();

                // === race_id (5フィールド結合, RaceNum除外) ===
                if (RaceIdFields.All(f => fieldNames.Contains(f)))
                {
                    string concat = string.Join(" || ", RaceIdFields.Select(f => $"\"{f}\""));
                    alterStatements.Add(
                        $"ALTER TABLE \"{tableName}\" ADD COLUMN IF NOT EXISTS race_id VARCHAR(14) " +
                        $"GENERATED ALWAYS AS ({concat}) STORED;");

                    // インデックス
                    alterStatements.Add(
                        $"CREATE INDEX IF NOT EXISTS idx_{tableName.ToLower()}_race_id ON \"{tableName}\" (race_id);");
                }

                // === kaisai_date (開催日: id_Year + id_MonthDay → DATE) ===
                if (fieldNames.Contains("id_Year") && fieldNames.Contains("id_MonthDay"))
                {
                    alterStatements.Add(
                        $"ALTER TABLE \"{tableName}\" ADD COLUMN IF NOT EXISTS kaisai_date DATE " +
                        $"GENERATED ALWAYS AS (" +
                        $"CASE WHEN \"id_Year\" ~ '^\\d{{4}}$' AND \"id_MonthDay\" ~ '^\\d{{4}}$' " +
                        $"THEN MAKE_DATE(CAST(\"id_Year\" AS INTEGER), CAST(SUBSTRING(\"id_MonthDay\", 1, 2) AS INTEGER), CAST(SUBSTRING(\"id_MonthDay\", 3, 2) AS INTEGER)) ELSE NULL END" +
                        $") STORED;");

                    alterStatements.Add(
                        $"CREATE INDEX IF NOT EXISTS idx_{tableName.ToLower()}_kaisai_date ON \"{tableName}\" (kaisai_date);");
                }

                // === make_date (データ作成日: head_MakeDate_Year/Month/Day → DATE) ===
                if (HasYmdFields(fieldNames, "head_MakeDate"))
                {
                    string makeDateExpr = BuildYmdMakeDate("head_MakeDate");
                    alterStatements.Add(
                        $"ALTER TABLE \"{tableName}\" ADD COLUMN IF NOT EXISTS make_date DATE " +
                        $"GENERATED ALWAYS AS (" +
                        $"CASE WHEN {BuildYmdValidation("head_MakeDate")} " +
                        $"THEN {makeDateExpr} ELSE NULL END" +
                        $") STORED;");
                }

                // === その他のYMD日付フィールドを検出して変換 ===
                // BirthDate, RegDate, DelDate, ChokyoDate 等
                var ymdPrefixes = DetectYmdPrefixes(fieldNames)
                    .Where(p => p != "head_MakeDate"); // make_dateは既に処理済み

                foreach (var prefix in ymdPrefixes)
                {
                    string colName = ConvertToSnakeCase(prefix) + "_date";
                    string makeDateExpr = BuildYmdMakeDate(prefix);

                    alterStatements.Add(
                        $"ALTER TABLE \"{tableName}\" ADD COLUMN IF NOT EXISTS {colName} DATE " +
                        $"GENERATED ALWAYS AS (" +
                        $"CASE WHEN {BuildYmdValidation(prefix)} " +
                        $"THEN {makeDateExpr} ELSE NULL END" +
                        $") STORED;");
                }

                // === horse_id (KettoNumが存在する場合) ===
                if (fieldNames.Contains("KettoNum"))
                {
                    alterStatements.Add(
                        $"CREATE INDEX IF NOT EXISTS idx_{tableName.ToLower()}_ketto ON \"{tableName}\" (\"KettoNum\");");
                }

                // SQL出力
                if (alterStatements.Count > 0)
                {
                    sb.AppendLine($"-- Table: {tableName}");
                    foreach (var stmt in alterStatements)
                    {
                        sb.AppendLine(stmt);
                    }
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        /// <summary>指定プレフィクスのYMDフィールド(Year/Month/Day)が存在するか</summary>
        private static bool HasYmdFields(HashSet<string> fieldNames, string prefix)
        {
            return YmdSuffixes.All(s => fieldNames.Contains(prefix + s));
        }

        /// <summary>フィールド名群からYMDパターンのプレフィクスを検出する</summary>
        private static List<string> DetectYmdPrefixes(HashSet<string> fieldNames)
        {
            var yearFields = fieldNames.Where(f => f.EndsWith("_Year")).ToList();
            var prefixes = new List<string>();

            foreach (var yf in yearFields)
            {
                string prefix = yf.Substring(0, yf.Length - "_Year".Length);
                if (HasYmdFields(fieldNames, prefix))
                {
                    prefixes.Add(prefix);
                }
            }

            return prefixes;
        }

        /// <summary>YMDパターンからMAKE_DATE関数呼び出しを生成</summary>
        private static string BuildYmdMakeDate(string prefix)
        {
            return $"MAKE_DATE(CAST(\"{prefix}_Year\" AS INTEGER), CAST(\"{prefix}_Month\" AS INTEGER), CAST(\"{prefix}_Day\" AS INTEGER))";
        }

        /// <summary>YMDバリデーション条件を生成</summary>
        private static string BuildYmdValidation(string prefix)
        {
            return $"\"{prefix}_Year\" ~ '^\\d{{4}}$' " +
                   $"AND \"{prefix}_Month\" ~ '^\\d{{2}}$' " +
                   $"AND \"{prefix}_Day\" ~ '^\\d{{2}}$'";
        }

        /// <summary>CamelCase/PascalCase → snake_case</summary>
        private static string ConvertToSnakeCase(string name)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];
                if (c == '_')
                {
                    sb.Append('_');
                }
                else if (char.IsUpper(c) && i > 0 && name[i - 1] != '_')
                {
                    sb.Append('_');
                    sb.Append(char.ToLower(c));
                }
                else
                {
                    sb.Append(char.ToLower(c));
                }
            }
            return sb.ToString();
        }
    }
}
