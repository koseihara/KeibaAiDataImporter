using System.Text;

namespace KeibaAiDataImporter.Core.Utils
{
    /// <summary>
    /// Shift-JIS固定長バイト配列からデータを抽出する高パフォーマンスパーサー
    /// </summary>
    public static class FixedLengthParser
    {
        private static readonly Encoding SjisEncoding = Encoding.GetEncoding("Shift_JIS");

        /// <summary>
        /// バイト配列の指定位置から文字列を取得し、前後の空白を除去します。
        /// </summary>
        public static string ReadString(ReadOnlySpan<byte> data, int offset, int length)
        {
            if (offset + length > data.Length)
            {
                return string.Empty;
            }

            var slice = data.Slice(offset, length);
            string value = SjisEncoding.GetString(slice);
            return value.Trim();
        }

        /// <summary>
        /// バイト配列から整数をパースします。
        /// </summary>
        public static int ReadInt(ReadOnlySpan<byte> data, int offset, int length)
        {
            string s = ReadString(data, offset, length);
            return int.TryParse(s, out int result) ? result : 0;
        }

        /// <summary>
        /// バイト配列からdecimalをパースします。
        /// </summary>
        public static decimal ReadDecimal(ReadOnlySpan<byte> data, int offset, int length)
        {
            string s = ReadString(data, offset, length);
            return decimal.TryParse(s, out decimal result) ? result : 0m;
        }
    }
}
