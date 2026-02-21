using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_RA_RACE — Auto-generated entity
    /// </summary>
    public class RAEntity : JvEntity
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
        public string GradeCDBefore { get; private set; } = string.Empty;
        public string JyokenInfo_SyubetuCD { get; private set; } = string.Empty;
        public string JyokenInfo_KigoCD { get; private set; } = string.Empty;
        public string JyokenInfo_JyuryoCD { get; private set; } = string.Empty;
        public string JyokenInfo_JyokenCD { get; private set; } = string.Empty;
        public string JyokenName { get; private set; } = string.Empty;
        public string Kyori { get; private set; } = string.Empty;
        public string KyoriBefore { get; private set; } = string.Empty;
        public string TrackCD { get; private set; } = string.Empty;
        public string TrackCDBefore { get; private set; } = string.Empty;
        public string CourseKubunCD { get; private set; } = string.Empty;
        public string CourseKubunCDBefore { get; private set; } = string.Empty;
        public string Honsyokin { get; private set; } = string.Empty;
        public string HonsyokinBefore { get; private set; } = string.Empty;
        public string Fukasyokin { get; private set; } = string.Empty;
        public string FukasyokinBefore { get; private set; } = string.Empty;
        public string HassoTime { get; private set; } = string.Empty;
        public string HassoTimeBefore { get; private set; } = string.Empty;
        public string TorokuTosu { get; private set; } = string.Empty;
        public string SyussoTosu { get; private set; } = string.Empty;
        public string NyusenTosu { get; private set; } = string.Empty;
        public string TenkoBaba_TenkoCD { get; private set; } = string.Empty;
        public string TenkoBaba_SibaBabaCD { get; private set; } = string.Empty;
        public string TenkoBaba_DirtBabaCD { get; private set; } = string.Empty;
        public string LapTime { get; private set; } = string.Empty;
        public string SyogaiMileTime { get; private set; } = string.Empty;
        public string HaronTimeS3 { get; private set; } = string.Empty;
        public string HaronTimeS4 { get; private set; } = string.Empty;
        public string HaronTimeL3 { get; private set; } = string.Empty;
        public string HaronTimeL4 { get; private set; } = string.Empty;
        public string CornerInfo_Corner { get; private set; } = string.Empty;
        public string CornerInfo_Syukaisu { get; private set; } = string.Empty;
        public string CornerInfo_Jyuni { get; private set; } = string.Empty;
        public string RecordUpKubun { get; private set; } = string.Empty;
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
            GradeCDBefore = FixedLengthParser.ReadString(span, 615, 1);
            JyokenInfo_SyubetuCD = FixedLengthParser.ReadString(span, 616, 2);
            JyokenInfo_KigoCD = FixedLengthParser.ReadString(span, 618, 3);
            JyokenInfo_JyuryoCD = FixedLengthParser.ReadString(span, 621, 1);
            var list_JyokenInfo_JyokenCD = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list_JyokenInfo_JyokenCD.Add(FixedLengthParser.ReadString(span, 622 + (i * 3), 3));
            }
            JyokenInfo_JyokenCD = JsonSerializer.Serialize(list_JyokenInfo_JyokenCD);
            JyokenName = FixedLengthParser.ReadString(span, 637, 60);
            Kyori = FixedLengthParser.ReadString(span, 697, 4);
            KyoriBefore = FixedLengthParser.ReadString(span, 701, 4);
            TrackCD = FixedLengthParser.ReadString(span, 705, 2);
            TrackCDBefore = FixedLengthParser.ReadString(span, 707, 2);
            CourseKubunCD = FixedLengthParser.ReadString(span, 709, 2);
            CourseKubunCDBefore = FixedLengthParser.ReadString(span, 711, 2);
            var list_Honsyokin = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                list_Honsyokin.Add(FixedLengthParser.ReadString(span, 713 + (i * 8), 8));
            }
            Honsyokin = JsonSerializer.Serialize(list_Honsyokin);
            var list_HonsyokinBefore = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list_HonsyokinBefore.Add(FixedLengthParser.ReadString(span, 769 + (i * 8), 8));
            }
            HonsyokinBefore = JsonSerializer.Serialize(list_HonsyokinBefore);
            var list_Fukasyokin = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list_Fukasyokin.Add(FixedLengthParser.ReadString(span, 809 + (i * 8), 8));
            }
            Fukasyokin = JsonSerializer.Serialize(list_Fukasyokin);
            var list_FukasyokinBefore = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_FukasyokinBefore.Add(FixedLengthParser.ReadString(span, 849 + (i * 8), 8));
            }
            FukasyokinBefore = JsonSerializer.Serialize(list_FukasyokinBefore);
            HassoTime = FixedLengthParser.ReadString(span, 873, 4);
            HassoTimeBefore = FixedLengthParser.ReadString(span, 877, 4);
            TorokuTosu = FixedLengthParser.ReadString(span, 881, 2);
            SyussoTosu = FixedLengthParser.ReadString(span, 883, 2);
            NyusenTosu = FixedLengthParser.ReadString(span, 885, 2);
            TenkoBaba_TenkoCD = FixedLengthParser.ReadString(span, 887, 1);
            TenkoBaba_SibaBabaCD = FixedLengthParser.ReadString(span, 888, 1);
            TenkoBaba_DirtBabaCD = FixedLengthParser.ReadString(span, 889, 1);
            var list_LapTime = new List<string>();
            for (int i = 0; i < 25; i++)
            {
                list_LapTime.Add(FixedLengthParser.ReadString(span, 890 + (i * 3), 3));
            }
            LapTime = JsonSerializer.Serialize(list_LapTime);
            SyogaiMileTime = FixedLengthParser.ReadString(span, 965, 4);
            HaronTimeS3 = FixedLengthParser.ReadString(span, 969, 3);
            HaronTimeS4 = FixedLengthParser.ReadString(span, 972, 3);
            HaronTimeL3 = FixedLengthParser.ReadString(span, 975, 3);
            HaronTimeL4 = FixedLengthParser.ReadString(span, 978, 3);
            var list_CornerInfo_Corner = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                list_CornerInfo_Corner.Add(FixedLengthParser.ReadString(span, 981 + (i * 72), 1));
            }
            CornerInfo_Corner = JsonSerializer.Serialize(list_CornerInfo_Corner);
            var list_CornerInfo_Syukaisu = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                list_CornerInfo_Syukaisu.Add(FixedLengthParser.ReadString(span, 982 + (i * 72), 1));
            }
            CornerInfo_Syukaisu = JsonSerializer.Serialize(list_CornerInfo_Syukaisu);
            var list_CornerInfo_Jyuni = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                list_CornerInfo_Jyuni.Add(FixedLengthParser.ReadString(span, 983 + (i * 72), 70));
            }
            CornerInfo_Jyuni = JsonSerializer.Serialize(list_CornerInfo_Jyuni);
            RecordUpKubun = FixedLengthParser.ReadString(span, 1269, 1);
            crlf = FixedLengthParser.ReadString(span, 1270, 2);
        }
    }
}
