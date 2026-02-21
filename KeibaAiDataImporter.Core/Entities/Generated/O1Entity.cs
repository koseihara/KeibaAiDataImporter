using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_O1_ODDS_TANFUKUWAKU — Auto-generated entity
    /// </summary>
    public class O1Entity : JvEntity
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
        public string TansyoFlag { get; private set; } = string.Empty;
        public string FukusyoFlag { get; private set; } = string.Empty;
        public string WakurenFlag { get; private set; } = string.Empty;
        public string FukuChakuBaraiKey { get; private set; } = string.Empty;
        public string OddsTansyoInfo_Umaban { get; private set; } = string.Empty;
        public string OddsTansyoInfo_Odds { get; private set; } = string.Empty;
        public string OddsTansyoInfo_Ninki { get; private set; } = string.Empty;
        public string OddsFukusyoInfo_Umaban { get; private set; } = string.Empty;
        public string OddsFukusyoInfo_OddsLow { get; private set; } = string.Empty;
        public string OddsFukusyoInfo_OddsHigh { get; private set; } = string.Empty;
        public string OddsFukusyoInfo_Ninki { get; private set; } = string.Empty;
        public string OddsWakurenInfo_Kumi { get; private set; } = string.Empty;
        public string OddsWakurenInfo_Odds { get; private set; } = string.Empty;
        public string OddsWakurenInfo_Ninki { get; private set; } = string.Empty;
        public string TotalHyosuTansyo { get; private set; } = string.Empty;
        public string TotalHyosuFukusyo { get; private set; } = string.Empty;
        public string TotalHyosuWakuren { get; private set; } = string.Empty;
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
            TansyoFlag = FixedLengthParser.ReadString(span, 39, 1);
            FukusyoFlag = FixedLengthParser.ReadString(span, 40, 1);
            WakurenFlag = FixedLengthParser.ReadString(span, 41, 1);
            FukuChakuBaraiKey = FixedLengthParser.ReadString(span, 42, 1);
            var list_OddsTansyoInfo_Umaban = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_OddsTansyoInfo_Umaban.Add(FixedLengthParser.ReadString(span, 43 + (i * 8), 2));
            }
            OddsTansyoInfo_Umaban = JsonSerializer.Serialize(list_OddsTansyoInfo_Umaban);
            var list_OddsTansyoInfo_Odds = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_OddsTansyoInfo_Odds.Add(FixedLengthParser.ReadString(span, 45 + (i * 8), 4));
            }
            OddsTansyoInfo_Odds = JsonSerializer.Serialize(list_OddsTansyoInfo_Odds);
            var list_OddsTansyoInfo_Ninki = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_OddsTansyoInfo_Ninki.Add(FixedLengthParser.ReadString(span, 49 + (i * 8), 2));
            }
            OddsTansyoInfo_Ninki = JsonSerializer.Serialize(list_OddsTansyoInfo_Ninki);
            var list_OddsFukusyoInfo_Umaban = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_OddsFukusyoInfo_Umaban.Add(FixedLengthParser.ReadString(span, 267 + (i * 12), 2));
            }
            OddsFukusyoInfo_Umaban = JsonSerializer.Serialize(list_OddsFukusyoInfo_Umaban);
            var list_OddsFukusyoInfo_OddsLow = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_OddsFukusyoInfo_OddsLow.Add(FixedLengthParser.ReadString(span, 269 + (i * 12), 4));
            }
            OddsFukusyoInfo_OddsLow = JsonSerializer.Serialize(list_OddsFukusyoInfo_OddsLow);
            var list_OddsFukusyoInfo_OddsHigh = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_OddsFukusyoInfo_OddsHigh.Add(FixedLengthParser.ReadString(span, 273 + (i * 12), 4));
            }
            OddsFukusyoInfo_OddsHigh = JsonSerializer.Serialize(list_OddsFukusyoInfo_OddsHigh);
            var list_OddsFukusyoInfo_Ninki = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_OddsFukusyoInfo_Ninki.Add(FixedLengthParser.ReadString(span, 277 + (i * 12), 2));
            }
            OddsFukusyoInfo_Ninki = JsonSerializer.Serialize(list_OddsFukusyoInfo_Ninki);
            var list_OddsWakurenInfo_Kumi = new List<string>();
            for (int i = 0; i < 36; i++)
            {
                list_OddsWakurenInfo_Kumi.Add(FixedLengthParser.ReadString(span, 603 + (i * 9), 2));
            }
            OddsWakurenInfo_Kumi = JsonSerializer.Serialize(list_OddsWakurenInfo_Kumi);
            var list_OddsWakurenInfo_Odds = new List<string>();
            for (int i = 0; i < 36; i++)
            {
                list_OddsWakurenInfo_Odds.Add(FixedLengthParser.ReadString(span, 605 + (i * 9), 5));
            }
            OddsWakurenInfo_Odds = JsonSerializer.Serialize(list_OddsWakurenInfo_Odds);
            var list_OddsWakurenInfo_Ninki = new List<string>();
            for (int i = 0; i < 36; i++)
            {
                list_OddsWakurenInfo_Ninki.Add(FixedLengthParser.ReadString(span, 610 + (i * 9), 2));
            }
            OddsWakurenInfo_Ninki = JsonSerializer.Serialize(list_OddsWakurenInfo_Ninki);
            TotalHyosuTansyo = FixedLengthParser.ReadString(span, 927, 11);
            TotalHyosuFukusyo = FixedLengthParser.ReadString(span, 938, 11);
            TotalHyosuWakuren = FixedLengthParser.ReadString(span, 949, 11);
            crlf = FixedLengthParser.ReadString(span, 960, 2);
        }
    }
}
