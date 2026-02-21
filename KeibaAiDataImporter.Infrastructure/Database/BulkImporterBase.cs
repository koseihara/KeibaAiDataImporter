using KeibaAiDataImporter.Core.Entities;
using Npgsql;
using System.Text;
using System.Linq;

namespace KeibaAiDataImporter.Infrastructure.Database
{
    /// <summary>
    /// NpgsqlのBinary Import (COPY) を使用した高速インポータの基底クラス
    /// </summary>
    public abstract class BulkImporterBase<T> where T : JvEntity
    {
        protected abstract string TableName { get; }
        protected abstract string[] Columns { get; }

        public void Import(IEnumerable<T> entities)
        {
            using var conn = DbConnectionFactory.Create();
            conn.Open();

            static string QuoteIdentifier(string s) => $"\"{s.Replace("\"", "\"\"")}\"";

            string quotedTable = QuoteIdentifier(TableName);
            string quotedColumns = string.Join(", ", Columns.Select(QuoteIdentifier));
            string copyCommand = $"COPY {quotedTable} ({quotedColumns}) FROM STDIN (FORMAT BINARY)";

            using var writer = conn.BeginBinaryImport(copyCommand);

            foreach (var entity in entities)
            {
                writer.StartRow();
                WriteRow(writer, entity);
            }

            writer.Complete();
        }

        protected abstract void WriteRow(NpgsqlBinaryImporter writer, T entity);
    }
}
