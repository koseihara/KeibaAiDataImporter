using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_UM_UMA — Auto-generated entity
    /// </summary>
    public class UMEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string KettoNum { get; private set; } = string.Empty;
        public string DelKubun { get; private set; } = string.Empty;
        public string RegDate_Year { get; private set; } = string.Empty;
        public string RegDate_Month { get; private set; } = string.Empty;
        public string RegDate_Day { get; private set; } = string.Empty;
        public string DelDate_Year { get; private set; } = string.Empty;
        public string DelDate_Month { get; private set; } = string.Empty;
        public string DelDate_Day { get; private set; } = string.Empty;
        public string BirthDate_Year { get; private set; } = string.Empty;
        public string BirthDate_Month { get; private set; } = string.Empty;
        public string BirthDate_Day { get; private set; } = string.Empty;
        public string Bamei { get; private set; } = string.Empty;
        public string BameiKana { get; private set; } = string.Empty;
        public string BameiEng { get; private set; } = string.Empty;
        public string ZaikyuFlag { get; private set; } = string.Empty;
        public string Reserved { get; private set; } = string.Empty;
        public string UmaKigoCD { get; private set; } = string.Empty;
        public string SexCD { get; private set; } = string.Empty;
        public string HinsyuCD { get; private set; } = string.Empty;
        public string KeiroCD { get; private set; } = string.Empty;
        public string Ketto3Info_HansyokuNum { get; private set; } = string.Empty;
        public string Ketto3Info_Bamei { get; private set; } = string.Empty;
        public string TozaiCD { get; private set; } = string.Empty;
        public string ChokyosiCode { get; private set; } = string.Empty;
        public string ChokyosiRyakusyo { get; private set; } = string.Empty;
        public string Syotai { get; private set; } = string.Empty;
        public string BreederCode { get; private set; } = string.Empty;
        public string BreederName { get; private set; } = string.Empty;
        public string SanchiName { get; private set; } = string.Empty;
        public string BanusiCode { get; private set; } = string.Empty;
        public string BanusiName { get; private set; } = string.Empty;
        public string RuikeiHonsyoHeiti { get; private set; } = string.Empty;
        public string RuikeiHonsyoSyogai { get; private set; } = string.Empty;
        public string RuikeiFukaHeichi { get; private set; } = string.Empty;
        public string RuikeiFukaSyogai { get; private set; } = string.Empty;
        public string RuikeiSyutokuHeichi { get; private set; } = string.Empty;
        public string RuikeiSyutokuSyogai { get; private set; } = string.Empty;
        public string ChakuSogo_ChakuKaisu { get; private set; } = string.Empty;
        public string ChakuChuo_ChakuKaisu { get; private set; } = string.Empty;
        public string ChakuKaisuBa_ChakuKaisu { get; private set; } = string.Empty;
        public string ChakuKaisuJyotai_ChakuKaisu { get; private set; } = string.Empty;
        public string ChakuKaisuKyori_ChakuKaisu { get; private set; } = string.Empty;
        public string Kyakusitu { get; private set; } = string.Empty;
        public string RaceCount { get; private set; } = string.Empty;
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
            KettoNum = FixedLengthParser.ReadString(span, 11, 10);
            DelKubun = FixedLengthParser.ReadString(span, 21, 1);
            RegDate_Year = FixedLengthParser.ReadString(span, 22, 4);
            RegDate_Month = FixedLengthParser.ReadString(span, 26, 2);
            RegDate_Day = FixedLengthParser.ReadString(span, 28, 2);
            DelDate_Year = FixedLengthParser.ReadString(span, 30, 4);
            DelDate_Month = FixedLengthParser.ReadString(span, 34, 2);
            DelDate_Day = FixedLengthParser.ReadString(span, 36, 2);
            BirthDate_Year = FixedLengthParser.ReadString(span, 38, 4);
            BirthDate_Month = FixedLengthParser.ReadString(span, 42, 2);
            BirthDate_Day = FixedLengthParser.ReadString(span, 44, 2);
            Bamei = FixedLengthParser.ReadString(span, 46, 36);
            BameiKana = FixedLengthParser.ReadString(span, 82, 36);
            BameiEng = FixedLengthParser.ReadString(span, 118, 60);
            ZaikyuFlag = FixedLengthParser.ReadString(span, 178, 1);
            Reserved = FixedLengthParser.ReadString(span, 179, 19);
            UmaKigoCD = FixedLengthParser.ReadString(span, 198, 2);
            SexCD = FixedLengthParser.ReadString(span, 200, 1);
            HinsyuCD = FixedLengthParser.ReadString(span, 201, 1);
            KeiroCD = FixedLengthParser.ReadString(span, 202, 2);
            var list_Ketto3Info_HansyokuNum = new List<string>();
            for (int i = 0; i < 14; i++)
            {
                list_Ketto3Info_HansyokuNum.Add(FixedLengthParser.ReadString(span, 204 + (i * 46), 10));
            }
            Ketto3Info_HansyokuNum = JsonSerializer.Serialize(list_Ketto3Info_HansyokuNum);
            var list_Ketto3Info_Bamei = new List<string>();
            for (int i = 0; i < 14; i++)
            {
                list_Ketto3Info_Bamei.Add(FixedLengthParser.ReadString(span, 214 + (i * 46), 36));
            }
            Ketto3Info_Bamei = JsonSerializer.Serialize(list_Ketto3Info_Bamei);
            TozaiCD = FixedLengthParser.ReadString(span, 848, 1);
            ChokyosiCode = FixedLengthParser.ReadString(span, 849, 5);
            ChokyosiRyakusyo = FixedLengthParser.ReadString(span, 854, 8);
            Syotai = FixedLengthParser.ReadString(span, 862, 20);
            BreederCode = FixedLengthParser.ReadString(span, 882, 8);
            BreederName = FixedLengthParser.ReadString(span, 890, 72);
            SanchiName = FixedLengthParser.ReadString(span, 962, 20);
            BanusiCode = FixedLengthParser.ReadString(span, 982, 6);
            BanusiName = FixedLengthParser.ReadString(span, 988, 64);
            RuikeiHonsyoHeiti = FixedLengthParser.ReadString(span, 1052, 9);
            RuikeiHonsyoSyogai = FixedLengthParser.ReadString(span, 1061, 9);
            RuikeiFukaHeichi = FixedLengthParser.ReadString(span, 1070, 9);
            RuikeiFukaSyogai = FixedLengthParser.ReadString(span, 1079, 9);
            RuikeiSyutokuHeichi = FixedLengthParser.ReadString(span, 1088, 9);
            RuikeiSyutokuSyogai = FixedLengthParser.ReadString(span, 1097, 9);
            var list_ChakuSogo_ChakuKaisu = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                list_ChakuSogo_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1106 + (i * 3), 3));
            }
            ChakuSogo_ChakuKaisu = JsonSerializer.Serialize(list_ChakuSogo_ChakuKaisu);
            var list_ChakuChuo_ChakuKaisu = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                list_ChakuChuo_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1124 + (i * 3), 3));
            }
            ChakuChuo_ChakuKaisu = JsonSerializer.Serialize(list_ChakuChuo_ChakuKaisu);
            var list_ChakuKaisuBa_ChakuKaisu = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                list_ChakuKaisuBa_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1142 + (i * 18), 3));
            }
            ChakuKaisuBa_ChakuKaisu = JsonSerializer.Serialize(list_ChakuKaisuBa_ChakuKaisu);
            var list_ChakuKaisuJyotai_ChakuKaisu = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                list_ChakuKaisuJyotai_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1268 + (i * 18), 3));
            }
            ChakuKaisuJyotai_ChakuKaisu = JsonSerializer.Serialize(list_ChakuKaisuJyotai_ChakuKaisu);
            var list_ChakuKaisuKyori_ChakuKaisu = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                list_ChakuKaisuKyori_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 1484 + (i * 18), 3));
            }
            ChakuKaisuKyori_ChakuKaisu = JsonSerializer.Serialize(list_ChakuKaisuKyori_ChakuKaisu);
            var list_Kyakusitu = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                list_Kyakusitu.Add(FixedLengthParser.ReadString(span, 1592 + (i * 3), 3));
            }
            Kyakusitu = JsonSerializer.Serialize(list_Kyakusitu);
            RaceCount = FixedLengthParser.ReadString(span, 1604, 3);
            crlf = FixedLengthParser.ReadString(span, 1607, 2);
        }
    }
}
