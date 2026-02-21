using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_BR_BREEDER — Auto-generated entity
    /// </summary>
    public class BREntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string BreederCode { get; private set; } = string.Empty;
        public string BreederName_Co { get; private set; } = string.Empty;
        public string BreederName { get; private set; } = string.Empty;
        public string BreederNameKana { get; private set; } = string.Empty;
        public string BreederNameEng { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
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
            BreederCode = FixedLengthParser.ReadString(span, 11, 8);
            BreederName_Co = FixedLengthParser.ReadString(span, 19, 72);
            BreederName = FixedLengthParser.ReadString(span, 91, 72);
            BreederNameKana = FixedLengthParser.ReadString(span, 163, 72);
            BreederNameEng = FixedLengthParser.ReadString(span, 235, 168);
            Address = FixedLengthParser.ReadString(span, 403, 20);
            var list_HonRuikei_SetYear = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HonRuikei_SetYear.Add(FixedLengthParser.ReadString(span, 423 + (i * 60), 4));
            }
            HonRuikei_SetYear = JsonSerializer.Serialize(list_HonRuikei_SetYear);
            var list_HonRuikei_HonSyokinTotal = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HonRuikei_HonSyokinTotal.Add(FixedLengthParser.ReadString(span, 427 + (i * 60), 10));
            }
            HonRuikei_HonSyokinTotal = JsonSerializer.Serialize(list_HonRuikei_HonSyokinTotal);
            var list_HonRuikei_FukaSyokin = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HonRuikei_FukaSyokin.Add(FixedLengthParser.ReadString(span, 437 + (i * 60), 10));
            }
            HonRuikei_FukaSyokin = JsonSerializer.Serialize(list_HonRuikei_FukaSyokin);
            var list_HonRuikei_ChakuKaisu = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HonRuikei_ChakuKaisu.Add(FixedLengthParser.ReadString(span, 447 + (i * 60), 6));
            }
            HonRuikei_ChakuKaisu = JsonSerializer.Serialize(list_HonRuikei_ChakuKaisu);
            crlf = FixedLengthParser.ReadString(span, 543, 2);
        }
    }
}
