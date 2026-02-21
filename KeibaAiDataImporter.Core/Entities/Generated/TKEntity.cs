using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_TK_TOKUUMA — Auto-generated entity
    /// </summary>
    public class TKEntity : JvEntity
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
        public string RaceInfo_YoubiCD { get; private set; } = string.Empty;
        public string RaceInfo_TokuNum { get; private set; } = string.Empty;
        public string RaceInfo_Hondai { get; private set; } = string.Empty;
        public string RaceInfo_Fukudai { get; private set; } = string.Empty;
        public string RaceInfo_Kakko { get; private set; } = string.Empty;
        public string RaceInfo_HondaiEng { get; private set; } = string.Empty;
        public string RaceInfo_FukudaiEng { get; private set; } = string.Empty;
        public string RaceInfo_KakkoEng { get; private set; } = string.Empty;
        public string RaceInfo_Ryakusyo10 { get; private set; } = string.Empty;
        public string RaceInfo_Ryakusyo6 { get; private set; } = string.Empty;
        public string RaceInfo_Ryakusyo3 { get; private set; } = string.Empty;
        public string RaceInfo_Kubun { get; private set; } = string.Empty;
        public string RaceInfo_Nkai { get; private set; } = string.Empty;
        public string GradeCD { get; private set; } = string.Empty;
        public string JyokenInfo_SyubetuCD { get; private set; } = string.Empty;
        public string JyokenInfo_KigoCD { get; private set; } = string.Empty;
        public string JyokenInfo_JyuryoCD { get; private set; } = string.Empty;
        public string JyokenInfo_JyokenCD { get; private set; } = string.Empty;
        public string Kyori { get; private set; } = string.Empty;
        public string TrackCD { get; private set; } = string.Empty;
        public string CourseKubunCD { get; private set; } = string.Empty;
        public string HandiDate_Year { get; private set; } = string.Empty;
        public string HandiDate_Month { get; private set; } = string.Empty;
        public string HandiDate_Day { get; private set; } = string.Empty;
        public string TorokuTosu { get; private set; } = string.Empty;
        public string TokuUmaInfo_Num { get; private set; } = string.Empty;
        public string TokuUmaInfo_KettoNum { get; private set; } = string.Empty;
        public string TokuUmaInfo_Bamei { get; private set; } = string.Empty;
        public string TokuUmaInfo_UmaKigoCD { get; private set; } = string.Empty;
        public string TokuUmaInfo_SexCD { get; private set; } = string.Empty;
        public string TokuUmaInfo_TozaiCD { get; private set; } = string.Empty;
        public string TokuUmaInfo_ChokyosiCode { get; private set; } = string.Empty;
        public string TokuUmaInfo_ChokyosiRyakusyo { get; private set; } = string.Empty;
        public string TokuUmaInfo_Futan { get; private set; } = string.Empty;
        public string TokuUmaInfo_Koryu { get; private set; } = string.Empty;
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
            RaceInfo_YoubiCD = FixedLengthParser.ReadString(span, 27, 1);
            RaceInfo_TokuNum = FixedLengthParser.ReadString(span, 28, 4);
            RaceInfo_Hondai = FixedLengthParser.ReadString(span, 32, 60);
            RaceInfo_Fukudai = FixedLengthParser.ReadString(span, 92, 60);
            RaceInfo_Kakko = FixedLengthParser.ReadString(span, 152, 60);
            RaceInfo_HondaiEng = FixedLengthParser.ReadString(span, 212, 120);
            RaceInfo_FukudaiEng = FixedLengthParser.ReadString(span, 332, 120);
            RaceInfo_KakkoEng = FixedLengthParser.ReadString(span, 452, 120);
            RaceInfo_Ryakusyo10 = FixedLengthParser.ReadString(span, 572, 20);
            RaceInfo_Ryakusyo6 = FixedLengthParser.ReadString(span, 592, 12);
            RaceInfo_Ryakusyo3 = FixedLengthParser.ReadString(span, 604, 6);
            RaceInfo_Kubun = FixedLengthParser.ReadString(span, 610, 1);
            RaceInfo_Nkai = FixedLengthParser.ReadString(span, 611, 3);
            GradeCD = FixedLengthParser.ReadString(span, 614, 1);
            JyokenInfo_SyubetuCD = FixedLengthParser.ReadString(span, 615, 2);
            JyokenInfo_KigoCD = FixedLengthParser.ReadString(span, 617, 3);
            JyokenInfo_JyuryoCD = FixedLengthParser.ReadString(span, 620, 1);
            var list_JyokenInfo_JyokenCD = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list_JyokenInfo_JyokenCD.Add(FixedLengthParser.ReadString(span, 621 + (i * 3), 3));
            }
            JyokenInfo_JyokenCD = JsonSerializer.Serialize(list_JyokenInfo_JyokenCD);
            Kyori = FixedLengthParser.ReadString(span, 636, 4);
            TrackCD = FixedLengthParser.ReadString(span, 640, 2);
            CourseKubunCD = FixedLengthParser.ReadString(span, 642, 2);
            HandiDate_Year = FixedLengthParser.ReadString(span, 644, 4);
            HandiDate_Month = FixedLengthParser.ReadString(span, 648, 2);
            HandiDate_Day = FixedLengthParser.ReadString(span, 650, 2);
            TorokuTosu = FixedLengthParser.ReadString(span, 652, 3);
            var list_TokuUmaInfo_Num = new List<string>();
            for (int i = 0; i < 300; i++)
            {
                list_TokuUmaInfo_Num.Add(FixedLengthParser.ReadString(span, 655 + (i * 70), 3));
            }
            TokuUmaInfo_Num = JsonSerializer.Serialize(list_TokuUmaInfo_Num);
            var list_TokuUmaInfo_KettoNum = new List<string>();
            for (int i = 0; i < 300; i++)
            {
                list_TokuUmaInfo_KettoNum.Add(FixedLengthParser.ReadString(span, 658 + (i * 70), 10));
            }
            TokuUmaInfo_KettoNum = JsonSerializer.Serialize(list_TokuUmaInfo_KettoNum);
            var list_TokuUmaInfo_Bamei = new List<string>();
            for (int i = 0; i < 300; i++)
            {
                list_TokuUmaInfo_Bamei.Add(FixedLengthParser.ReadString(span, 668 + (i * 70), 36));
            }
            TokuUmaInfo_Bamei = JsonSerializer.Serialize(list_TokuUmaInfo_Bamei);
            var list_TokuUmaInfo_UmaKigoCD = new List<string>();
            for (int i = 0; i < 300; i++)
            {
                list_TokuUmaInfo_UmaKigoCD.Add(FixedLengthParser.ReadString(span, 704 + (i * 70), 2));
            }
            TokuUmaInfo_UmaKigoCD = JsonSerializer.Serialize(list_TokuUmaInfo_UmaKigoCD);
            var list_TokuUmaInfo_SexCD = new List<string>();
            for (int i = 0; i < 300; i++)
            {
                list_TokuUmaInfo_SexCD.Add(FixedLengthParser.ReadString(span, 706 + (i * 70), 1));
            }
            TokuUmaInfo_SexCD = JsonSerializer.Serialize(list_TokuUmaInfo_SexCD);
            var list_TokuUmaInfo_TozaiCD = new List<string>();
            for (int i = 0; i < 300; i++)
            {
                list_TokuUmaInfo_TozaiCD.Add(FixedLengthParser.ReadString(span, 707 + (i * 70), 1));
            }
            TokuUmaInfo_TozaiCD = JsonSerializer.Serialize(list_TokuUmaInfo_TozaiCD);
            var list_TokuUmaInfo_ChokyosiCode = new List<string>();
            for (int i = 0; i < 300; i++)
            {
                list_TokuUmaInfo_ChokyosiCode.Add(FixedLengthParser.ReadString(span, 708 + (i * 70), 5));
            }
            TokuUmaInfo_ChokyosiCode = JsonSerializer.Serialize(list_TokuUmaInfo_ChokyosiCode);
            var list_TokuUmaInfo_ChokyosiRyakusyo = new List<string>();
            for (int i = 0; i < 300; i++)
            {
                list_TokuUmaInfo_ChokyosiRyakusyo.Add(FixedLengthParser.ReadString(span, 713 + (i * 70), 8));
            }
            TokuUmaInfo_ChokyosiRyakusyo = JsonSerializer.Serialize(list_TokuUmaInfo_ChokyosiRyakusyo);
            var list_TokuUmaInfo_Futan = new List<string>();
            for (int i = 0; i < 300; i++)
            {
                list_TokuUmaInfo_Futan.Add(FixedLengthParser.ReadString(span, 721 + (i * 70), 3));
            }
            TokuUmaInfo_Futan = JsonSerializer.Serialize(list_TokuUmaInfo_Futan);
            var list_TokuUmaInfo_Koryu = new List<string>();
            for (int i = 0; i < 300; i++)
            {
                list_TokuUmaInfo_Koryu.Add(FixedLengthParser.ReadString(span, 724 + (i * 70), 1));
            }
            TokuUmaInfo_Koryu = JsonSerializer.Serialize(list_TokuUmaInfo_Koryu);
            crlf = FixedLengthParser.ReadString(span, 21655, 2);
        }
    }
}
