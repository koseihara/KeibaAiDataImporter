using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_CH_CHOKYOSI — Auto-generated entity
    /// </summary>
    public class CHEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string ChokyosiCode { get; private set; } = string.Empty;
        public string DelKubun { get; private set; } = string.Empty;
        public string IssueDate_Year { get; private set; } = string.Empty;
        public string IssueDate_Month { get; private set; } = string.Empty;
        public string IssueDate_Day { get; private set; } = string.Empty;
        public string DelDate_Year { get; private set; } = string.Empty;
        public string DelDate_Month { get; private set; } = string.Empty;
        public string DelDate_Day { get; private set; } = string.Empty;
        public string BirthDate_Year { get; private set; } = string.Empty;
        public string BirthDate_Month { get; private set; } = string.Empty;
        public string BirthDate_Day { get; private set; } = string.Empty;
        public string ChokyosiName { get; private set; } = string.Empty;
        public string ChokyosiNameKana { get; private set; } = string.Empty;
        public string ChokyosiRyakusyo { get; private set; } = string.Empty;
        public string ChokyosiNameEng { get; private set; } = string.Empty;
        public string SexCD { get; private set; } = string.Empty;
        public string TozaiCD { get; private set; } = string.Empty;
        public string Syotai { get; private set; } = string.Empty;
        public string SaikinJyusyo_SaikinJyusyoid_Year { get; private set; } = string.Empty;
        public string SaikinJyusyo_SaikinJyusyoid_MonthDay { get; private set; } = string.Empty;
        public string SaikinJyusyo_SaikinJyusyoid_JyoCD { get; private set; } = string.Empty;
        public string SaikinJyusyo_SaikinJyusyoid_Kaiji { get; private set; } = string.Empty;
        public string SaikinJyusyo_SaikinJyusyoid_Nichiji { get; private set; } = string.Empty;
        public string SaikinJyusyo_SaikinJyusyoid_RaceNum { get; private set; } = string.Empty;
        public string SaikinJyusyo_Hondai { get; private set; } = string.Empty;
        public string SaikinJyusyo_Ryakusyo10 { get; private set; } = string.Empty;
        public string SaikinJyusyo_Ryakusyo6 { get; private set; } = string.Empty;
        public string SaikinJyusyo_Ryakusyo3 { get; private set; } = string.Empty;
        public string SaikinJyusyo_GradeCD { get; private set; } = string.Empty;
        public string SaikinJyusyo_SyussoTosu { get; private set; } = string.Empty;
        public string SaikinJyusyo_KettoNum { get; private set; } = string.Empty;
        public string SaikinJyusyo_Bamei { get; private set; } = string.Empty;
        public string HonZenRuikei_SetYear { get; private set; } = string.Empty;
        public string HonZenRuikei_HonSyokinHeichi { get; private set; } = string.Empty;
        public string HonZenRuikei_HonSyokinSyogai { get; private set; } = string.Empty;
        public string HonZenRuikei_FukaSyokinHeichi { get; private set; } = string.Empty;
        public string HonZenRuikei_FukaSyokinSyogai { get; private set; } = string.Empty;
        public string HonZenRuikei_ChakuKaisuHeichi_ChakuKaisu { get; private set; } = string.Empty;
        public string HonZenRuikei_ChakuKaisuSyogai_ChakuKaisu { get; private set; } = string.Empty;
        public string HonZenRuikei_ChakuKaisuJyo_ChakuKaisu { get; private set; } = string.Empty;
        public string HonZenRuikei_ChakuKaisuKyori_ChakuKaisu { get; private set; } = string.Empty;
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
            ChokyosiCode = FixedLengthParser.ReadString(span, 11, 5);
            DelKubun = FixedLengthParser.ReadString(span, 16, 1);
            IssueDate_Year = FixedLengthParser.ReadString(span, 17, 4);
            IssueDate_Month = FixedLengthParser.ReadString(span, 21, 2);
            IssueDate_Day = FixedLengthParser.ReadString(span, 23, 2);
            DelDate_Year = FixedLengthParser.ReadString(span, 25, 4);
            DelDate_Month = FixedLengthParser.ReadString(span, 29, 2);
            DelDate_Day = FixedLengthParser.ReadString(span, 31, 2);
            BirthDate_Year = FixedLengthParser.ReadString(span, 33, 4);
            BirthDate_Month = FixedLengthParser.ReadString(span, 37, 2);
            BirthDate_Day = FixedLengthParser.ReadString(span, 39, 2);
            ChokyosiName = FixedLengthParser.ReadString(span, 41, 34);
            ChokyosiNameKana = FixedLengthParser.ReadString(span, 75, 30);
            ChokyosiRyakusyo = FixedLengthParser.ReadString(span, 105, 8);
            ChokyosiNameEng = FixedLengthParser.ReadString(span, 113, 80);
            SexCD = FixedLengthParser.ReadString(span, 193, 1);
            TozaiCD = FixedLengthParser.ReadString(span, 194, 1);
            Syotai = FixedLengthParser.ReadString(span, 195, 20);
            var list_SaikinJyusyo_SaikinJyusyoid_Year = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SaikinJyusyoid_Year.Add(FixedLengthParser.ReadString(span, 215 + (i * 163), 4));
            }
            SaikinJyusyo_SaikinJyusyoid_Year = JsonSerializer.Serialize(list_SaikinJyusyo_SaikinJyusyoid_Year);
            var list_SaikinJyusyo_SaikinJyusyoid_MonthDay = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SaikinJyusyoid_MonthDay.Add(FixedLengthParser.ReadString(span, 219 + (i * 163), 4));
            }
            SaikinJyusyo_SaikinJyusyoid_MonthDay = JsonSerializer.Serialize(list_SaikinJyusyo_SaikinJyusyoid_MonthDay);
            var list_SaikinJyusyo_SaikinJyusyoid_JyoCD = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SaikinJyusyoid_JyoCD.Add(FixedLengthParser.ReadString(span, 223 + (i * 163), 2));
            }
            SaikinJyusyo_SaikinJyusyoid_JyoCD = JsonSerializer.Serialize(list_SaikinJyusyo_SaikinJyusyoid_JyoCD);
            var list_SaikinJyusyo_SaikinJyusyoid_Kaiji = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SaikinJyusyoid_Kaiji.Add(FixedLengthParser.ReadString(span, 225 + (i * 163), 2));
            }
            SaikinJyusyo_SaikinJyusyoid_Kaiji = JsonSerializer.Serialize(list_SaikinJyusyo_SaikinJyusyoid_Kaiji);
            var list_SaikinJyusyo_SaikinJyusyoid_Nichiji = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SaikinJyusyoid_Nichiji.Add(FixedLengthParser.ReadString(span, 227 + (i * 163), 2));
            }
            SaikinJyusyo_SaikinJyusyoid_Nichiji = JsonSerializer.Serialize(list_SaikinJyusyo_SaikinJyusyoid_Nichiji);
            var list_SaikinJyusyo_SaikinJyusyoid_RaceNum = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SaikinJyusyoid_RaceNum.Add(FixedLengthParser.ReadString(span, 229 + (i * 163), 2));
            }
            SaikinJyusyo_SaikinJyusyoid_RaceNum = JsonSerializer.Serialize(list_SaikinJyusyo_SaikinJyusyoid_RaceNum);
            var list_SaikinJyusyo_Hondai = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_Hondai.Add(FixedLengthParser.ReadString(span, 231 + (i * 163), 60));
            }
            SaikinJyusyo_Hondai = JsonSerializer.Serialize(list_SaikinJyusyo_Hondai);
            var list_SaikinJyusyo_Ryakusyo10 = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_Ryakusyo10.Add(FixedLengthParser.ReadString(span, 291 + (i * 163), 20));
            }
            SaikinJyusyo_Ryakusyo10 = JsonSerializer.Serialize(list_SaikinJyusyo_Ryakusyo10);
            var list_SaikinJyusyo_Ryakusyo6 = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_Ryakusyo6.Add(FixedLengthParser.ReadString(span, 311 + (i * 163), 12));
            }
            SaikinJyusyo_Ryakusyo6 = JsonSerializer.Serialize(list_SaikinJyusyo_Ryakusyo6);
            var list_SaikinJyusyo_Ryakusyo3 = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_Ryakusyo3.Add(FixedLengthParser.ReadString(span, 323 + (i * 163), 6));
            }
            SaikinJyusyo_Ryakusyo3 = JsonSerializer.Serialize(list_SaikinJyusyo_Ryakusyo3);
            var list_SaikinJyusyo_GradeCD = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_GradeCD.Add(FixedLengthParser.ReadString(span, 329 + (i * 163), 1));
            }
            SaikinJyusyo_GradeCD = JsonSerializer.Serialize(list_SaikinJyusyo_GradeCD);
            var list_SaikinJyusyo_SyussoTosu = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SyussoTosu.Add(FixedLengthParser.ReadString(span, 330 + (i * 163), 2));
            }
            SaikinJyusyo_SyussoTosu = JsonSerializer.Serialize(list_SaikinJyusyo_SyussoTosu);
            var list_SaikinJyusyo_KettoNum = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_KettoNum.Add(FixedLengthParser.ReadString(span, 332 + (i * 163), 10));
            }
            SaikinJyusyo_KettoNum = JsonSerializer.Serialize(list_SaikinJyusyo_KettoNum);
            var list_SaikinJyusyo_Bamei = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_Bamei.Add(FixedLengthParser.ReadString(span, 342 + (i * 163), 36));
            }
            SaikinJyusyo_Bamei = JsonSerializer.Serialize(list_SaikinJyusyo_Bamei);
            var list_HonZenRuikei_SetYear = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_SetYear.Add(FixedLengthParser.ReadString(span, 704 + (i * 1052), 4));
            }
            HonZenRuikei_SetYear = JsonSerializer.Serialize(list_HonZenRuikei_SetYear);
            var list_HonZenRuikei_HonSyokinHeichi = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_HonSyokinHeichi.Add(FixedLengthParser.ReadString(span, 708 + (i * 1052), 10));
            }
            HonZenRuikei_HonSyokinHeichi = JsonSerializer.Serialize(list_HonZenRuikei_HonSyokinHeichi);
            var list_HonZenRuikei_HonSyokinSyogai = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_HonSyokinSyogai.Add(FixedLengthParser.ReadString(span, 718 + (i * 1052), 10));
            }
            HonZenRuikei_HonSyokinSyogai = JsonSerializer.Serialize(list_HonZenRuikei_HonSyokinSyogai);
            var list_HonZenRuikei_FukaSyokinHeichi = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_FukaSyokinHeichi.Add(FixedLengthParser.ReadString(span, 728 + (i * 1052), 10));
            }
            HonZenRuikei_FukaSyokinHeichi = JsonSerializer.Serialize(list_HonZenRuikei_FukaSyokinHeichi);
            var list_HonZenRuikei_FukaSyokinSyogai = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_FukaSyokinSyogai.Add(FixedLengthParser.ReadString(span, 738 + (i * 1052), 10));
            }
            HonZenRuikei_FukaSyokinSyogai = JsonSerializer.Serialize(list_HonZenRuikei_FukaSyokinSyogai);
            var list_HonZenRuikei_ChakuKaisuHeichi_ChakuKaisu = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_ChakuKaisuHeichi_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 748 + (i * 1052), 6));
            }
            HonZenRuikei_ChakuKaisuHeichi_ChakuKaisu = JsonSerializer.Serialize(list_HonZenRuikei_ChakuKaisuHeichi_ChakuKaisu);
            var list_HonZenRuikei_ChakuKaisuSyogai_ChakuKaisu = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_ChakuKaisuSyogai_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 784 + (i * 1052), 6));
            }
            HonZenRuikei_ChakuKaisuSyogai_ChakuKaisu = JsonSerializer.Serialize(list_HonZenRuikei_ChakuKaisuSyogai_ChakuKaisu);
            var list_HonZenRuikei_ChakuKaisuJyo_ChakuKaisu = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_ChakuKaisuJyo_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 820 + (i * 1052), 6));
            }
            HonZenRuikei_ChakuKaisuJyo_ChakuKaisu = JsonSerializer.Serialize(list_HonZenRuikei_ChakuKaisuJyo_ChakuKaisu);
            var list_HonZenRuikei_ChakuKaisuKyori_ChakuKaisu = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_ChakuKaisuKyori_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1540 + (i * 1052), 6));
            }
            HonZenRuikei_ChakuKaisuKyori_ChakuKaisu = JsonSerializer.Serialize(list_HonZenRuikei_ChakuKaisuKyori_ChakuKaisu);
            crlf = FixedLengthParser.ReadString(span, 3860, 2);
        }
    }
}
