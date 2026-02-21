using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_BT_KEITO — Auto-generated entity
    /// </summary>
    public class BTEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string HansyokuNum { get; private set; } = string.Empty;
        public string KeitoId { get; private set; } = string.Empty;
        public string KeitoName { get; private set; } = string.Empty;
        public string KeitoEx { get; private set; } = string.Empty;
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
            HansyokuNum = FixedLengthParser.ReadString(span, 11, 10);
            KeitoId = FixedLengthParser.ReadString(span, 21, 30);
            KeitoName = FixedLengthParser.ReadString(span, 51, 36);
            KeitoEx = FixedLengthParser.ReadString(span, 87, 6800);
            crlf = FixedLengthParser.ReadString(span, 6887, 2);
        }
    }
}
