using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_CS_COURSE — Auto-generated entity
    /// </summary>
    public class CSEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string JyoCD { get; private set; } = string.Empty;
        public string Kyori { get; private set; } = string.Empty;
        public string TrackCD { get; private set; } = string.Empty;
        public string KaishuDate_Year { get; private set; } = string.Empty;
        public string KaishuDate_Month { get; private set; } = string.Empty;
        public string KaishuDate_Day { get; private set; } = string.Empty;
        public string CourseEx { get; private set; } = string.Empty;
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
            JyoCD = FixedLengthParser.ReadString(span, 11, 2);
            Kyori = FixedLengthParser.ReadString(span, 13, 4);
            TrackCD = FixedLengthParser.ReadString(span, 17, 2);
            KaishuDate_Year = FixedLengthParser.ReadString(span, 19, 4);
            KaishuDate_Month = FixedLengthParser.ReadString(span, 23, 2);
            KaishuDate_Day = FixedLengthParser.ReadString(span, 25, 2);
            CourseEx = FixedLengthParser.ReadString(span, 27, 6800);
            crlf = FixedLengthParser.ReadString(span, 6827, 2);
        }
    }
}
