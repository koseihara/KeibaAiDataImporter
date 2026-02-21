using Npgsql;

namespace KeibaAiDataImporter.Infrastructure.Database
{
    /// <summary>
    /// DDL文字列をPostgreSQLに実行してスキーマを初期化する
    /// </summary>
    public class SchemaInitializer
    {
        /// <summary>
        /// DDL文字列を実行してテーブルを作成する
        /// </summary>
        public void InitializeSchema(string ddlSql)
        {
            using var conn = DbConnectionFactory.Create();
            conn.Open();

            using var cmd = new NpgsqlCommand(ddlSql, conn);
            cmd.CommandTimeout = 120;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// SQL文字列をセミコロンで分割し、各ステートメントを個別実行する。
        /// 個別のステートメントが失敗してもログを出しつつ続行する。
        /// </summary>
        /// <returns>各ステートメントの実行結果（statement, success, errorMessage）のリスト</returns>
        public List<(string Statement, bool Success, string? Error)> InitializeSchemaStatements(string sql)
        {
            var results = new List<(string Statement, bool Success, string? Error)>();

            var statements = sql.Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();

            using var conn = DbConnectionFactory.Create();
            conn.Open();

            foreach (var statement in statements)
            {
                try
                {
                    using var cmd = new NpgsqlCommand(statement, conn);
                    cmd.CommandTimeout = 120;
                    cmd.ExecuteNonQuery();
                    results.Add((statement, true, null));
                }
                catch (Exception ex)
                {
                    results.Add((statement, false, ex.Message));
                }
            }

            return results;
        }

        /// <summary>
        /// 指定テーブルが存在するか確認
        /// </summary>
        public bool TableExists(string tableName)
        {
            using var conn = DbConnectionFactory.Create();
            conn.Open();

            string sql = @"
                SELECT EXISTS (
                    SELECT FROM information_schema.tables
                    WHERE table_name = @tableName
                )";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tableName", tableName);

            return (bool)(cmd.ExecuteScalar() ?? false);
        }
    }
}
