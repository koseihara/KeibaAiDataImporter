using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_KS_KISYU — Auto-generated entity
    /// </summary>
    public class KSEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string KisyuCode { get; private set; } = string.Empty;
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
        public string KisyuName { get; private set; } = string.Empty;
        public string reserved { get; private set; } = string.Empty;
        public string KisyuNameKana { get; private set; } = string.Empty;
        public string KisyuRyakusyo { get; private set; } = string.Empty;
        public string KisyuNameEng { get; private set; } = string.Empty;
        public string SexCD { get; private set; } = string.Empty;
        public string SikakuCD { get; private set; } = string.Empty;
        public string MinaraiCD { get; private set; } = string.Empty;
        public string TozaiCD { get; private set; } = string.Empty;
        public string Syotai { get; private set; } = string.Empty;
        public string ChokyosiCode { get; private set; } = string.Empty;
        public string ChokyosiRyakusyo { get; private set; } = string.Empty;
        public string HatuKiJyo_Hatukijyoid_Year { get; private set; } = string.Empty;
        public string HatuKiJyo_Hatukijyoid_MonthDay { get; private set; } = string.Empty;
        public string HatuKiJyo_Hatukijyoid_JyoCD { get; private set; } = string.Empty;
        public string HatuKiJyo_Hatukijyoid_Kaiji { get; private set; } = string.Empty;
        public string HatuKiJyo_Hatukijyoid_Nichiji { get; private set; } = string.Empty;
        public string HatuKiJyo_Hatukijyoid_RaceNum { get; private set; } = string.Empty;
        public string HatuKiJyo_SyussoTosu { get; private set; } = string.Empty;
        public string HatuKiJyo_KettoNum { get; private set; } = string.Empty;
        public string HatuKiJyo_Bamei { get; private set; } = string.Empty;
        public string HatuKiJyo_KakuteiJyuni { get; private set; } = string.Empty;
        public string HatuKiJyo_IJyoCD { get; private set; } = string.Empty;
        public string HatuSyori_Hatukijyoid_Year { get; private set; } = string.Empty;
        public string HatuSyori_Hatukijyoid_MonthDay { get; private set; } = string.Empty;
        public string HatuSyori_Hatukijyoid_JyoCD { get; private set; } = string.Empty;
        public string HatuSyori_Hatukijyoid_Kaiji { get; private set; } = string.Empty;
        public string HatuSyori_Hatukijyoid_Nichiji { get; private set; } = string.Empty;
        public string HatuSyori_Hatukijyoid_RaceNum { get; private set; } = string.Empty;
        public string HatuSyori_SyussoTosu { get; private set; } = string.Empty;
        public string HatuSyori_KettoNum { get; private set; } = string.Empty;
        public string HatuSyori_Bamei { get; private set; } = string.Empty;
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
            KisyuCode = FixedLengthParser.ReadString(span, 11, 5);
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
            KisyuName = FixedLengthParser.ReadString(span, 41, 34);
            reserved = FixedLengthParser.ReadString(span, 75, 34);
            KisyuNameKana = FixedLengthParser.ReadString(span, 109, 30);
            KisyuRyakusyo = FixedLengthParser.ReadString(span, 139, 8);
            KisyuNameEng = FixedLengthParser.ReadString(span, 147, 80);
            SexCD = FixedLengthParser.ReadString(span, 227, 1);
            SikakuCD = FixedLengthParser.ReadString(span, 228, 1);
            MinaraiCD = FixedLengthParser.ReadString(span, 229, 1);
            TozaiCD = FixedLengthParser.ReadString(span, 230, 1);
            Syotai = FixedLengthParser.ReadString(span, 231, 20);
            ChokyosiCode = FixedLengthParser.ReadString(span, 251, 5);
            ChokyosiRyakusyo = FixedLengthParser.ReadString(span, 256, 8);
            var list_HatuKiJyo_Hatukijyoid_Year = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuKiJyo_Hatukijyoid_Year.Add(FixedLengthParser.ReadString(span, 264 + (i * 67), 4));
            }
            HatuKiJyo_Hatukijyoid_Year = JsonSerializer.Serialize(list_HatuKiJyo_Hatukijyoid_Year);
            var list_HatuKiJyo_Hatukijyoid_MonthDay = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuKiJyo_Hatukijyoid_MonthDay.Add(FixedLengthParser.ReadString(span, 268 + (i * 67), 4));
            }
            HatuKiJyo_Hatukijyoid_MonthDay = JsonSerializer.Serialize(list_HatuKiJyo_Hatukijyoid_MonthDay);
            var list_HatuKiJyo_Hatukijyoid_JyoCD = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuKiJyo_Hatukijyoid_JyoCD.Add(FixedLengthParser.ReadString(span, 272 + (i * 67), 2));
            }
            HatuKiJyo_Hatukijyoid_JyoCD = JsonSerializer.Serialize(list_HatuKiJyo_Hatukijyoid_JyoCD);
            var list_HatuKiJyo_Hatukijyoid_Kaiji = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuKiJyo_Hatukijyoid_Kaiji.Add(FixedLengthParser.ReadString(span, 274 + (i * 67), 2));
            }
            HatuKiJyo_Hatukijyoid_Kaiji = JsonSerializer.Serialize(list_HatuKiJyo_Hatukijyoid_Kaiji);
            var list_HatuKiJyo_Hatukijyoid_Nichiji = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuKiJyo_Hatukijyoid_Nichiji.Add(FixedLengthParser.ReadString(span, 276 + (i * 67), 2));
            }
            HatuKiJyo_Hatukijyoid_Nichiji = JsonSerializer.Serialize(list_HatuKiJyo_Hatukijyoid_Nichiji);
            var list_HatuKiJyo_Hatukijyoid_RaceNum = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuKiJyo_Hatukijyoid_RaceNum.Add(FixedLengthParser.ReadString(span, 278 + (i * 67), 2));
            }
            HatuKiJyo_Hatukijyoid_RaceNum = JsonSerializer.Serialize(list_HatuKiJyo_Hatukijyoid_RaceNum);
            var list_HatuKiJyo_SyussoTosu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuKiJyo_SyussoTosu.Add(FixedLengthParser.ReadString(span, 280 + (i * 67), 2));
            }
            HatuKiJyo_SyussoTosu = JsonSerializer.Serialize(list_HatuKiJyo_SyussoTosu);
            var list_HatuKiJyo_KettoNum = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuKiJyo_KettoNum.Add(FixedLengthParser.ReadString(span, 282 + (i * 67), 10));
            }
            HatuKiJyo_KettoNum = JsonSerializer.Serialize(list_HatuKiJyo_KettoNum);
            var list_HatuKiJyo_Bamei = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuKiJyo_Bamei.Add(FixedLengthParser.ReadString(span, 292 + (i * 67), 36));
            }
            HatuKiJyo_Bamei = JsonSerializer.Serialize(list_HatuKiJyo_Bamei);
            var list_HatuKiJyo_KakuteiJyuni = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuKiJyo_KakuteiJyuni.Add(FixedLengthParser.ReadString(span, 328 + (i * 67), 2));
            }
            HatuKiJyo_KakuteiJyuni = JsonSerializer.Serialize(list_HatuKiJyo_KakuteiJyuni);
            var list_HatuKiJyo_IJyoCD = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuKiJyo_IJyoCD.Add(FixedLengthParser.ReadString(span, 330 + (i * 67), 1));
            }
            HatuKiJyo_IJyoCD = JsonSerializer.Serialize(list_HatuKiJyo_IJyoCD);
            var list_HatuSyori_Hatukijyoid_Year = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuSyori_Hatukijyoid_Year.Add(FixedLengthParser.ReadString(span, 398 + (i * 64), 4));
            }
            HatuSyori_Hatukijyoid_Year = JsonSerializer.Serialize(list_HatuSyori_Hatukijyoid_Year);
            var list_HatuSyori_Hatukijyoid_MonthDay = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuSyori_Hatukijyoid_MonthDay.Add(FixedLengthParser.ReadString(span, 402 + (i * 64), 4));
            }
            HatuSyori_Hatukijyoid_MonthDay = JsonSerializer.Serialize(list_HatuSyori_Hatukijyoid_MonthDay);
            var list_HatuSyori_Hatukijyoid_JyoCD = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuSyori_Hatukijyoid_JyoCD.Add(FixedLengthParser.ReadString(span, 406 + (i * 64), 2));
            }
            HatuSyori_Hatukijyoid_JyoCD = JsonSerializer.Serialize(list_HatuSyori_Hatukijyoid_JyoCD);
            var list_HatuSyori_Hatukijyoid_Kaiji = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuSyori_Hatukijyoid_Kaiji.Add(FixedLengthParser.ReadString(span, 408 + (i * 64), 2));
            }
            HatuSyori_Hatukijyoid_Kaiji = JsonSerializer.Serialize(list_HatuSyori_Hatukijyoid_Kaiji);
            var list_HatuSyori_Hatukijyoid_Nichiji = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuSyori_Hatukijyoid_Nichiji.Add(FixedLengthParser.ReadString(span, 410 + (i * 64), 2));
            }
            HatuSyori_Hatukijyoid_Nichiji = JsonSerializer.Serialize(list_HatuSyori_Hatukijyoid_Nichiji);
            var list_HatuSyori_Hatukijyoid_RaceNum = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuSyori_Hatukijyoid_RaceNum.Add(FixedLengthParser.ReadString(span, 412 + (i * 64), 2));
            }
            HatuSyori_Hatukijyoid_RaceNum = JsonSerializer.Serialize(list_HatuSyori_Hatukijyoid_RaceNum);
            var list_HatuSyori_SyussoTosu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuSyori_SyussoTosu.Add(FixedLengthParser.ReadString(span, 414 + (i * 64), 2));
            }
            HatuSyori_SyussoTosu = JsonSerializer.Serialize(list_HatuSyori_SyussoTosu);
            var list_HatuSyori_KettoNum = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuSyori_KettoNum.Add(FixedLengthParser.ReadString(span, 416 + (i * 64), 10));
            }
            HatuSyori_KettoNum = JsonSerializer.Serialize(list_HatuSyori_KettoNum);
            var list_HatuSyori_Bamei = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HatuSyori_Bamei.Add(FixedLengthParser.ReadString(span, 426 + (i * 64), 36));
            }
            HatuSyori_Bamei = JsonSerializer.Serialize(list_HatuSyori_Bamei);
            var list_SaikinJyusyo_SaikinJyusyoid_Year = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SaikinJyusyoid_Year.Add(FixedLengthParser.ReadString(span, 526 + (i * 163), 4));
            }
            SaikinJyusyo_SaikinJyusyoid_Year = JsonSerializer.Serialize(list_SaikinJyusyo_SaikinJyusyoid_Year);
            var list_SaikinJyusyo_SaikinJyusyoid_MonthDay = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SaikinJyusyoid_MonthDay.Add(FixedLengthParser.ReadString(span, 530 + (i * 163), 4));
            }
            SaikinJyusyo_SaikinJyusyoid_MonthDay = JsonSerializer.Serialize(list_SaikinJyusyo_SaikinJyusyoid_MonthDay);
            var list_SaikinJyusyo_SaikinJyusyoid_JyoCD = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SaikinJyusyoid_JyoCD.Add(FixedLengthParser.ReadString(span, 534 + (i * 163), 2));
            }
            SaikinJyusyo_SaikinJyusyoid_JyoCD = JsonSerializer.Serialize(list_SaikinJyusyo_SaikinJyusyoid_JyoCD);
            var list_SaikinJyusyo_SaikinJyusyoid_Kaiji = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SaikinJyusyoid_Kaiji.Add(FixedLengthParser.ReadString(span, 536 + (i * 163), 2));
            }
            SaikinJyusyo_SaikinJyusyoid_Kaiji = JsonSerializer.Serialize(list_SaikinJyusyo_SaikinJyusyoid_Kaiji);
            var list_SaikinJyusyo_SaikinJyusyoid_Nichiji = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SaikinJyusyoid_Nichiji.Add(FixedLengthParser.ReadString(span, 538 + (i * 163), 2));
            }
            SaikinJyusyo_SaikinJyusyoid_Nichiji = JsonSerializer.Serialize(list_SaikinJyusyo_SaikinJyusyoid_Nichiji);
            var list_SaikinJyusyo_SaikinJyusyoid_RaceNum = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SaikinJyusyoid_RaceNum.Add(FixedLengthParser.ReadString(span, 540 + (i * 163), 2));
            }
            SaikinJyusyo_SaikinJyusyoid_RaceNum = JsonSerializer.Serialize(list_SaikinJyusyo_SaikinJyusyoid_RaceNum);
            var list_SaikinJyusyo_Hondai = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_Hondai.Add(FixedLengthParser.ReadString(span, 542 + (i * 163), 60));
            }
            SaikinJyusyo_Hondai = JsonSerializer.Serialize(list_SaikinJyusyo_Hondai);
            var list_SaikinJyusyo_Ryakusyo10 = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_Ryakusyo10.Add(FixedLengthParser.ReadString(span, 602 + (i * 163), 20));
            }
            SaikinJyusyo_Ryakusyo10 = JsonSerializer.Serialize(list_SaikinJyusyo_Ryakusyo10);
            var list_SaikinJyusyo_Ryakusyo6 = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_Ryakusyo6.Add(FixedLengthParser.ReadString(span, 622 + (i * 163), 12));
            }
            SaikinJyusyo_Ryakusyo6 = JsonSerializer.Serialize(list_SaikinJyusyo_Ryakusyo6);
            var list_SaikinJyusyo_Ryakusyo3 = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_Ryakusyo3.Add(FixedLengthParser.ReadString(span, 634 + (i * 163), 6));
            }
            SaikinJyusyo_Ryakusyo3 = JsonSerializer.Serialize(list_SaikinJyusyo_Ryakusyo3);
            var list_SaikinJyusyo_GradeCD = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_GradeCD.Add(FixedLengthParser.ReadString(span, 640 + (i * 163), 1));
            }
            SaikinJyusyo_GradeCD = JsonSerializer.Serialize(list_SaikinJyusyo_GradeCD);
            var list_SaikinJyusyo_SyussoTosu = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_SyussoTosu.Add(FixedLengthParser.ReadString(span, 641 + (i * 163), 2));
            }
            SaikinJyusyo_SyussoTosu = JsonSerializer.Serialize(list_SaikinJyusyo_SyussoTosu);
            var list_SaikinJyusyo_KettoNum = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_KettoNum.Add(FixedLengthParser.ReadString(span, 643 + (i * 163), 10));
            }
            SaikinJyusyo_KettoNum = JsonSerializer.Serialize(list_SaikinJyusyo_KettoNum);
            var list_SaikinJyusyo_Bamei = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_SaikinJyusyo_Bamei.Add(FixedLengthParser.ReadString(span, 653 + (i * 163), 36));
            }
            SaikinJyusyo_Bamei = JsonSerializer.Serialize(list_SaikinJyusyo_Bamei);
            var list_HonZenRuikei_SetYear = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_SetYear.Add(FixedLengthParser.ReadString(span, 1015 + (i * 1052), 4));
            }
            HonZenRuikei_SetYear = JsonSerializer.Serialize(list_HonZenRuikei_SetYear);
            var list_HonZenRuikei_HonSyokinHeichi = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_HonSyokinHeichi.Add(FixedLengthParser.ReadString(span, 1019 + (i * 1052), 10));
            }
            HonZenRuikei_HonSyokinHeichi = JsonSerializer.Serialize(list_HonZenRuikei_HonSyokinHeichi);
            var list_HonZenRuikei_HonSyokinSyogai = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_HonSyokinSyogai.Add(FixedLengthParser.ReadString(span, 1029 + (i * 1052), 10));
            }
            HonZenRuikei_HonSyokinSyogai = JsonSerializer.Serialize(list_HonZenRuikei_HonSyokinSyogai);
            var list_HonZenRuikei_FukaSyokinHeichi = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_FukaSyokinHeichi.Add(FixedLengthParser.ReadString(span, 1039 + (i * 1052), 10));
            }
            HonZenRuikei_FukaSyokinHeichi = JsonSerializer.Serialize(list_HonZenRuikei_FukaSyokinHeichi);
            var list_HonZenRuikei_FukaSyokinSyogai = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_FukaSyokinSyogai.Add(FixedLengthParser.ReadString(span, 1049 + (i * 1052), 10));
            }
            HonZenRuikei_FukaSyokinSyogai = JsonSerializer.Serialize(list_HonZenRuikei_FukaSyokinSyogai);
            var list_HonZenRuikei_ChakuKaisuHeichi_ChakuKaisu = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_ChakuKaisuHeichi_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1059 + (i * 1052), 6));
            }
            HonZenRuikei_ChakuKaisuHeichi_ChakuKaisu = JsonSerializer.Serialize(list_HonZenRuikei_ChakuKaisuHeichi_ChakuKaisu);
            var list_HonZenRuikei_ChakuKaisuSyogai_ChakuKaisu = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_ChakuKaisuSyogai_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1095 + (i * 1052), 6));
            }
            HonZenRuikei_ChakuKaisuSyogai_ChakuKaisu = JsonSerializer.Serialize(list_HonZenRuikei_ChakuKaisuSyogai_ChakuKaisu);
            var list_HonZenRuikei_ChakuKaisuJyo_ChakuKaisu = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_ChakuKaisuJyo_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1131 + (i * 1052), 6));
            }
            HonZenRuikei_ChakuKaisuJyo_ChakuKaisu = JsonSerializer.Serialize(list_HonZenRuikei_ChakuKaisuJyo_ChakuKaisu);
            var list_HonZenRuikei_ChakuKaisuKyori_ChakuKaisu = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_HonZenRuikei_ChakuKaisuKyori_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1851 + (i * 1052), 6));
            }
            HonZenRuikei_ChakuKaisuKyori_ChakuKaisu = JsonSerializer.Serialize(list_HonZenRuikei_ChakuKaisuKyori_ChakuKaisu);
            crlf = FixedLengthParser.ReadString(span, 4171, 2);
        }
    }
}
