namespace KeibaAiDataImporter.Core.Generators
{
    /// <summary>
    /// JVData_Struct.cs の1構造体（例: JV_RA_RACE）に対応する情報
    /// </summary>
    public class JvStructInfo
    {
        /// <summary>構造体名（例: JV_RA_RACE）</summary>
        public string StructName { get; set; } = string.Empty;

        /// <summary>レコード種別ID（例: RA）</summary>
        public string RecordId { get; set; } = string.Empty;

        /// <summary>フラット展開済みフィールド一覧（DB列に対応）</summary>
        public List<StructFieldInfo> FlattenedFields { get; set; } = new();

        /// <summary>主キー候補のフィールド名リスト</summary>
        public List<string> PrimaryKeyFields { get; set; } = new();
    }
}
