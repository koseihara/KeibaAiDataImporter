using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_RC_RECORD — Auto-generated entity
    /// </summary>
    public class RCEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string RecInfoKubun { get; private set; } = string.Empty;
        public string id_Year { get; private set; } = string.Empty;
        public string id_MonthDay { get; private set; } = string.Empty;
        public string id_JyoCD { get; private set; } = string.Empty;
        public string id_Kaiji { get; private set; } = string.Empty;
        public string id_Nichiji { get; private set; } = string.Empty;
        public string id_RaceNum { get; private set; } = string.Empty;
        public string TokuNum { get; private set; } = string.Empty;
        public string Hondai { get; private set; } = string.Empty;
        public string GradeCD { get; private set; } = string.Empty;
        public string SyubetuCD { get; private set; } = string.Empty;
        public string Kyori { get; private set; } = string.Empty;
        public string TrackCD { get; private set; } = string.Empty;
        public string RecKubun { get; private set; } = string.Empty;
        public string RecTime { get; private set; } = string.Empty;
        public string TenkoBaba_TenkoCD { get; private set; } = string.Empty;
        public string TenkoBaba_SibaBabaCD { get; private set; } = string.Empty;
        public string TenkoBaba_DirtBabaCD { get; private set; } = string.Empty;
        public string RecUmaInfo_KettoNum { get; private set; } = string.Empty;
        public string RecUmaInfo_Bamei { get; private set; } = string.Empty;
        public string RecUmaInfo_UmaKigoCD { get; private set; } = string.Empty;
        public string RecUmaInfo_SexCD { get; private set; } = string.Empty;
        public string RecUmaInfo_ChokyosiCode { get; private set; } = string.Empty;
        public string RecUmaInfo_ChokyosiName { get; private set; } = string.Empty;
        public string RecUmaInfo_Futan { get; private set; } = string.Empty;
        public string RecUmaInfo_KisyuCode { get; private set; } = string.Empty;
        public string RecUmaInfo_KisyuName { get; private set; } = string.Empty;
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
            RecInfoKubun = FixedLengthParser.ReadString(span, 11, 1);
            id_Year = FixedLengthParser.ReadString(span, 12, 4);
            id_MonthDay = FixedLengthParser.ReadString(span, 16, 4);
            id_JyoCD = FixedLengthParser.ReadString(span, 20, 2);
            id_Kaiji = FixedLengthParser.ReadString(span, 22, 2);
            id_Nichiji = FixedLengthParser.ReadString(span, 24, 2);
            id_RaceNum = FixedLengthParser.ReadString(span, 26, 2);
            TokuNum = FixedLengthParser.ReadString(span, 28, 4);
            Hondai = FixedLengthParser.ReadString(span, 32, 60);
            GradeCD = FixedLengthParser.ReadString(span, 92, 1);
            SyubetuCD = FixedLengthParser.ReadString(span, 93, 2);
            Kyori = FixedLengthParser.ReadString(span, 95, 4);
            TrackCD = FixedLengthParser.ReadString(span, 99, 2);
            RecKubun = FixedLengthParser.ReadString(span, 101, 1);
            RecTime = FixedLengthParser.ReadString(span, 102, 4);
            TenkoBaba_TenkoCD = FixedLengthParser.ReadString(span, 106, 1);
            TenkoBaba_SibaBabaCD = FixedLengthParser.ReadString(span, 107, 1);
            TenkoBaba_DirtBabaCD = FixedLengthParser.ReadString(span, 108, 1);
            var list_RecUmaInfo_KettoNum = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_RecUmaInfo_KettoNum.Add(FixedLengthParser.ReadString(span, 109 + (i * 130), 10));
            }
            RecUmaInfo_KettoNum = JsonSerializer.Serialize(list_RecUmaInfo_KettoNum);
            var list_RecUmaInfo_Bamei = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_RecUmaInfo_Bamei.Add(FixedLengthParser.ReadString(span, 119 + (i * 130), 36));
            }
            RecUmaInfo_Bamei = JsonSerializer.Serialize(list_RecUmaInfo_Bamei);
            var list_RecUmaInfo_UmaKigoCD = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_RecUmaInfo_UmaKigoCD.Add(FixedLengthParser.ReadString(span, 155 + (i * 130), 2));
            }
            RecUmaInfo_UmaKigoCD = JsonSerializer.Serialize(list_RecUmaInfo_UmaKigoCD);
            var list_RecUmaInfo_SexCD = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_RecUmaInfo_SexCD.Add(FixedLengthParser.ReadString(span, 157 + (i * 130), 1));
            }
            RecUmaInfo_SexCD = JsonSerializer.Serialize(list_RecUmaInfo_SexCD);
            var list_RecUmaInfo_ChokyosiCode = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_RecUmaInfo_ChokyosiCode.Add(FixedLengthParser.ReadString(span, 158 + (i * 130), 5));
            }
            RecUmaInfo_ChokyosiCode = JsonSerializer.Serialize(list_RecUmaInfo_ChokyosiCode);
            var list_RecUmaInfo_ChokyosiName = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_RecUmaInfo_ChokyosiName.Add(FixedLengthParser.ReadString(span, 163 + (i * 130), 34));
            }
            RecUmaInfo_ChokyosiName = JsonSerializer.Serialize(list_RecUmaInfo_ChokyosiName);
            var list_RecUmaInfo_Futan = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_RecUmaInfo_Futan.Add(FixedLengthParser.ReadString(span, 197 + (i * 130), 3));
            }
            RecUmaInfo_Futan = JsonSerializer.Serialize(list_RecUmaInfo_Futan);
            var list_RecUmaInfo_KisyuCode = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_RecUmaInfo_KisyuCode.Add(FixedLengthParser.ReadString(span, 200 + (i * 130), 5));
            }
            RecUmaInfo_KisyuCode = JsonSerializer.Serialize(list_RecUmaInfo_KisyuCode);
            var list_RecUmaInfo_KisyuName = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_RecUmaInfo_KisyuName.Add(FixedLengthParser.ReadString(span, 205 + (i * 130), 34));
            }
            RecUmaInfo_KisyuName = JsonSerializer.Serialize(list_RecUmaInfo_KisyuName);
            crlf = FixedLengthParser.ReadString(span, 499, 2);
        }
    }
}
