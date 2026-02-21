namespace KeibaAiDataImporter.Core.Generators
{
    /// <summary>
    /// JVData_Struct.cs から抽出したフィールド情報
    /// </summary>
    public class StructFieldInfo
    {
        /// <summary>フィールド名（例: Year, MonthDay, JyoCD）</summary>
        public string FieldName { get; set; } = string.Empty;

        /// <summary>バイトオフセット（SetDataB内のMidB2Sの第2引数）</summary>
        public int Offset { get; set; }

        /// <summary>バイト長（SetDataB内のMidB2Sの第3引数）</summary>
        public int Length { get; set; }

        /// <summary>配列要素数（forループの場合）。1 = 非配列</summary>
        public int ArrayCount { get; set; } = 1;

        /// <summary>配列内のストライド（配列要素1つあたりのバイト数）</summary>
        public int ArrayStride { get; set; } = 0;

        /// <summary>サブ構造体名（MidB2Bで参照される場合、例: RACE_ID）</summary>
        public string? SubStructName { get; set; }

        /// <summary>サブ構造体のフラット展開されたフィールド</summary>
        public List<StructFieldInfo>? SubFields { get; set; }

        /// <summary>プレフィックス（親のフィールド名。フラット化時に使用）</summary>
        public string Prefix { get; set; } = string.Empty;

        /// <summary>1つのJSON配列列として格納するかどうか</summary>
        public bool IsJsonArray { get; set; } = false;
    }
}
