using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_BN_BANUSI — Auto-generated entity
    /// </summary>
    public class BNEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string BanusiCode { get; private set; } = string.Empty;
        public string BanusiName_Co { get; private set; } = string.Empty;
        public string BanusiName { get; private set; } = string.Empty;
        public string BanusiNameKana { get; private set; } = string.Empty;
        public string BanusiNameEng { get; private set; } = string.Empty;
        public string Fukusyoku { get; private set; } = string.Empty;
        public string HonRuikei_SetYear { get; private set; } = string.Empty;
        public string HonRuikei_HonSyokinTotal { get; private set; } = string.Empty;
        public string HonRuikei_FukaSyokin { get; private set; } = string.Empty;
        public string HonRuikei_ChakuKaisu { get; private set; } = string.Empty;
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
            BanusiCode = FixedLengthParser.ReadString(span, 11, 6);
            BanusiName_Co = FixedLengthParser.ReadString(span, 17, 64);
            BanusiName = FixedLengthParser.ReadString(span, 81, 64);
            BanusiNameKana = FixedLengthParser.ReadString(span, 145, 50);
            BanusiNameEng = FixedLengthParser.ReadString(span, 195, 100);
            Fukusyoku = FixedLengthParser.ReadString(span, 295, 60);
            var list_HonRuikei_SetYear = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HonRuikei_SetYear.Add(FixedLengthParser.ReadString(span, 355 + (i * 60), 4));
            }
            HonRuikei_SetYear = JsonSerializer.Serialize(list_HonRuikei_SetYear);
            var list_HonRuikei_HonSyokinTotal = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HonRuikei_HonSyokinTotal.Add(FixedLengthParser.ReadString(span, 359 + (i * 60), 10));
            }
            HonRuikei_HonSyokinTotal = JsonSerializer.Serialize(list_HonRuikei_HonSyokinTotal);
            var list_HonRuikei_FukaSyokin = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HonRuikei_FukaSyokin.Add(FixedLengthParser.ReadString(span, 369 + (i * 60), 10));
            }
            HonRuikei_FukaSyokin = JsonSerializer.Serialize(list_HonRuikei_FukaSyokin);
            var list_HonRuikei_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HonRuikei_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 379 + (i * 60), 6));
            }
            HonRuikei_ChakuKaisu = JsonSerializer.Serialize(list_HonRuikei_ChakuKaisu);
            crlf = FixedLengthParser.ReadString(span, 475, 2);
        }
    }
}
