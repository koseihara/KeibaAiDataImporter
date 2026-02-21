using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_HR_PAY — Auto-generated entity
    /// </summary>
    public class HREntity : JvEntity
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
        public string FuseirituFlag { get; private set; } = string.Empty;
        public string TokubaraiFlag { get; private set; } = string.Empty;
        public string HenkanFlag { get; private set; } = string.Empty;
        public string HenkanUma { get; private set; } = string.Empty;
        public string HenkanWaku { get; private set; } = string.Empty;
        public string HenkanDoWaku { get; private set; } = string.Empty;
        public string PayTansyo_Umaban { get; private set; } = string.Empty;
        public string PayTansyo_Pay { get; private set; } = string.Empty;
        public string PayTansyo_Ninki { get; private set; } = string.Empty;
        public string PayFukusyo_Umaban { get; private set; } = string.Empty;
        public string PayFukusyo_Pay { get; private set; } = string.Empty;
        public string PayFukusyo_Ninki { get; private set; } = string.Empty;
        public string PayWakuren_Umaban { get; private set; } = string.Empty;
        public string PayWakuren_Pay { get; private set; } = string.Empty;
        public string PayWakuren_Ninki { get; private set; } = string.Empty;
        public string PayUmaren_Kumi { get; private set; } = string.Empty;
        public string PayUmaren_Pay { get; private set; } = string.Empty;
        public string PayUmaren_Ninki { get; private set; } = string.Empty;
        public string PayWide_Kumi { get; private set; } = string.Empty;
        public string PayWide_Pay { get; private set; } = string.Empty;
        public string PayWide_Ninki { get; private set; } = string.Empty;
        public string PayReserved1_Kumi { get; private set; } = string.Empty;
        public string PayReserved1_Pay { get; private set; } = string.Empty;
        public string PayReserved1_Ninki { get; private set; } = string.Empty;
        public string PayUmatan_Kumi { get; private set; } = string.Empty;
        public string PayUmatan_Pay { get; private set; } = string.Empty;
        public string PayUmatan_Ninki { get; private set; } = string.Empty;
        public string PaySanrenpuku_Kumi { get; private set; } = string.Empty;
        public string PaySanrenpuku_Pay { get; private set; } = string.Empty;
        public string PaySanrenpuku_Ninki { get; private set; } = string.Empty;
        public string PaySanrentan_Kumi { get; private set; } = string.Empty;
        public string PaySanrentan_Pay { get; private set; } = string.Empty;
        public string PaySanrentan_Ninki { get; private set; } = string.Empty;
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
            var list_FuseirituFlag = new List<string>();
            for (int i = 0; i < 9; i++)
            {
                list_FuseirituFlag.Add(FixedLengthParser.ReadString(span, 31 + (i * 1), 1));
            }
            FuseirituFlag = JsonSerializer.Serialize(list_FuseirituFlag);
            var list_TokubaraiFlag = new List<string>();
            for (int i = 0; i < 9; i++)
            {
                list_TokubaraiFlag.Add(FixedLengthParser.ReadString(span, 40 + (i * 1), 1));
            }
            TokubaraiFlag = JsonSerializer.Serialize(list_TokubaraiFlag);
            var list_HenkanFlag = new List<string>();
            for (int i = 0; i < 9; i++)
            {
                list_HenkanFlag.Add(FixedLengthParser.ReadString(span, 49 + (i * 1), 1));
            }
            HenkanFlag = JsonSerializer.Serialize(list_HenkanFlag);
            var list_HenkanUma = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                list_HenkanUma.Add(FixedLengthParser.ReadString(span, 58 + (i * 1), 1));
            }
            HenkanUma = JsonSerializer.Serialize(list_HenkanUma);
            var list_HenkanWaku = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                list_HenkanWaku.Add(FixedLengthParser.ReadString(span, 86 + (i * 1), 1));
            }
            HenkanWaku = JsonSerializer.Serialize(list_HenkanWaku);
            var list_HenkanDoWaku = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                list_HenkanDoWaku.Add(FixedLengthParser.ReadString(span, 94 + (i * 1), 1));
            }
            HenkanDoWaku = JsonSerializer.Serialize(list_HenkanDoWaku);
            var list_PayTansyo_Umaban = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PayTansyo_Umaban.Add(FixedLengthParser.ReadString(span, 102 + (i * 13), 2));
            }
            PayTansyo_Umaban = JsonSerializer.Serialize(list_PayTansyo_Umaban);
            var list_PayTansyo_Pay = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PayTansyo_Pay.Add(FixedLengthParser.ReadString(span, 104 + (i * 13), 9));
            }
            PayTansyo_Pay = JsonSerializer.Serialize(list_PayTansyo_Pay);
            var list_PayTansyo_Ninki = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PayTansyo_Ninki.Add(FixedLengthParser.ReadString(span, 113 + (i * 13), 2));
            }
            PayTansyo_Ninki = JsonSerializer.Serialize(list_PayTansyo_Ninki);
            var list_PayFukusyo_Umaban = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list_PayFukusyo_Umaban.Add(FixedLengthParser.ReadString(span, 141 + (i * 13), 2));
            }
            PayFukusyo_Umaban = JsonSerializer.Serialize(list_PayFukusyo_Umaban);
            var list_PayFukusyo_Pay = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list_PayFukusyo_Pay.Add(FixedLengthParser.ReadString(span, 143 + (i * 13), 9));
            }
            PayFukusyo_Pay = JsonSerializer.Serialize(list_PayFukusyo_Pay);
            var list_PayFukusyo_Ninki = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                list_PayFukusyo_Ninki.Add(FixedLengthParser.ReadString(span, 152 + (i * 13), 2));
            }
            PayFukusyo_Ninki = JsonSerializer.Serialize(list_PayFukusyo_Ninki);
            var list_PayWakuren_Umaban = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PayWakuren_Umaban.Add(FixedLengthParser.ReadString(span, 206 + (i * 13), 2));
            }
            PayWakuren_Umaban = JsonSerializer.Serialize(list_PayWakuren_Umaban);
            var list_PayWakuren_Pay = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PayWakuren_Pay.Add(FixedLengthParser.ReadString(span, 208 + (i * 13), 9));
            }
            PayWakuren_Pay = JsonSerializer.Serialize(list_PayWakuren_Pay);
            var list_PayWakuren_Ninki = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PayWakuren_Ninki.Add(FixedLengthParser.ReadString(span, 217 + (i * 13), 2));
            }
            PayWakuren_Ninki = JsonSerializer.Serialize(list_PayWakuren_Ninki);
            var list_PayUmaren_Kumi = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PayUmaren_Kumi.Add(FixedLengthParser.ReadString(span, 245 + (i * 16), 4));
            }
            PayUmaren_Kumi = JsonSerializer.Serialize(list_PayUmaren_Kumi);
            var list_PayUmaren_Pay = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PayUmaren_Pay.Add(FixedLengthParser.ReadString(span, 249 + (i * 16), 9));
            }
            PayUmaren_Pay = JsonSerializer.Serialize(list_PayUmaren_Pay);
            var list_PayUmaren_Ninki = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PayUmaren_Ninki.Add(FixedLengthParser.ReadString(span, 258 + (i * 16), 3));
            }
            PayUmaren_Ninki = JsonSerializer.Serialize(list_PayUmaren_Ninki);
            var list_PayWide_Kumi = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                list_PayWide_Kumi.Add(FixedLengthParser.ReadString(span, 293 + (i * 16), 4));
            }
            PayWide_Kumi = JsonSerializer.Serialize(list_PayWide_Kumi);
            var list_PayWide_Pay = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                list_PayWide_Pay.Add(FixedLengthParser.ReadString(span, 297 + (i * 16), 9));
            }
            PayWide_Pay = JsonSerializer.Serialize(list_PayWide_Pay);
            var list_PayWide_Ninki = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                list_PayWide_Ninki.Add(FixedLengthParser.ReadString(span, 306 + (i * 16), 3));
            }
            PayWide_Ninki = JsonSerializer.Serialize(list_PayWide_Ninki);
            var list_PayReserved1_Kumi = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PayReserved1_Kumi.Add(FixedLengthParser.ReadString(span, 405 + (i * 16), 4));
            }
            PayReserved1_Kumi = JsonSerializer.Serialize(list_PayReserved1_Kumi);
            var list_PayReserved1_Pay = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PayReserved1_Pay.Add(FixedLengthParser.ReadString(span, 409 + (i * 16), 9));
            }
            PayReserved1_Pay = JsonSerializer.Serialize(list_PayReserved1_Pay);
            var list_PayReserved1_Ninki = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PayReserved1_Ninki.Add(FixedLengthParser.ReadString(span, 418 + (i * 16), 3));
            }
            PayReserved1_Ninki = JsonSerializer.Serialize(list_PayReserved1_Ninki);
            var list_PayUmatan_Kumi = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                list_PayUmatan_Kumi.Add(FixedLengthParser.ReadString(span, 453 + (i * 16), 4));
            }
            PayUmatan_Kumi = JsonSerializer.Serialize(list_PayUmatan_Kumi);
            var list_PayUmatan_Pay = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                list_PayUmatan_Pay.Add(FixedLengthParser.ReadString(span, 457 + (i * 16), 9));
            }
            PayUmatan_Pay = JsonSerializer.Serialize(list_PayUmatan_Pay);
            var list_PayUmatan_Ninki = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                list_PayUmatan_Ninki.Add(FixedLengthParser.ReadString(span, 466 + (i * 16), 3));
            }
            PayUmatan_Ninki = JsonSerializer.Serialize(list_PayUmatan_Ninki);
            var list_PaySanrenpuku_Kumi = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PaySanrenpuku_Kumi.Add(FixedLengthParser.ReadString(span, 549 + (i * 18), 6));
            }
            PaySanrenpuku_Kumi = JsonSerializer.Serialize(list_PaySanrenpuku_Kumi);
            var list_PaySanrenpuku_Pay = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PaySanrenpuku_Pay.Add(FixedLengthParser.ReadString(span, 555 + (i * 18), 9));
            }
            PaySanrenpuku_Pay = JsonSerializer.Serialize(list_PaySanrenpuku_Pay);
            var list_PaySanrenpuku_Ninki = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_PaySanrenpuku_Ninki.Add(FixedLengthParser.ReadString(span, 564 + (i * 18), 3));
            }
            PaySanrenpuku_Ninki = JsonSerializer.Serialize(list_PaySanrenpuku_Ninki);
            var list_PaySanrentan_Kumi = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                list_PaySanrentan_Kumi.Add(FixedLengthParser.ReadString(span, 603 + (i * 19), 6));
            }
            PaySanrentan_Kumi = JsonSerializer.Serialize(list_PaySanrentan_Kumi);
            var list_PaySanrentan_Pay = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                list_PaySanrentan_Pay.Add(FixedLengthParser.ReadString(span, 609 + (i * 19), 9));
            }
            PaySanrentan_Pay = JsonSerializer.Serialize(list_PaySanrentan_Pay);
            var list_PaySanrentan_Ninki = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                list_PaySanrentan_Ninki.Add(FixedLengthParser.ReadString(span, 618 + (i * 19), 4));
            }
            PaySanrentan_Ninki = JsonSerializer.Serialize(list_PaySanrentan_Ninki);
            crlf = FixedLengthParser.ReadString(span, 717, 2);
        }
    }
}
