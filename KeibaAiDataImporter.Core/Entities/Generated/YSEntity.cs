using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_YS_SCHEDULE — Auto-generated entity
    /// </summary>
    public class YSEntity : JvEntity
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
        public string YoubiCD { get; private set; } = string.Empty;
        public string JyusyoInfo_TokuNum { get; private set; } = string.Empty;
        public string JyusyoInfo_Hondai { get; private set; } = string.Empty;
        public string JyusyoInfo_Ryakusyo10 { get; private set; } = string.Empty;
        public string JyusyoInfo_Ryakusyo6 { get; private set; } = string.Empty;
        public string JyusyoInfo_Ryakusyo3 { get; private set; } = string.Empty;
        public string JyusyoInfo_Nkai { get; private set; } = string.Empty;
        public string JyusyoInfo_GradeCD { get; private set; } = string.Empty;
        public string JyusyoInfo_SyubetuCD { get; private set; } = string.Empty;
        public string JyusyoInfo_KigoCD { get; private set; } = string.Empty;
        public string JyusyoInfo_JyuryoCD { get; private set; } = string.Empty;
        public string JyusyoInfo_Kyori { get; private set; } = string.Empty;
        public string JyusyoInfo_TrackCD { get; private set; } = string.Empty;
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
            YoubiCD = FixedLengthParser.ReadString(span, 25, 1);
            var list_JyusyoInfo_TokuNum = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_JyusyoInfo_TokuNum.Add(FixedLengthParser.ReadString(span, 26 + (i * 118), 4));
            }
            JyusyoInfo_TokuNum = JsonSerializer.Serialize(list_JyusyoInfo_TokuNum);
            var list_JyusyoInfo_Hondai = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_JyusyoInfo_Hondai.Add(FixedLengthParser.ReadString(span, 30 + (i * 118), 60));
            }
            JyusyoInfo_Hondai = JsonSerializer.Serialize(list_JyusyoInfo_Hondai);
            var list_JyusyoInfo_Ryakusyo10 = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_JyusyoInfo_Ryakusyo10.Add(FixedLengthParser.ReadString(span, 90 + (i * 118), 20));
            }
            JyusyoInfo_Ryakusyo10 = JsonSerializer.Serialize(list_JyusyoInfo_Ryakusyo10);
            var list_JyusyoInfo_Ryakusyo6 = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_JyusyoInfo_Ryakusyo6.Add(FixedLengthParser.ReadString(span, 110 + (i * 118), 12));
            }
            JyusyoInfo_Ryakusyo6 = JsonSerializer.Serialize(list_JyusyoInfo_Ryakusyo6);
            var list_JyusyoInfo_Ryakusyo3 = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_JyusyoInfo_Ryakusyo3.Add(FixedLengthParser.ReadString(span, 122 + (i * 118), 6));
            }
            JyusyoInfo_Ryakusyo3 = JsonSerializer.Serialize(list_JyusyoInfo_Ryakusyo3);
            var list_JyusyoInfo_Nkai = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_JyusyoInfo_Nkai.Add(FixedLengthParser.ReadString(span, 128 + (i * 118), 3));
            }
            JyusyoInfo_Nkai = JsonSerializer.Serialize(list_JyusyoInfo_Nkai);
            var list_JyusyoInfo_GradeCD = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_JyusyoInfo_GradeCD.Add(FixedLengthParser.ReadString(span, 131 + (i * 118), 1));
            }
            JyusyoInfo_GradeCD = JsonSerializer.Serialize(list_JyusyoInfo_GradeCD);
            var list_JyusyoInfo_SyubetuCD = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_JyusyoInfo_SyubetuCD.Add(FixedLengthParser.ReadString(span, 132 + (i * 118), 2));
            }
            JyusyoInfo_SyubetuCD = JsonSerializer.Serialize(list_JyusyoInfo_SyubetuCD);
            var list_JyusyoInfo_KigoCD = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_JyusyoInfo_KigoCD.Add(FixedLengthParser.ReadString(span, 134 + (i * 118), 3));
            }
            JyusyoInfo_KigoCD = JsonSerializer.Serialize(list_JyusyoInfo_KigoCD);
            var list_JyusyoInfo_JyuryoCD = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_JyusyoInfo_JyuryoCD.Add(FixedLengthParser.ReadString(span, 137 + (i * 118), 1));
            }
            JyusyoInfo_JyuryoCD = JsonSerializer.Serialize(list_JyusyoInfo_JyuryoCD);
            var list_JyusyoInfo_Kyori = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_JyusyoInfo_Kyori.Add(FixedLengthParser.ReadString(span, 138 + (i * 118), 4));
            }
            JyusyoInfo_Kyori = JsonSerializer.Serialize(list_JyusyoInfo_Kyori);
            var list_JyusyoInfo_TrackCD = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_JyusyoInfo_TrackCD.Add(FixedLengthParser.ReadString(span, 142 + (i * 118), 2));
            }
            JyusyoInfo_TrackCD = JsonSerializer.Serialize(list_JyusyoInfo_TrackCD);
            crlf = FixedLengthParser.ReadString(span, 380, 2);
        }
    }
}
