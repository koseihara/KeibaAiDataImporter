using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_CK_CHAKU — Auto-generated entity
    /// </summary>
    public class CKEntity : JvEntity
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
        public string UmaChaku_KettoNum { get; private set; } = string.Empty;
        public string UmaChaku_Bamei { get; private set; } = string.Empty;
        public string UmaChaku_RuikeiHonsyoHeiti { get; private set; } = string.Empty;
        public string UmaChaku_RuikeiHonsyoSyogai { get; private set; } = string.Empty;
        public string UmaChaku_RuikeiFukaHeichi { get; private set; } = string.Empty;
        public string UmaChaku_RuikeiFukaSyogai { get; private set; } = string.Empty;
        public string UmaChaku_RuikeiSyutokuHeichi { get; private set; } = string.Empty;
        public string UmaChaku_RuikeiSyutokuSyogai { get; private set; } = string.Empty;
        public string UmaChaku_ChakuSogo_ChakuKaisu { get; private set; } = string.Empty;
        public string UmaChaku_ChakuChuo_ChakuKaisu { get; private set; } = string.Empty;
        public string UmaChaku_ChakuKaisuBa_ChakuKaisu { get; private set; } = string.Empty;
        public string UmaChaku_ChakuKaisuJyotai_ChakuKaisu { get; private set; } = string.Empty;
        public string UmaChaku_ChakuKaisuSibaKyori_ChakuKaisu { get; private set; } = string.Empty;
        public string UmaChaku_ChakuKaisuDirtKyori_ChakuKaisu { get; private set; } = string.Empty;
        public string UmaChaku_ChakuKaisuJyoSiba_ChakuKaisu { get; private set; } = string.Empty;
        public string UmaChaku_ChakuKaisuJyoDirt_ChakuKaisu { get; private set; } = string.Empty;
        public string UmaChaku_ChakuKaisuJyoSyogai_ChakuKaisu { get; private set; } = string.Empty;
        public string UmaChaku_Kyakusitu { get; private set; } = string.Empty;
        public string UmaChaku_RaceCount { get; private set; } = string.Empty;
        public string KisyuChaku_KisyuCode { get; private set; } = string.Empty;
        public string KisyuChaku_KisyuName { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_SetYear { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_HonSyokinHeichi { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_HonSyokinSyogai { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_FukaSyokinHeichi { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_FukaSyokinSyogai { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_ChakuKaisuSiba_ChakuKaisu { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_ChakuKaisuDirt_ChakuKaisu { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_ChakuKaisuSyogai_ChakuKaisu { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_ChakuKaisuSibaKyori_ChakuKaisu { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_ChakuKaisuDirtKyori_ChakuKaisu { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_ChakuKaisuJyoSiba_ChakuKaisu { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_ChakuKaisuJyoDirt_ChakuKaisu { get; private set; } = string.Empty;
        public string KisyuChaku_HonRuikei_ChakuKaisuJyoSyogai_ChakuKaisu { get; private set; } = string.Empty;
        public string ChokyoChaku_ChokyosiCode { get; private set; } = string.Empty;
        public string ChokyoChaku_ChokyosiName { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_SetYear { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_HonSyokinHeichi { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_HonSyokinSyogai { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_FukaSyokinHeichi { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_FukaSyokinSyogai { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_ChakuKaisuSiba_ChakuKaisu { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_ChakuKaisuDirt_ChakuKaisu { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_ChakuKaisuSyogai_ChakuKaisu { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_ChakuKaisuSibaKyori_ChakuKaisu { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_ChakuKaisuDirtKyori_ChakuKaisu { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_ChakuKaisuJyoSiba_ChakuKaisu { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_ChakuKaisuJyoDirt_ChakuKaisu { get; private set; } = string.Empty;
        public string ChokyoChaku_HonRuikei_ChakuKaisuJyoSyogai_ChakuKaisu { get; private set; } = string.Empty;
        public string BanusiChaku_BanusiCode { get; private set; } = string.Empty;
        public string BanusiChaku_BanusiName_Co { get; private set; } = string.Empty;
        public string BanusiChaku_BanusiName { get; private set; } = string.Empty;
        public string BanusiChaku_HonRuikei_SetYear { get; private set; } = string.Empty;
        public string BanusiChaku_HonRuikei_HonSyokinTotal { get; private set; } = string.Empty;
        public string BanusiChaku_HonRuikei_FukaSyokin { get; private set; } = string.Empty;
        public string BanusiChaku_HonRuikei_ChakuKaisu { get; private set; } = string.Empty;
        public string BreederChaku_BreederCode { get; private set; } = string.Empty;
        public string BreederChaku_BreederName_Co { get; private set; } = string.Empty;
        public string BreederChaku_BreederName { get; private set; } = string.Empty;
        public string BreederChaku_HonRuikei_SetYear { get; private set; } = string.Empty;
        public string BreederChaku_HonRuikei_HonSyokinTotal { get; private set; } = string.Empty;
        public string BreederChaku_HonRuikei_FukaSyokin { get; private set; } = string.Empty;
        public string BreederChaku_HonRuikei_ChakuKaisu { get; private set; } = string.Empty;
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
            UmaChaku_KettoNum = FixedLengthParser.ReadString(span, 27, 10);
            UmaChaku_Bamei = FixedLengthParser.ReadString(span, 37, 36);
            UmaChaku_RuikeiHonsyoHeiti = FixedLengthParser.ReadString(span, 73, 9);
            UmaChaku_RuikeiHonsyoSyogai = FixedLengthParser.ReadString(span, 82, 9);
            UmaChaku_RuikeiFukaHeichi = FixedLengthParser.ReadString(span, 91, 9);
            UmaChaku_RuikeiFukaSyogai = FixedLengthParser.ReadString(span, 100, 9);
            UmaChaku_RuikeiSyutokuHeichi = FixedLengthParser.ReadString(span, 109, 9);
            UmaChaku_RuikeiSyutokuSyogai = FixedLengthParser.ReadString(span, 118, 9);
            var list_UmaChaku_ChakuSogo_ChakuKaisu = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                list_UmaChaku_ChakuSogo_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 127 + (i * 3), 3));
            }
            UmaChaku_ChakuSogo_ChakuKaisu = JsonSerializer.Serialize(list_UmaChaku_ChakuSogo_ChakuKaisu);
            var list_UmaChaku_ChakuChuo_ChakuKaisu = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                list_UmaChaku_ChakuChuo_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 145 + (i * 3), 3));
            }
            UmaChaku_ChakuChuo_ChakuKaisu = JsonSerializer.Serialize(list_UmaChaku_ChakuChuo_ChakuKaisu);
            var list_UmaChaku_ChakuKaisuBa_ChakuKaisu = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                list_UmaChaku_ChakuKaisuBa_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 163 + (i * 18), 3));
            }
            UmaChaku_ChakuKaisuBa_ChakuKaisu = JsonSerializer.Serialize(list_UmaChaku_ChakuKaisuBa_ChakuKaisu);
            var list_UmaChaku_ChakuKaisuJyotai_ChakuKaisu = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                list_UmaChaku_ChakuKaisuJyotai_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 289 + (i * 18), 3));
            }
            UmaChaku_ChakuKaisuJyotai_ChakuKaisu = JsonSerializer.Serialize(list_UmaChaku_ChakuKaisuJyotai_ChakuKaisu);
            var list_UmaChaku_ChakuKaisuSibaKyori_ChakuKaisu = new List<string>();
            for (int i = 0; i < 9; i++)
            {
                list_UmaChaku_ChakuKaisuSibaKyori_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 505 + (i * 18), 3));
            }
            UmaChaku_ChakuKaisuSibaKyori_ChakuKaisu = JsonSerializer.Serialize(list_UmaChaku_ChakuKaisuSibaKyori_ChakuKaisu);
            var list_UmaChaku_ChakuKaisuDirtKyori_ChakuKaisu = new List<string>();
            for (int i = 0; i < 9; i++)
            {
                list_UmaChaku_ChakuKaisuDirtKyori_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 667 + (i * 18), 3));
            }
            UmaChaku_ChakuKaisuDirtKyori_ChakuKaisu = JsonSerializer.Serialize(list_UmaChaku_ChakuKaisuDirtKyori_ChakuKaisu);
            var list_UmaChaku_ChakuKaisuJyoSiba_ChakuKaisu = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                list_UmaChaku_ChakuKaisuJyoSiba_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 829 + (i * 18), 3));
            }
            UmaChaku_ChakuKaisuJyoSiba_ChakuKaisu = JsonSerializer.Serialize(list_UmaChaku_ChakuKaisuJyoSiba_ChakuKaisu);
            var list_UmaChaku_ChakuKaisuJyoDirt_ChakuKaisu = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                list_UmaChaku_ChakuKaisuJyoDirt_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1009 + (i * 18), 3));
            }
            UmaChaku_ChakuKaisuJyoDirt_ChakuKaisu = JsonSerializer.Serialize(list_UmaChaku_ChakuKaisuJyoDirt_ChakuKaisu);
            var list_UmaChaku_ChakuKaisuJyoSyogai_ChakuKaisu = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                list_UmaChaku_ChakuKaisuJyoSyogai_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1189 + (i * 18), 3));
            }
            UmaChaku_ChakuKaisuJyoSyogai_ChakuKaisu = JsonSerializer.Serialize(list_UmaChaku_ChakuKaisuJyoSyogai_ChakuKaisu);
            var list_UmaChaku_Kyakusitu = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                list_UmaChaku_Kyakusitu.Add(FixedLengthParser.ReadString(span, 1369 + (i * 3), 3));
            }
            UmaChaku_Kyakusitu = JsonSerializer.Serialize(list_UmaChaku_Kyakusitu);
            UmaChaku_RaceCount = FixedLengthParser.ReadString(span, 1381, 3);
            KisyuChaku_KisyuCode = FixedLengthParser.ReadString(span, 1384, 5);
            KisyuChaku_KisyuName = FixedLengthParser.ReadString(span, 1389, 34);
            var list_KisyuChaku_HonRuikei_SetYear = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_SetYear.Add(FixedLengthParser.ReadString(span, 1423 + (i * 1220), 4));
            }
            KisyuChaku_HonRuikei_SetYear = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_SetYear);
            var list_KisyuChaku_HonRuikei_HonSyokinHeichi = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_HonSyokinHeichi.Add(FixedLengthParser.ReadString(span, 1427 + (i * 1220), 10));
            }
            KisyuChaku_HonRuikei_HonSyokinHeichi = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_HonSyokinHeichi);
            var list_KisyuChaku_HonRuikei_HonSyokinSyogai = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_HonSyokinSyogai.Add(FixedLengthParser.ReadString(span, 1437 + (i * 1220), 10));
            }
            KisyuChaku_HonRuikei_HonSyokinSyogai = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_HonSyokinSyogai);
            var list_KisyuChaku_HonRuikei_FukaSyokinHeichi = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_FukaSyokinHeichi.Add(FixedLengthParser.ReadString(span, 1447 + (i * 1220), 10));
            }
            KisyuChaku_HonRuikei_FukaSyokinHeichi = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_FukaSyokinHeichi);
            var list_KisyuChaku_HonRuikei_FukaSyokinSyogai = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_FukaSyokinSyogai.Add(FixedLengthParser.ReadString(span, 1457 + (i * 1220), 10));
            }
            KisyuChaku_HonRuikei_FukaSyokinSyogai = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_FukaSyokinSyogai);
            var list_KisyuChaku_HonRuikei_ChakuKaisuSiba_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_ChakuKaisuSiba_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1467 + (i * 1220), 5));
            }
            KisyuChaku_HonRuikei_ChakuKaisuSiba_ChakuKaisu = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_ChakuKaisuSiba_ChakuKaisu);
            var list_KisyuChaku_HonRuikei_ChakuKaisuDirt_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_ChakuKaisuDirt_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1497 + (i * 1220), 5));
            }
            KisyuChaku_HonRuikei_ChakuKaisuDirt_ChakuKaisu = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_ChakuKaisuDirt_ChakuKaisu);
            var list_KisyuChaku_HonRuikei_ChakuKaisuSyogai_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_ChakuKaisuSyogai_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1527 + (i * 1220), 4));
            }
            KisyuChaku_HonRuikei_ChakuKaisuSyogai_ChakuKaisu = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_ChakuKaisuSyogai_ChakuKaisu);
            var list_KisyuChaku_HonRuikei_ChakuKaisuSibaKyori_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_ChakuKaisuSibaKyori_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1551 + (i * 1220), 4));
            }
            KisyuChaku_HonRuikei_ChakuKaisuSibaKyori_ChakuKaisu = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_ChakuKaisuSibaKyori_ChakuKaisu);
            var list_KisyuChaku_HonRuikei_ChakuKaisuDirtKyori_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_ChakuKaisuDirtKyori_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1767 + (i * 1220), 4));
            }
            KisyuChaku_HonRuikei_ChakuKaisuDirtKyori_ChakuKaisu = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_ChakuKaisuDirtKyori_ChakuKaisu);
            var list_KisyuChaku_HonRuikei_ChakuKaisuJyoSiba_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_ChakuKaisuJyoSiba_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1983 + (i * 1220), 4));
            }
            KisyuChaku_HonRuikei_ChakuKaisuJyoSiba_ChakuKaisu = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_ChakuKaisuJyoSiba_ChakuKaisu);
            var list_KisyuChaku_HonRuikei_ChakuKaisuJyoDirt_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_ChakuKaisuJyoDirt_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 2223 + (i * 1220), 4));
            }
            KisyuChaku_HonRuikei_ChakuKaisuJyoDirt_ChakuKaisu = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_ChakuKaisuJyoDirt_ChakuKaisu);
            var list_KisyuChaku_HonRuikei_ChakuKaisuJyoSyogai_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_KisyuChaku_HonRuikei_ChakuKaisuJyoSyogai_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 2463 + (i * 1220), 3));
            }
            KisyuChaku_HonRuikei_ChakuKaisuJyoSyogai_ChakuKaisu = JsonSerializer.Serialize(list_KisyuChaku_HonRuikei_ChakuKaisuJyoSyogai_ChakuKaisu);
            ChokyoChaku_ChokyosiCode = FixedLengthParser.ReadString(span, 3863, 5);
            ChokyoChaku_ChokyosiName = FixedLengthParser.ReadString(span, 3868, 34);
            var list_ChokyoChaku_HonRuikei_SetYear = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_SetYear.Add(FixedLengthParser.ReadString(span, 3902 + (i * 1220), 4));
            }
            ChokyoChaku_HonRuikei_SetYear = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_SetYear);
            var list_ChokyoChaku_HonRuikei_HonSyokinHeichi = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_HonSyokinHeichi.Add(FixedLengthParser.ReadString(span, 3906 + (i * 1220), 10));
            }
            ChokyoChaku_HonRuikei_HonSyokinHeichi = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_HonSyokinHeichi);
            var list_ChokyoChaku_HonRuikei_HonSyokinSyogai = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_HonSyokinSyogai.Add(FixedLengthParser.ReadString(span, 3916 + (i * 1220), 10));
            }
            ChokyoChaku_HonRuikei_HonSyokinSyogai = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_HonSyokinSyogai);
            var list_ChokyoChaku_HonRuikei_FukaSyokinHeichi = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_FukaSyokinHeichi.Add(FixedLengthParser.ReadString(span, 3926 + (i * 1220), 10));
            }
            ChokyoChaku_HonRuikei_FukaSyokinHeichi = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_FukaSyokinHeichi);
            var list_ChokyoChaku_HonRuikei_FukaSyokinSyogai = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_FukaSyokinSyogai.Add(FixedLengthParser.ReadString(span, 3936 + (i * 1220), 10));
            }
            ChokyoChaku_HonRuikei_FukaSyokinSyogai = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_FukaSyokinSyogai);
            var list_ChokyoChaku_HonRuikei_ChakuKaisuSiba_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_ChakuKaisuSiba_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 3946 + (i * 1220), 5));
            }
            ChokyoChaku_HonRuikei_ChakuKaisuSiba_ChakuKaisu = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_ChakuKaisuSiba_ChakuKaisu);
            var list_ChokyoChaku_HonRuikei_ChakuKaisuDirt_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_ChakuKaisuDirt_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 3976 + (i * 1220), 5));
            }
            ChokyoChaku_HonRuikei_ChakuKaisuDirt_ChakuKaisu = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_ChakuKaisuDirt_ChakuKaisu);
            var list_ChokyoChaku_HonRuikei_ChakuKaisuSyogai_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_ChakuKaisuSyogai_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 4006 + (i * 1220), 4));
            }
            ChokyoChaku_HonRuikei_ChakuKaisuSyogai_ChakuKaisu = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_ChakuKaisuSyogai_ChakuKaisu);
            var list_ChokyoChaku_HonRuikei_ChakuKaisuSibaKyori_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_ChakuKaisuSibaKyori_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 4030 + (i * 1220), 4));
            }
            ChokyoChaku_HonRuikei_ChakuKaisuSibaKyori_ChakuKaisu = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_ChakuKaisuSibaKyori_ChakuKaisu);
            var list_ChokyoChaku_HonRuikei_ChakuKaisuDirtKyori_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_ChakuKaisuDirtKyori_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 4246 + (i * 1220), 4));
            }
            ChokyoChaku_HonRuikei_ChakuKaisuDirtKyori_ChakuKaisu = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_ChakuKaisuDirtKyori_ChakuKaisu);
            var list_ChokyoChaku_HonRuikei_ChakuKaisuJyoSiba_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_ChakuKaisuJyoSiba_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 4462 + (i * 1220), 4));
            }
            ChokyoChaku_HonRuikei_ChakuKaisuJyoSiba_ChakuKaisu = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_ChakuKaisuJyoSiba_ChakuKaisu);
            var list_ChokyoChaku_HonRuikei_ChakuKaisuJyoDirt_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_ChakuKaisuJyoDirt_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 4702 + (i * 1220), 4));
            }
            ChokyoChaku_HonRuikei_ChakuKaisuJyoDirt_ChakuKaisu = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_ChakuKaisuJyoDirt_ChakuKaisu);
            var list_ChokyoChaku_HonRuikei_ChakuKaisuJyoSyogai_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_ChokyoChaku_HonRuikei_ChakuKaisuJyoSyogai_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 4942 + (i * 1220), 3));
            }
            ChokyoChaku_HonRuikei_ChakuKaisuJyoSyogai_ChakuKaisu = JsonSerializer.Serialize(list_ChokyoChaku_HonRuikei_ChakuKaisuJyoSyogai_ChakuKaisu);
            BanusiChaku_BanusiCode = FixedLengthParser.ReadString(span, 6342, 6);
            BanusiChaku_BanusiName_Co = FixedLengthParser.ReadString(span, 6348, 64);
            BanusiChaku_BanusiName = FixedLengthParser.ReadString(span, 6412, 64);
            var list_BanusiChaku_HonRuikei_SetYear = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_BanusiChaku_HonRuikei_SetYear.Add(FixedLengthParser.ReadString(span, 6476 + (i * 60), 4));
            }
            BanusiChaku_HonRuikei_SetYear = JsonSerializer.Serialize(list_BanusiChaku_HonRuikei_SetYear);
            var list_BanusiChaku_HonRuikei_HonSyokinTotal = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_BanusiChaku_HonRuikei_HonSyokinTotal.Add(FixedLengthParser.ReadString(span, 6480 + (i * 60), 10));
            }
            BanusiChaku_HonRuikei_HonSyokinTotal = JsonSerializer.Serialize(list_BanusiChaku_HonRuikei_HonSyokinTotal);
            var list_BanusiChaku_HonRuikei_FukaSyokin = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_BanusiChaku_HonRuikei_FukaSyokin.Add(FixedLengthParser.ReadString(span, 6490 + (i * 60), 10));
            }
            BanusiChaku_HonRuikei_FukaSyokin = JsonSerializer.Serialize(list_BanusiChaku_HonRuikei_FukaSyokin);
            var list_BanusiChaku_HonRuikei_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_BanusiChaku_HonRuikei_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 6500 + (i * 60), 6));
            }
            BanusiChaku_HonRuikei_ChakuKaisu = JsonSerializer.Serialize(list_BanusiChaku_HonRuikei_ChakuKaisu);
            BreederChaku_BreederCode = FixedLengthParser.ReadString(span, 6596, 8);
            BreederChaku_BreederName_Co = FixedLengthParser.ReadString(span, 6604, 72);
            BreederChaku_BreederName = FixedLengthParser.ReadString(span, 6676, 72);
            var list_BreederChaku_HonRuikei_SetYear = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_BreederChaku_HonRuikei_SetYear.Add(FixedLengthParser.ReadString(span, 6748 + (i * 60), 4));
            }
            BreederChaku_HonRuikei_SetYear = JsonSerializer.Serialize(list_BreederChaku_HonRuikei_SetYear);
            var list_BreederChaku_HonRuikei_HonSyokinTotal = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_BreederChaku_HonRuikei_HonSyokinTotal.Add(FixedLengthParser.ReadString(span, 6752 + (i * 60), 10));
            }
            BreederChaku_HonRuikei_HonSyokinTotal = JsonSerializer.Serialize(list_BreederChaku_HonRuikei_HonSyokinTotal);
            var list_BreederChaku_HonRuikei_FukaSyokin = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_BreederChaku_HonRuikei_FukaSyokin.Add(FixedLengthParser.ReadString(span, 6762 + (i * 60), 10));
            }
            BreederChaku_HonRuikei_FukaSyokin = JsonSerializer.Serialize(list_BreederChaku_HonRuikei_FukaSyokin);
            var list_BreederChaku_HonRuikei_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_BreederChaku_HonRuikei_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 6772 + (i * 60), 6));
            }
            BreederChaku_HonRuikei_ChakuKaisu = JsonSerializer.Serialize(list_BreederChaku_HonRuikei_ChakuKaisu);
            crlf = FixedLengthParser.ReadString(span, 6868, 2);
        }
    }
}
