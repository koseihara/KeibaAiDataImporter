using KeibaAiDataImporter.Core.Utils;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// 全JV-Dataレコードの基底クラス
    /// </summary>
    public abstract class JvEntity
    {
        // 共通ヘッダ定義 (JV-Data仕様書より)
        // 1. レコード種別ID (2byte)
        // 2. データ区分 (1byte)
        // 3. データ作成年月日 (8byte)

        public string RecordTypeId { get; protected set; } = string.Empty;
        public string DataKubun { get; protected set; } = string.Empty;
        public string MakeDate { get; protected set; } = string.Empty;

        /// <summary>
        /// バイト配列から共通ヘッダ部分のみを読み込みます。
        /// </summary>
        public virtual void ParseHeader(ReadOnlySpan<byte> data)
        {
            RecordTypeId = FixedLengthParser.ReadString(data, 0, 2);
            DataKubun = FixedLengthParser.ReadString(data, 2, 1);
            MakeDate = FixedLengthParser.ReadString(data, 3, 8);
        }

        /// <summary>
        /// レコード全体のパースを行う抽象メソッド
        /// </summary>
        public abstract void SetData(byte[] buffer);
    }
}
