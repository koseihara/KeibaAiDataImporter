using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_SK_SANKU — Auto-generated entity
    /// </summary>
    public class SKEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string KettoNum { get; private set; } = string.Empty;
        public string BirthDate_Year { get; private set; } = string.Empty;
        public string BirthDate_Month { get; private set; } = string.Empty;
        public string BirthDate_Day { get; private set; } = string.Empty;
        public string SexCD { get; private set; } = string.Empty;
        public string HinsyuCD { get; private set; } = string.Empty;
        public string KeiroCD { get; private set; } = string.Empty;
        public string SankuMochiKubun { get; private set; } = string.Empty;
        public string ImportYear { get; private set; } = string.Empty;
        public string BreederCode { get; private set; } = string.Empty;
        public string SanchiName { get; private set; } = string.Empty;
        public string HansyokuNum { get; private set; } = string.Empty;
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
            BirthDate_Year = FixedLengthParser.ReadString(span, 21, 4);
            BirthDate_Month = FixedLengthParser.ReadString(span, 25, 2);
            BirthDate_Day = FixedLengthParser.ReadString(span, 27, 2);
            SexCD = FixedLengthParser.ReadString(span, 29, 1);
            HinsyuCD = FixedLengthParser.ReadString(span, 30, 1);
            KeiroCD = FixedLengthParser.ReadString(span, 31, 2);
            SankuMochiKubun = FixedLengthParser.ReadString(span, 33, 1);
            ImportYear = FixedLengthParser.ReadString(span, 34, 4);
            BreederCode = FixedLengthParser.ReadString(span, 38, 8);
            SanchiName = FixedLengthParser.ReadString(span, 46, 20);
            var list_HansyokuNum = new List<string>();
            for (int i = 0; i < 14; i++)
            {
                list_HansyokuNum.Add(FixedLengthParser.ReadString(span, 66 + (i * 10), 10));
            }
            HansyokuNum = JsonSerializer.Serialize(list_HansyokuNum);
            crlf = FixedLengthParser.ReadString(span, 206, 2);
        }
    }
}
