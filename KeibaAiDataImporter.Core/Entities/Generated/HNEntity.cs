using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_HN_HANSYOKU — Auto-generated entity
    /// </summary>
    public class HNEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string HansyokuNum { get; private set; } = string.Empty;
        public string reserved { get; private set; } = string.Empty;
        public string KettoNum { get; private set; } = string.Empty;
        public string DelKubun { get; private set; } = string.Empty;
        public string Bamei { get; private set; } = string.Empty;
        public string BameiKana { get; private set; } = string.Empty;
        public string BameiEng { get; private set; } = string.Empty;
        public string BirthYear { get; private set; } = string.Empty;
        public string SexCD { get; private set; } = string.Empty;
        public string HinsyuCD { get; private set; } = string.Empty;
        public string KeiroCD { get; private set; } = string.Empty;
        public string HansyokuMochiKubun { get; private set; } = string.Empty;
        public string ImportYear { get; private set; } = string.Empty;
        public string SanchiName { get; private set; } = string.Empty;
        public string HansyokuFNum { get; private set; } = string.Empty;
        public string HansyokuMNum { get; private set; } = string.Empty;
        public string crlf { get; private set; } = string.Empty;

        public override void SetData(byte[] buffer)
        {
            var span = new ReadOnlySpan<byte>(buffer);
            base.ParseHeader(span);

            head_RecordSpec = FixedLengthParser.ReadString(span, 0, 2);
            head_DataKubun = FixedLengthParser.ReadString(span, 2, 1);
            head_MakeDate_Year = FixedLengthParser.ReadString(span, 3, 4);
            head_MakeDate_Month = FixedLengthParser.ReadString(span, 7, 2);
            head_MakeDate_Day = FixedLengthParser.ReadString(span, 9, 2);
            HansyokuNum = FixedLengthParser.ReadString(span, 11, 10);
            reserved = FixedLengthParser.ReadString(span, 21, 8);
            KettoNum = FixedLengthParser.ReadString(span, 29, 10);
            DelKubun = FixedLengthParser.ReadString(span, 39, 1);
            Bamei = FixedLengthParser.ReadString(span, 40, 36);
            BameiKana = FixedLengthParser.ReadString(span, 76, 40);
            BameiEng = FixedLengthParser.ReadString(span, 116, 80);
            BirthYear = FixedLengthParser.ReadString(span, 196, 4);
            SexCD = FixedLengthParser.ReadString(span, 200, 1);
            HinsyuCD = FixedLengthParser.ReadString(span, 201, 1);
            KeiroCD = FixedLengthParser.ReadString(span, 202, 2);
            HansyokuMochiKubun = FixedLengthParser.ReadString(span, 204, 1);
            ImportYear = FixedLengthParser.ReadString(span, 205, 4);
            SanchiName = FixedLengthParser.ReadString(span, 209, 20);
            HansyokuFNum = FixedLengthParser.ReadString(span, 229, 10);
            HansyokuMNum = FixedLengthParser.ReadString(span, 239, 10);
            crlf = FixedLengthParser.ReadString(span, 249, 2);
        }
    }
}
