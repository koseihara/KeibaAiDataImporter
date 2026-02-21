using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KeibaAiDataImporter.Core.Entities;
using Npgsql;
using NpgsqlTypes;

namespace KeibaAiDataImporter.Infrastructure.Database
{
    public class GenericJvImporter<T> : BulkImporterBase<T> where T : JvEntity
    {
        private readonly string _tableName;
        private readonly PropertyInfo[] _properties;
        private readonly string[] _primaryKeys;
        private readonly PropertyInfo[] _pkProperties;
        private readonly HashSet<string> _jsonbColumns;

        public GenericJvImporter(string tableName, string[]? primaryKeys = null)
        {
            _tableName = tableName;

            _properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            _primaryKeys = primaryKeys ?? Array.Empty<string>();

            _pkProperties = _properties.Where(p => _primaryKeys.Contains(p.Name)).ToArray();

            _jsonbColumns = LoadJsonbColumns(tableName);
        }

        private static readonly Dictionary<string, HashSet<string>> _jsonbColumnCache = new();

        private static HashSet<string> LoadJsonbColumns(string tableName)
        {
            lock (_jsonbColumnCache)
            {
                if (_jsonbColumnCache.TryGetValue(tableName, out var cached))
                    return cached;
            }

            var result = new HashSet<string>();
            try
            {
                using var conn = DbConnectionFactory.Create();
                conn.Open();
                using var cmd = new NpgsqlCommand(
                    "SELECT column_name FROM information_schema.columns WHERE table_name = @t AND data_type = 'jsonb'", conn);
                cmd.Parameters.AddWithValue("@t", tableName);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(reader.GetString(0));
                }
            }
            catch
            {
                // テーブルが存在しない場合など — 全てTextとして扱う
            }

            lock (_jsonbColumnCache)
            {
                _jsonbColumnCache[tableName] = result;
            }
            return result;
        }

        protected override string TableName => _tableName;
        protected override string[] Columns => _properties.Select(p => p.Name).ToArray();

        protected override void WriteRow(NpgsqlBinaryImporter writer, T entity)
        {
            foreach (var prop in _properties)
            {
                object? value = prop.GetValue(entity);
                string strValue = value?.ToString() ?? string.Empty;

                if (_jsonbColumns.Contains(prop.Name))
                {
                    writer.Write(strValue, NpgsqlDbType.Jsonb);
                }
                else
                {
                    writer.Write(strValue, NpgsqlDbType.Text);
                }
            }
        }

        public void ImportWithMerge(IEnumerable<T> entities)
        {
            if (_primaryKeys.Length == 0)
            {
                base.Import(entities);
                return;
            }

            var distinctEntities = Deduplicate(entities);

            using var conn = DbConnectionFactory.Create();
            conn.Open();

            using var trans = conn.BeginTransaction();

            try
            {
                string tempTable = $"temp_{_tableName}_{Guid.NewGuid().ToString("N").Substring(0, 8)}";
                string qMainTable = QuoteIdentifier(_tableName);
                string qTempTable = QuoteIdentifier(tempTable);

                using (var cmd = new NpgsqlCommand($"CREATE TEMP TABLE {qTempTable} (LIKE {qMainTable} INCLUDING DEFAULTS) ON COMMIT DROP", conn, trans))
                {
                    cmd.ExecuteNonQuery();
                }

                string quotedColumns = string.Join(", ", Columns.Select(QuoteIdentifier));
                string copyCmd = $"COPY {qTempTable} ({quotedColumns}) FROM STDIN (FORMAT BINARY)";

                using (var writer = conn.BeginBinaryImport(copyCmd))
                {
                    foreach (var entity in distinctEntities)
                    {
                        writer.StartRow();
                        WriteRow(writer, entity);
                    }
                    writer.Complete();
                }

                var updateColumns = Columns.Where(c => !_primaryKeys.Contains(c));
                string updateSet = string.Join(", ", updateColumns.Select(c => $"{QuoteIdentifier(c)} = EXCLUDED.{QuoteIdentifier(c)}"));
                string conflictKeys = string.Join(", ", _primaryKeys.Select(QuoteIdentifier));
                string doClause = string.IsNullOrEmpty(updateSet) ? "DO NOTHING" : $"DO UPDATE SET {updateSet}";

                string mergeSql = $@"
                    INSERT INTO {qMainTable} ({quotedColumns})
                    SELECT {quotedColumns} FROM {qTempTable}
                    ON CONFLICT ({conflictKeys})
                    {doClause};
                ";

                using (var cmd = new NpgsqlCommand(mergeSql, conn, trans))
                {
                    cmd.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                throw;
            }
        }

        private IEnumerable<T> Deduplicate(IEnumerable<T> source)
        {
            if (_pkProperties.Length == 0) return source;

            return source
                .GroupBy(entity => GenerateKeyString(entity))
                .Select(group => group.Last());
        }

        private string GenerateKeyString(T entity)
        {
            if (_pkProperties.Length == 1)
            {
                return _pkProperties[0].GetValue(entity)?.ToString() ?? "";
            }

            var values = _pkProperties.Select(p => p.GetValue(entity)?.ToString() ?? "");
            return string.Join("|", values);
        }

        private static string QuoteIdentifier(string s) => $"\"{s.Replace("\"", "\"\"")}\"";
    }
}
