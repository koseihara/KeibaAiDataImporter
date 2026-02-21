using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_JC_INFO — Auto-generated entity
    /// </summary>
    public class JCEntity : JvEntity
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
        public string id_RaceNum { get; private set; } = string.Empty;
        public string HappyoTime_Month { get; private set; } = string.Empty;
        public string HappyoTime_Day { get; private set; } = string.Empty;
        public string HappyoTime_Hour { get; private set; } = string.Empty;
        public string HappyoTime_Minute { get; private set; } = string.Empty;
        public string Umaban { get; private set; } = string.Empty;
        public string Bamei { get; private set; } = string.Empty;
        public string JCInfoAfter_Futan { get; private set; } = string.Empty;
        public string JCInfoAfter_KisyuCode { get; private set; } = string.Empty;
        public string JCInfoAfter_KisyuName { get; private set; } = string.Empty;
        public string JCInfoAfter_MinaraiCD { get; private set; } = string.Empty;
        public string JCInfoBefore_Futan { get; private set; } = string.Empty;
        public string JCInfoBefore_KisyuCode { get; private set; } = string.Empty;
        public string JCInfoBefore_KisyuName { get; private set; } = string.Empty;
        public string JCInfoBefore_MinaraiCD { get; private set; } = string.Empty;
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
            id_RaceNum = FixedLengthParser.ReadString(span, 25, 2);
            HappyoTime_Month = FixedLengthParser.ReadString(span, 27, 2);
            HappyoTime_Day = FixedLengthParser.ReadString(span, 29, 2);
            HappyoTime_Hour = FixedLengthParser.ReadString(span, 31, 2);
            HappyoTime_Minute = FixedLengthParser.ReadString(span, 33, 2);
            Umaban = FixedLengthParser.ReadString(span, 35, 2);
            Bamei = FixedLengthParser.ReadString(span, 37, 36);
            JCInfoAfter_Futan = FixedLengthParser.ReadString(span, 73, 3);
            JCInfoAfter_KisyuCode = FixedLengthParser.ReadString(span, 76, 5);
            JCInfoAfter_KisyuName = FixedLengthParser.ReadString(span, 81, 34);
            JCInfoAfter_MinaraiCD = FixedLengthParser.ReadString(span, 115, 1);
            JCInfoBefore_Futan = FixedLengthParser.ReadString(span, 116, 3);
            JCInfoBefore_KisyuCode = FixedLengthParser.ReadString(span, 119, 5);
            JCInfoBefore_KisyuName = FixedLengthParser.ReadString(span, 124, 34);
            JCInfoBefore_MinaraiCD = FixedLengthParser.ReadString(span, 158, 1);
            crlf = FixedLengthParser.ReadString(span, 159, 2);
        }
    }
}
