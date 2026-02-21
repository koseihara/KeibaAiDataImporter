namespace KeibaAiDataImporter.Core.Generators
{
    /// <summary>
    /// レコードID → テーブル名のマッピングを自動生成する
    /// </summary>
    public class TableIdMapGenerator
    {
        /// <summary>
        /// JvStructInfo リストからレコードID→テーブル名マッピングを生成
        /// </summary>
        public Dictionary<string, string> GenerateMap(List<JvStructInfo> structs)
        {
            var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var info in structs)
            {
                map[info.RecordId] = info.RecordId;
            }

            return map;
        }

        /// <summary>
        /// マッピングをCSVファイルとして保存（互換性のため）
        /// </summary>
        public void SaveToCsv(Dictionary<string, string> map, string filePath)
        {
            var lines = map.Select(kvp => $"{kvp.Key},{kvp.Value}");
            File.WriteAllLines(filePath, lines);
        }
    }
}
