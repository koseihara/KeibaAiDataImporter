using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_WC_WOOD — Auto-generated entity
    /// </summary>
    public class WCEntity : JvEntity
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
        public string Course { get; private set; } = string.Empty;
        public string BabaAround { get; private set; } = string.Empty;
        public string reserved { get; private set; } = string.Empty;
        public string HaronTime10 { get; private set; } = string.Empty;
        public string LapTime10 { get; private set; } = string.Empty;
        public string HaronTime9 { get; private set; } = string.Empty;
        public string LapTime9 { get; private set; } = string.Empty;
        public string HaronTime8 { get; private set; } = string.Empty;
        public string LapTime8 { get; private set; } = string.Empty;
        public string HaronTime7 { get; private set; } = string.Empty;
        public string LapTime7 { get; private set; } = string.Empty;
        public string HaronTime6 { get; private set; } = string.Empty;
        public string LapTime6 { get; private set; } = string.Empty;
        public string HaronTime5 { get; private set; } = string.Empty;
        public string LapTime5 { get; private set; } = string.Empty;
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
            Course = FixedLengthParser.ReadString(span, 34, 1);
            BabaAround = FixedLengthParser.ReadString(span, 35, 1);
            reserved = FixedLengthParser.ReadString(span, 36, 1);
            HaronTime10 = FixedLengthParser.ReadString(span, 37, 4);
            LapTime10 = FixedLengthParser.ReadString(span, 41, 3);
            HaronTime9 = FixedLengthParser.ReadString(span, 44, 4);
            LapTime9 = FixedLengthParser.ReadString(span, 48, 3);
            HaronTime8 = FixedLengthParser.ReadString(span, 51, 4);
            LapTime8 = FixedLengthParser.ReadString(span, 55, 3);
            HaronTime7 = FixedLengthParser.ReadString(span, 58, 4);
            LapTime7 = FixedLengthParser.ReadString(span, 62, 3);
            HaronTime6 = FixedLengthParser.ReadString(span, 65, 4);
            LapTime6 = FixedLengthParser.ReadString(span, 69, 3);
            HaronTime5 = FixedLengthParser.ReadString(span, 72, 4);
            LapTime5 = FixedLengthParser.ReadString(span, 76, 3);
            HaronTime4 = FixedLengthParser.ReadString(span, 79, 4);
            LapTime4 = FixedLengthParser.ReadString(span, 83, 3);
            HaronTime3 = FixedLengthParser.ReadString(span, 86, 4);
            LapTime3 = FixedLengthParser.ReadString(span, 90, 3);
            HaronTime2 = FixedLengthParser.ReadString(span, 93, 4);
            LapTime2 = FixedLengthParser.ReadString(span, 97, 3);
            LapTime1 = FixedLengthParser.ReadString(span, 100, 3);
            crlf = FixedLengthParser.ReadString(span, 103, 2);
        }
    }
}
