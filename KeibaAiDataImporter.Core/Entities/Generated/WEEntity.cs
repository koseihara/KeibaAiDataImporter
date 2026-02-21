using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_WE_WEATHER — Auto-generated entity
    /// </summary>
    public class WEEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string id_Year { get; private set; } = string.Empty;
        public string id_MonthDay { get; private set; } = string.Empty;
        public string id_JyoCD { get; private set; } = string.Empty;
        public string id_Kaiji { get; private set; } = string.Empty;
        public string id_Nichiji { get; private set; } = string.Empty;
        public string HappyoTime_Month { get; private set; } = string.Empty;
        public string HappyoTime_Day { get; private set; } = string.Empty;
        public string HappyoTime_Hour { get; private set; } = string.Empty;
        public string HappyoTime_Minute { get; private set; } = string.Empty;
        public string HenkoID { get; private set; } = string.Empty;
        public string TenkoBaba_TenkoCD { get; private set; } = string.Empty;
        public string TenkoBaba_SibaBabaCD { get; private set; } = string.Empty;
        public string TenkoBaba_DirtBabaCD { get; private set; } = string.Empty;
        public string TenkoBabaBefore_TenkoCD { get; private set; } = string.Empty;
        public string TenkoBabaBefore_SibaBabaCD { get; private set; } = string.Empty;
        public string TenkoBabaBefore_DirtBabaCD { get; private set; } = string.Empty;
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
            id_Year = FixedLengthParser.ReadString(span, 11, 4);
            id_MonthDay = FixedLengthParser.ReadString(span, 15, 4);
            id_JyoCD = FixedLengthParser.ReadString(span, 19, 2);
            id_Kaiji = FixedLengthParser.ReadString(span, 21, 2);
            id_Nichiji = FixedLengthParser.ReadString(span, 23, 2);
            HappyoTime_Month = FixedLengthParser.ReadString(span, 25, 2);
            HappyoTime_Day = FixedLengthParser.ReadString(span, 27, 2);
            HappyoTime_Hour = FixedLengthParser.ReadString(span, 29, 2);
            HappyoTime_Minute = FixedLengthParser.ReadString(span, 31, 2);
            HenkoID = FixedLengthParser.ReadString(span, 33, 1);
            TenkoBaba_TenkoCD = FixedLengthParser.ReadString(span, 34, 1);
            TenkoBaba_SibaBabaCD = FixedLengthParser.ReadString(span, 35, 1);
            TenkoBaba_DirtBabaCD = FixedLengthParser.ReadString(span, 36, 1);
            TenkoBabaBefore_TenkoCD = FixedLengthParser.ReadString(span, 37, 1);
            TenkoBabaBefore_SibaBabaCD = FixedLengthParser.ReadString(span, 38, 1);
            TenkoBabaBefore_DirtBabaCD = FixedLengthParser.ReadString(span, 39, 1);
            crlf = FixedLengthParser.ReadString(span, 40, 2);
        }
    }
}
