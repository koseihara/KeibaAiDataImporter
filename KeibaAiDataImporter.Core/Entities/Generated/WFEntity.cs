using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_WF_INFO — Auto-generated entity
    /// </summary>
    public class WFEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string KaisaiDate_Year { get; private set; } = string.Empty;
        public string KaisaiDate_Month { get; private set; } = string.Empty;
        public string KaisaiDate_Day { get; private set; } = string.Empty;
        public string reserved1 { get; private set; } = string.Empty;
        public string WFRaceInfo_JyoCD { get; private set; } = string.Empty;
        public string WFRaceInfo_Kaiji { get; private set; } = string.Empty;
        public string WFRaceInfo_Nichiji { get; private set; } = string.Empty;
        public string WFRaceInfo_RaceNum { get; private set; } = string.Empty;
        public string reserved2 { get; private set; } = string.Empty;
        public string Hatsubai_Hyo { get; private set; } = string.Empty;
        public string WFYukoHyoInfo_Yuko_Hyo { get; private set; } = string.Empty;
        public string HenkanFlag { get; private set; } = string.Empty;
        public string FuseiritsuFlag { get; private set; } = string.Empty;
        public string TekichunashiFlag { get; private set; } = string.Empty;
        public string COShoki { get; private set; } = string.Empty;
        public string COZanDaka { get; private set; } = string.Empty;
        public string WFPayInfo_Kumiban { get; private set; } = string.Empty;
        public string WFPayInfo_Pay { get; private set; } = string.Empty;
        public string WFPayInfo_Tekichu_Hyo { get; private set; } = string.Empty;
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
            KaisaiDate_Year = FixedLengthParser.ReadString(span, 11, 4);
            KaisaiDate_Month = FixedLengthParser.ReadString(span, 15, 2);
            KaisaiDate_Day = FixedLengthParser.ReadString(span, 17, 2);
            reserved1 = FixedLengthParser.ReadString(span, 19, 2);
            var list_WFRaceInfo_JyoCD = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list_WFRaceInfo_JyoCD.Add(FixedLengthParser.ReadString(span, 21 + (i * 8), 2));
            }
            WFRaceInfo_JyoCD = JsonSerializer.Serialize(list_WFRaceInfo_JyoCD);
            var list_WFRaceInfo_Kaiji = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list_WFRaceInfo_Kaiji.Add(FixedLengthParser.ReadString(span, 23 + (i * 8), 2));
            }
            WFRaceInfo_Kaiji = JsonSerializer.Serialize(list_WFRaceInfo_Kaiji);
            var list_WFRaceInfo_Nichiji = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list_WFRaceInfo_Nichiji.Add(FixedLengthParser.ReadString(span, 25 + (i * 8), 2));
            }
            WFRaceInfo_Nichiji = JsonSerializer.Serialize(list_WFRaceInfo_Nichiji);
            var list_WFRaceInfo_RaceNum = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list_WFRaceInfo_RaceNum.Add(FixedLengthParser.ReadString(span, 27 + (i * 8), 2));
            }
            WFRaceInfo_RaceNum = JsonSerializer.Serialize(list_WFRaceInfo_RaceNum);
            reserved2 = FixedLengthParser.ReadString(span, 61, 6);
            Hatsubai_Hyo = FixedLengthParser.ReadString(span, 67, 11);
            var list_WFYukoHyoInfo_Yuko_Hyo = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list_WFYukoHyoInfo_Yuko_Hyo.Add(FixedLengthParser.ReadString(span, 78 + (i * 11), 11));
            }
            WFYukoHyoInfo_Yuko_Hyo = JsonSerializer.Serialize(list_WFYukoHyoInfo_Yuko_Hyo);
            HenkanFlag = FixedLengthParser.ReadString(span, 133, 1);
            FuseiritsuFlag = FixedLengthParser.ReadString(span, 134, 1);
            TekichunashiFlag = FixedLengthParser.ReadString(span, 135, 1);
            COShoki = FixedLengthParser.ReadString(span, 136, 15);
            COZanDaka = FixedLengthParser.ReadString(span, 151, 15);
            var list_WFPayInfo_Kumiban = new List<string>();
            for (int i = 0; i < 243; i++)
            {
                list_WFPayInfo_Kumiban.Add(FixedLengthParser.ReadString(span, 166 + (i * 29), 10));
            }
            WFPayInfo_Kumiban = JsonSerializer.Serialize(list_WFPayInfo_Kumiban);
            var list_WFPayInfo_Pay = new List<string>();
            for (int i = 0; i < 243; i++)
            {
                list_WFPayInfo_Pay.Add(FixedLengthParser.ReadString(span, 176 + (i * 29), 9));
            }
            WFPayInfo_Pay = JsonSerializer.Serialize(list_WFPayInfo_Pay);
            var list_WFPayInfo_Tekichu_Hyo = new List<string>();
            for (int i = 0; i < 243; i++)
            {
                list_WFPayInfo_Tekichu_Hyo.Add(FixedLengthParser.ReadString(span, 185 + (i * 29), 10));
            }
            WFPayInfo_Tekichu_Hyo = JsonSerializer.Serialize(list_WFPayInfo_Tekichu_Hyo);
            crlf = FixedLengthParser.ReadString(span, 7213, 2);
        }
    }
}
