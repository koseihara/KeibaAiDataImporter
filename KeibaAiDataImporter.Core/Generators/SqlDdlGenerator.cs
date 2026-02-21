using System.Text;

namespace KeibaAiDataImporter.Core.Generators
{
    /// <summary>
    /// JvStructInfo から PostgreSQL DDL (CREATE TABLE) を生成する
    /// </summary>
    public class SqlDdlGenerator
    {
        /// <summary>
        /// 全構造体のCREATE TABLE文を生成
        /// </summary>
        public string GenerateDdl(List<JvStructInfo> structs)
        {
            var sb = new StringBuilder();
            sb.AppendLine("-- Auto-generated DDL from JVData_Struct.cs");
            sb.AppendLine($"-- Generated at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine();

            // RecordIdが重複する場合、最後の定義のみ採用
            var deduped = structs
                .GroupBy(s => s.RecordId)
                .Select(g => g.Last())
                .ToList();

            foreach (var info in deduped)
            {
                string tableName = info.RecordId;
                sb.AppendLine($"DROP TABLE IF EXISTS \"{tableName}\" CASCADE;");
                sb.AppendLine($"CREATE TABLE \"{tableName}\" (");

                for (int i = 0; i < info.FlattenedFields.Count; i++)
                {
                    var field = info.FlattenedFields[i];
                    string colName = SanitizeColumnName(field.FieldName);
                    string comma = (i < info.FlattenedFields.Count - 1) ? "," : "";
                    if (field.IsJsonArray)
                    {
                        sb.AppendLine($"    \"{colName}\" JSONB{comma}");
                    }
                    else
                    {
                        sb.AppendLine($"    \"{colName}\" VARCHAR({field.Length}){comma}");
                    }
                }

                sb.AppendLine(");");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// カラム名をサニタイズ（PostgreSQL識別子として安全にする）
        /// </summary>
        private static string SanitizeColumnName(string name)
        {
            return name.Replace("\"", "");
        }
    }
}
