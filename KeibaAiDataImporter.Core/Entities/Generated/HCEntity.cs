using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_HC_HANRO — Auto-generated entity
    /// </summary>
    public class HCEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string TresenKubun { get; private set; } = string.Empty;
        public string ChokyoDate_Year { get; private set; } = string.Empty;
        public string ChokyoDate_Month { get; private set; } = string.Empty;
        public string ChokyoDate_Day { get; private set; } = string.Empty;
        public string ChokyoTime { get; private set; } = string.Empty;
        public string KettoNum { get; private set; } = string.Empty;
        public string HaronTime4 { get; private set; } = string.Empty;
        public string LapTime4 { get; private set; } = string.Empty;
        public string HaronTime3 { get; private set; } = string.Empty;
        public string LapTime3 { get; private set; } = string.Empty;
        public string HaronTime2 { get; private set; } = string.Empty;
        public string LapTime2 { get; private set; } = string.Empty;
        public string LapTime1 { get; private set; } = string.Empty;
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
            TresenKubun = FixedLengthParser.ReadString(span, 11, 1);
            ChokyoDate_Year = FixedLengthParser.ReadString(span, 12, 4);
            ChokyoDate_Month = FixedLengthParser.ReadString(span, 16, 2);
            ChokyoDate_Day = FixedLengthParser.ReadString(span, 18, 2);
            ChokyoTime = FixedLengthParser.ReadString(span, 20, 4);
            KettoNum = FixedLengthParser.ReadString(span, 24, 10);
            HaronTime4 = FixedLengthParser.ReadString(span, 34, 4);
            LapTime4 = FixedLengthParser.ReadString(span, 38, 3);
            HaronTime3 = FixedLengthParser.ReadString(span, 41, 4);
            LapTime3 = FixedLengthParser.ReadString(span, 45, 3);
            HaronTime2 = FixedLengthParser.ReadString(span, 48, 4);
            LapTime2 = FixedLengthParser.ReadString(span, 52, 3);
            LapTime1 = FixedLengthParser.ReadString(span, 55, 3);
            crlf = FixedLengthParser.ReadString(span, 58, 2);
        }
    }
}
