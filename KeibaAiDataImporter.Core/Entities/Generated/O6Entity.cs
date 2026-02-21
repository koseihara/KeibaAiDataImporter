using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_O6_ODDS_SANRENTAN — Auto-generated entity
    /// </summary>
    public class O6Entity : JvEntity
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
        public string TorokuTosu { get; private set; } = string.Empty;
        public string SyussoTosu { get; private set; } = string.Empty;
        public string SanrentanFlag { get; private set; } = string.Empty;
        public string OddsSanrentanInfo_Kumi { get; private set; } = string.Empty;
        public string OddsSanrentanInfo_Odds { get; private set; } = string.Empty;
        public string OddsSanrentanInfo_Ninki { get; private set; } = string.Empty;
        public string TotalHyosuSanrentan { get; private set; } = string.Empty;
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
            TorokuTosu = FixedLengthParser.ReadString(span, 35, 2);
            SyussoTosu = FixedLengthParser.ReadString(span, 37, 2);
            SanrentanFlag = FixedLengthParser.ReadString(span, 39, 1);
            var list_OddsSanrentanInfo_Kumi = new List<string>();
            for (int i = 0; i < 4896; i++)
            {
                list_OddsSanrentanInfo_Kumi.Add(FixedLengthParser.ReadString(span, 40 + (i * 17), 6));
            }
            OddsSanrentanInfo_Kumi = JsonSerializer.Serialize(list_OddsSanrentanInfo_Kumi);
            var list_OddsSanrentanInfo_Odds = new List<string>();
            for (int i = 0; i < 4896; i++)
            {
                list_OddsSanrentanInfo_Odds.Add(FixedLengthParser.ReadString(span, 46 + (i * 17), 7));
            }
            OddsSanrentanInfo_Odds = JsonSerializer.Serialize(list_OddsSanrentanInfo_Odds);
            var list_OddsSanrentanInfo_Ninki = new List<string>();
            for (int i = 0; i < 4896; i++)
            {
                list_OddsSanrentanInfo_Ninki.Add(FixedLengthParser.ReadString(span, 53 + (i * 17), 4));
            }
            OddsSanrentanInfo_Ninki = JsonSerializer.Serialize(list_OddsSanrentanInfo_Ninki);
            TotalHyosuSanrentan = FixedLengthParser.ReadString(span, 83272, 11);
            crlf = FixedLengthParser.ReadString(span, 83283, 2);
        }
    }
}
