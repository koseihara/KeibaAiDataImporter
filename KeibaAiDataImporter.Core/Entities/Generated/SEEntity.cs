using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_SE_RACE_UMA — Auto-generated entity
    /// </summary>
    public class SEEntity : JvEntity
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
        public string Wakuban { get; private set; } = string.Empty;
        public string Umaban { get; private set; } = string.Empty;
        public string KettoNum { get; private set; } = string.Empty;
        public string Bamei { get; private set; } = string.Empty;
        public string UmaKigoCD { get; private set; } = string.Empty;
        public string SexCD { get; private set; } = string.Empty;
        public string HinsyuCD { get; private set; } = string.Empty;
        public string KeiroCD { get; private set; } = string.Empty;
        public string Barei { get; private set; } = string.Empty;
        public string TozaiCD { get; private set; } = string.Empty;
        public string ChokyosiCode { get; private set; } = string.Empty;
        public string ChokyosiRyakusyo { get; private set; } = string.Empty;
        public string BanusiCode { get; private set; } = string.Empty;
        public string BanusiName { get; private set; } = string.Empty;
        public string Fukusyoku { get; private set; } = string.Empty;
        public string reserved1 { get; private set; } = string.Empty;
        public string Futan { get; private set; } = string.Empty;
        public string FutanBefore { get; private set; } = string.Empty;
        public string Blinker { get; private set; } = string.Empty;
        public string reserved2 { get; private set; } = string.Empty;
        public string KisyuCode { get; private set; } = string.Empty;
        public string KisyuCodeBefore { get; private set; } = string.Empty;
        public string KisyuRyakusyo { get; private set; } = string.Empty;
        public string KisyuRyakusyoBefore { get; private set; } = string.Empty;
        public string MinaraiCD { get; private set; } = string.Empty;
        public string MinaraiCDBefore { get; private set; } = string.Empty;
        public string BaTaijyu { get; private set; } = string.Empty;
        public string ZogenFugo { get; private set; } = string.Empty;
        public string ZogenSa { get; private set; } = string.Empty;
        public string IJyoCD { get; private set; } = string.Empty;
        public string NyusenJyuni { get; private set; } = string.Empty;
        public string KakuteiJyuni { get; private set; } = string.Empty;
        public string DochakuKubun { get; private set; } = string.Empty;
        public string DochakuTosu { get; private set; } = string.Empty;
        public string Time { get; private set; } = string.Empty;
        public string ChakusaCD { get; private set; } = string.Empty;
        public string ChakusaCDP { get; private set; } = string.Empty;
        public string ChakusaCDPP { get; private set; } = string.Empty;
        public string Jyuni1c { get; private set; } = string.Empty;
        public string Jyuni2c { get; private set; } = string.Empty;
        public string Jyuni3c { get; private set; } = string.Empty;
        public string Jyuni4c { get; private set; } = string.Empty;
        public string Odds { get; private set; } = string.Empty;
        public string Ninki { get; private set; } = string.Empty;
        public string Honsyokin { get; private set; } = string.Empty;
        public string Fukasyokin { get; private set; } = string.Empty;
        public string reserved3 { get; private set; } = string.Empty;
        public string reserved4 { get; private set; } = string.Empty;
        public string HaronTimeL4 { get; private set; } = string.Empty;
        public string HaronTimeL3 { get; private set; } = string.Empty;
        public string ChakuUmaInfo_KettoNum { get; private set; } = string.Empty;
        public string ChakuUmaInfo_Bamei { get; private set; } = string.Empty;
        public string TimeDiff { get; private set; } = string.Empty;
        public string RecordUpKubun { get; private set; } = string.Empty;
        public string DMKubun { get; private set; } = string.Empty;
        public string DMTime { get; private set; } = string.Empty;
        public string DMGosaP { get; private set; } = string.Empty;
        public string DMGosaM { get; private set; } = string.Empty;
        public string DMJyuni { get; private set; } = string.Empty;
        public string KyakusituKubun { get; private set; } = string.Empty;
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
            Wakuban = FixedLengthParser.ReadString(span, 27, 1);
            Umaban = FixedLengthParser.ReadString(span, 28, 2);
            KettoNum = FixedLengthParser.ReadString(span, 30, 10);
            Bamei = FixedLengthParser.ReadString(span, 40, 36);
            UmaKigoCD = FixedLengthParser.ReadString(span, 76, 2);
            SexCD = FixedLengthParser.ReadString(span, 78, 1);
            HinsyuCD = FixedLengthParser.ReadString(span, 79, 1);
            KeiroCD = FixedLengthParser.ReadString(span, 80, 2);
            Barei = FixedLengthParser.ReadString(span, 82, 2);
            TozaiCD = FixedLengthParser.ReadString(span, 84, 1);
            ChokyosiCode = FixedLengthParser.ReadString(span, 85, 5);
            ChokyosiRyakusyo = FixedLengthParser.ReadString(span, 90, 8);
            BanusiCode = FixedLengthParser.ReadString(span, 98, 6);
            BanusiName = FixedLengthParser.ReadString(span, 104, 64);
            Fukusyoku = FixedLengthParser.ReadString(span, 168, 60);
            reserved1 = FixedLengthParser.ReadString(span, 228, 60);
            Futan = FixedLengthParser.ReadString(span, 288, 3);
            FutanBefore = FixedLengthParser.ReadString(span, 291, 3);
            Blinker = FixedLengthParser.ReadString(span, 294, 1);
            reserved2 = FixedLengthParser.ReadString(span, 295, 1);
            KisyuCode = FixedLengthParser.ReadString(span, 296, 5);
            KisyuCodeBefore = FixedLengthParser.ReadString(span, 301, 5);
            KisyuRyakusyo = FixedLengthParser.ReadString(span, 306, 8);
            KisyuRyakusyoBefore = FixedLengthParser.ReadString(span, 314, 8);
            MinaraiCD = FixedLengthParser.ReadString(span, 322, 1);
            MinaraiCDBefore = FixedLengthParser.ReadString(span, 323, 1);
            BaTaijyu = FixedLengthParser.ReadString(span, 324, 3);
            ZogenFugo = FixedLengthParser.ReadString(span, 327, 1);
            ZogenSa = FixedLengthParser.ReadString(span, 328, 3);
            IJyoCD = FixedLengthParser.ReadString(span, 331, 1);
            NyusenJyuni = FixedLengthParser.ReadString(span, 332, 2);
            KakuteiJyuni = FixedLengthParser.ReadString(span, 334, 2);
            DochakuKubun = FixedLengthParser.ReadString(span, 336, 1);
            DochakuTosu = FixedLengthParser.ReadString(span, 337, 1);
            Time = FixedLengthParser.ReadString(span, 338, 4);
            ChakusaCD = FixedLengthParser.ReadString(span, 342, 3);
            ChakusaCDP = FixedLengthParser.ReadString(span, 345, 3);
            ChakusaCDPP = FixedLengthParser.ReadString(span, 348, 3);
            Jyuni1c = FixedLengthParser.ReadString(span, 351, 2);
            Jyuni2c = FixedLengthParser.ReadString(span, 353, 2);
            Jyuni3c = FixedLengthParser.ReadString(span, 355, 2);
            Jyuni4c = FixedLengthParser.ReadString(span, 357, 2);
            Odds = FixedLengthParser.ReadString(span, 359, 4);
            Ninki = FixedLengthParser.ReadString(span, 363, 2);
            Honsyokin = FixedLengthParser.ReadString(span, 365, 8);
            Fukasyokin = FixedLengthParser.ReadString(span, 373, 8);
            reserved3 = FixedLengthParser.ReadString(span, 381, 3);
            reserved4 = FixedLengthParser.ReadString(span, 384, 3);
            HaronTimeL4 = FixedLengthParser.ReadString(span, 387, 3);
            HaronTimeL3 = FixedLengthParser.ReadString(span, 390, 3);
            var list_ChakuUmaInfo_KettoNum = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_ChakuUmaInfo_KettoNum.Add(FixedLengthParser.ReadString(span, 393 + (i * 46), 10));
            }
            ChakuUmaInfo_KettoNum = JsonSerializer.Serialize(list_ChakuUmaInfo_KettoNum);
            var list_ChakuUmaInfo_Bamei = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                list_ChakuUmaInfo_Bamei.Add(FixedLengthParser.ReadString(span, 403 + (i * 46), 36));
            }
            ChakuUmaInfo_Bamei = JsonSerializer.Serialize(list_ChakuUmaInfo_Bamei);
            TimeDiff = FixedLengthParser.ReadString(span, 531, 4);
            RecordUpKubun = FixedLengthParser.ReadString(span, 535, 1);
            DMKubun = FixedLengthParser.ReadString(span, 536, 1);
            DMTime = FixedLengthParser.ReadString(span, 537, 5);
            DMGosaP = FixedLengthParser.ReadString(span, 542, 4);
            DMGosaM = FixedLengthParser.ReadString(span, 546, 4);
            DMJyuni = FixedLengthParser.ReadString(span, 550, 2);
            KyakusituKubun = FixedLengthParser.ReadString(span, 552, 1);
            crlf = FixedLengthParser.ReadString(span, 553, 2);
        }
    }
}
