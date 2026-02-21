using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_DM_INFO — Auto-generated entity
    /// </summary>
    public class DMEntity : JvEntity
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
        public string MakeHM_Hour { get; private set; } = string.Empty;
        public string MakeHM_Minute { get; private set; } = string.Empty;
        public string DMInfo_Umaban { get; private set; } = string.Empty;
        public string DMInfo_DMTime { get; private set; } = string.Empty;
        public string DMInfo_DMGosaP { get; private set; } = string.Empty;
        public string DMInfo_DMGosaM { get; private set; } = string.Empty;
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
            MakeHM_Hour = FixedLengthParser.ReadString(span, 27, 2);
            MakeHM_Minute = FixedLengthParser.ReadString(span, 29, 2);
            var list_DMInfo_Umaban = new List<string>();
            for (int i = 0; i < 18; i++)
            {
                list_DMInfo_Umaban.Add(FixedLengthParser.ReadString(span, 31 + (i * 15), 2));
            }
            DMInfo_Umaban = JsonSerializer.Serialize(list_DMInfo_Umaban);
            var list_DMInfo_DMTime = new List<string>();
            for (int i = 0; i < 18; i++)
            {
                list_DMInfo_DMTime.Add(FixedLengthParser.ReadString(span, 33 + (i * 15), 5));
            }
            DMInfo_DMTime = JsonSerializer.Serialize(list_DMInfo_DMTime);
            var list_DMInfo_DMGosaP = new List<string>();
            for (int i = 0; i < 18; i++)
            {
                list_DMInfo_DMGosaP.Add(FixedLengthParser.ReadString(span, 38 + (i * 15), 4));
            }
            DMInfo_DMGosaP = JsonSerializer.Serialize(list_DMInfo_DMGosaP);
            var list_DMInfo_DMGosaM = new List<string>();
            for (int i = 0; i < 18; i++)
            {
                list_DMInfo_DMGosaM.Add(FixedLengthParser.ReadString(span, 42 + (i * 15), 4));
            }
            DMInfo_DMGosaM = JsonSerializer.Serialize(list_DMInfo_DMGosaM);
            crlf = FixedLengthParser.ReadString(span, 301, 2);
        }
    }
}
