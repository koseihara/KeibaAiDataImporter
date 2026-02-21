using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_H1_HYOSU_ZENKAKE — Auto-generated entity
    /// </summary>
    public class H1Entity : JvEntity
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
        public string TorokuTosu { get; private set; } = string.Empty;
        public string SyussoTosu { get; private set; } = string.Empty;
        public string HatubaiFlag { get; private set; } = string.Empty;
        public string FukuChakuBaraiKey { get; private set; } = string.Empty;
        public string HenkanUma { get; private set; } = string.Empty;
        public string HenkanWaku { get; private set; } = string.Empty;
        public string HenkanDoWaku { get; private set; } = string.Empty;
        public string HyoTansyo_Umaban { get; private set; } = string.Empty;
        public string HyoTansyo_Hyo { get; private set; } = string.Empty;
        public string HyoTansyo_Ninki { get; private set; } = string.Empty;
        public string HyoFukusyo_Umaban { get; private set; } = string.Empty;
        public string HyoFukusyo_Hyo { get; private set; } = string.Empty;
        public string HyoFukusyo_Ninki { get; private set; } = string.Empty;
        public string HyoWakuren_Umaban { get; private set; } = string.Empty;
        public string HyoWakuren_Hyo { get; private set; } = string.Empty;
        public string HyoWakuren_Ninki { get; private set; } = string.Empty;
        public string HyoUmaren_Kumi { get; private set; } = string.Empty;
        public string HyoUmaren_Hyo { get; private set; } = string.Empty;
        public string HyoUmaren_Ninki { get; private set; } = string.Empty;
        public string HyoWide_Kumi { get; private set; } = string.Empty;
        public string HyoWide_Hyo { get; private set; } = string.Empty;
        public string HyoWide_Ninki { get; private set; } = string.Empty;
        public string HyoUmatan_Kumi { get; private set; } = string.Empty;
        public string HyoUmatan_Hyo { get; private set; } = string.Empty;
        public string HyoUmatan_Ninki { get; private set; } = string.Empty;
        public string HyoSanrenpuku_Kumi { get; private set; } = string.Empty;
        public string HyoSanrenpuku_Hyo { get; private set; } = string.Empty;
        public string HyoSanrenpuku_Ninki { get; private set; } = string.Empty;
        public string HyoTotal { get; private set; } = string.Empty;
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
            TorokuTosu = FixedLengthParser.ReadString(span, 27, 2);
            SyussoTosu = FixedLengthParser.ReadString(span, 29, 2);
            var list_HatubaiFlag = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                list_HatubaiFlag.Add(FixedLengthParser.ReadString(span, 31 + (i * 1), 1));
            }
            HatubaiFlag = JsonSerializer.Serialize(list_HatubaiFlag);
            FukuChakuBaraiKey = FixedLengthParser.ReadString(span, 38, 1);
            var list_HenkanUma = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_HenkanUma.Add(FixedLengthParser.ReadString(span, 39 + (i * 1), 1));
            }
            HenkanUma = JsonSerializer.Serialize(list_HenkanUma);
            var list_HenkanWaku = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                list_HenkanWaku.Add(FixedLengthParser.ReadString(span, 67 + (i * 1), 1));
            }
            HenkanWaku = JsonSerializer.Serialize(list_HenkanWaku);
            var list_HenkanDoWaku = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                list_HenkanDoWaku.Add(FixedLengthParser.ReadString(span, 75 + (i * 1), 1));
            }
            HenkanDoWaku = JsonSerializer.Serialize(list_HenkanDoWaku);
            var list_HyoTansyo_Umaban = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_HyoTansyo_Umaban.Add(FixedLengthParser.ReadString(span, 83 + (i * 15), 2));
            }
            HyoTansyo_Umaban = JsonSerializer.Serialize(list_HyoTansyo_Umaban);
            var list_HyoTansyo_Hyo = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_HyoTansyo_Hyo.Add(FixedLengthParser.ReadString(span, 85 + (i * 15), 11));
            }
            HyoTansyo_Hyo = JsonSerializer.Serialize(list_HyoTansyo_Hyo);
            var list_HyoTansyo_Ninki = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_HyoTansyo_Ninki.Add(FixedLengthParser.ReadString(span, 96 + (i * 15), 2));
            }
            HyoTansyo_Ninki = JsonSerializer.Serialize(list_HyoTansyo_Ninki);
            var list_HyoFukusyo_Umaban = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_HyoFukusyo_Umaban.Add(FixedLengthParser.ReadString(span, 503 + (i * 15), 2));
            }
            HyoFukusyo_Umaban = JsonSerializer.Serialize(list_HyoFukusyo_Umaban);
            var list_HyoFukusyo_Hyo = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_HyoFukusyo_Hyo.Add(FixedLengthParser.ReadString(span, 505 + (i * 15), 11));
            }
            HyoFukusyo_Hyo = JsonSerializer.Serialize(list_HyoFukusyo_Hyo);
            var list_HyoFukusyo_Ninki = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_HyoFukusyo_Ninki.Add(FixedLengthParser.ReadString(span, 516 + (i * 15), 2));
            }
            HyoFukusyo_Ninki = JsonSerializer.Serialize(list_HyoFukusyo_Ninki);
            var list_HyoWakuren_Umaban = new List<string>();
            for (int i = 0; i < 36; i++)
            {
                list_HyoWakuren_Umaban.Add(FixedLengthParser.ReadString(span, 923 + (i * 15), 2));
            }
            HyoWakuren_Umaban = JsonSerializer.Serialize(list_HyoWakuren_Umaban);
            var list_HyoWakuren_Hyo = new List<string>();
            for (int i = 0; i < 36; i++)
            {
                list_HyoWakuren_Hyo.Add(FixedLengthParser.ReadString(span, 925 + (i * 15), 11));
            }
            HyoWakuren_Hyo = JsonSerializer.Serialize(list_HyoWakuren_Hyo);
            var list_HyoWakuren_Ninki = new List<string>();
            for (int i = 0; i < 36; i++)
            {
                list_HyoWakuren_Ninki.Add(FixedLengthParser.ReadString(span, 936 + (i * 15), 2));
            }
            HyoWakuren_Ninki = JsonSerializer.Serialize(list_HyoWakuren_Ninki);
            var list_HyoUmaren_Kumi = new List<string>();
            for (int i = 0; i < 153; i++)
            {
                list_HyoUmaren_Kumi.Add(FixedLengthParser.ReadString(span, 1463 + (i * 18), 4));
            }
            HyoUmaren_Kumi = JsonSerializer.Serialize(list_HyoUmaren_Kumi);
            var list_HyoUmaren_Hyo = new List<string>();
            for (int i = 0; i < 153; i++)
            {
                list_HyoUmaren_Hyo.Add(FixedLengthParser.ReadString(span, 1467 + (i * 18), 11));
            }
            HyoUmaren_Hyo = JsonSerializer.Serialize(list_HyoUmaren_Hyo);
            var list_HyoUmaren_Ninki = new List<string>();
            for (int i = 0; i < 153; i++)
            {
                list_HyoUmaren_Ninki.Add(FixedLengthParser.ReadString(span, 1478 + (i * 18), 3));
            }
            HyoUmaren_Ninki = JsonSerializer.Serialize(list_HyoUmaren_Ninki);
            var list_HyoWide_Kumi = new List<string>();
            for (int i = 0; i < 153; i++)
            {
                list_HyoWide_Kumi.Add(FixedLengthParser.ReadString(span, 4217 + (i * 18), 4));
            }
            HyoWide_Kumi = JsonSerializer.Serialize(list_HyoWide_Kumi);
            var list_HyoWide_Hyo = new List<string>();
            for (int i = 0; i < 153; i++)
            {
                list_HyoWide_Hyo.Add(FixedLengthParser.ReadString(span, 4221 + (i * 18), 11));
            }
            HyoWide_Hyo = JsonSerializer.Serialize(list_HyoWide_Hyo);
            var list_HyoWide_Ninki = new List<string>();
            for (int i = 0; i < 153; i++)
            {
                list_HyoWide_Ninki.Add(FixedLengthParser.ReadString(span, 4232 + (i * 18), 3));
            }
            HyoWide_Ninki = JsonSerializer.Serialize(list_HyoWide_Ninki);
            var list_HyoUmatan_Kumi = new List<string>();
            for (int i = 0; i < 306; i++)
            {
                list_HyoUmatan_Kumi.Add(FixedLengthParser.ReadString(span, 6971 + (i * 18), 4));
            }
            HyoUmatan_Kumi = JsonSerializer.Serialize(list_HyoUmatan_Kumi);
            var list_HyoUmatan_Hyo = new List<string>();
            for (int i = 0; i < 306; i++)
            {
                list_HyoUmatan_Hyo.Add(FixedLengthParser.ReadString(span, 6975 + (i * 18), 11));
            }
            HyoUmatan_Hyo = JsonSerializer.Serialize(list_HyoUmatan_Hyo);
            var list_HyoUmatan_Ninki = new List<string>();
            for (int i = 0; i < 306; i++)
            {
                list_HyoUmatan_Ninki.Add(FixedLengthParser.ReadString(span, 6986 + (i * 18), 3));
            }
            HyoUmatan_Ninki = JsonSerializer.Serialize(list_HyoUmatan_Ninki);
            var list_HyoSanrenpuku_Kumi = new List<string>();
            for (int i = 0; i < 816; i++)
            {
                list_HyoSanrenpuku_Kumi.Add(FixedLengthParser.ReadString(span, 12479 + (i * 20), 6));
            }
            HyoSanrenpuku_Kumi = JsonSerializer.Serialize(list_HyoSanrenpuku_Kumi);
            var list_HyoSanrenpuku_Hyo = new List<string>();
            for (int i = 0; i < 816; i++)
            {
                list_HyoSanrenpuku_Hyo.Add(FixedLengthParser.ReadString(span, 12485 + (i * 20), 11));
            }
            HyoSanrenpuku_Hyo = JsonSerializer.Serialize(list_HyoSanrenpuku_Hyo);
            var list_HyoSanrenpuku_Ninki = new List<string>();
            for (int i = 0; i < 816; i++)
            {
                list_HyoSanrenpuku_Ninki.Add(FixedLengthParser.ReadString(span, 12496 + (i * 20), 3));
            }
            HyoSanrenpuku_Ninki = JsonSerializer.Serialize(list_HyoSanrenpuku_Ninki);
            var list_HyoTotal = new List<string>();
            for (int i = 0; i < 14; i++)
            {
                list_HyoTotal.Add(FixedLengthParser.ReadString(span, 28799 + (i * 11), 11));
            }
            HyoTotal = JsonSerializer.Serialize(list_HyoTotal);
            crlf = FixedLengthParser.ReadString(span, 28953, 2);
        }
    }
}
