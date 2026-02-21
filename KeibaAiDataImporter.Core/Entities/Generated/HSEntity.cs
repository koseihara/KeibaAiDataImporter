using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_HS_SALE — Auto-generated entity
    /// </summary>
    public class HSEntity : JvEntity
    {
        public string head_RecordSpec { get; private set; } = string.Empty;
        public string head_DataKubun { get; private set; } = string.Empty;
        public string head_MakeDate_Year { get; private set; } = string.Empty;
        public string head_MakeDate_Month { get; private set; } = string.Empty;
        public string head_MakeDate_Day { get; private set; } = string.Empty;
        public string KettoNum { get; private set; } = string.Empty;
        public string HansyokuFNum { get; private set; } = string.Empty;
        public string HansyokuMNum { get; private set; } = string.Empty;
        public string BirthYear { get; private set; } = string.Empty;
        public string SaleCode { get; private set; } = string.Empty;
        public string SaleHostName { get; private set; } = string.Empty;
        public string SaleName { get; private set; } = string.Empty;
        public string FromDate_Year { get; private set; } = string.Empty;
        public string FromDate_Month { get; private set; } = string.Empty;
        public string FromDate_Day { get; private set; } = string.Empty;
        public string ToDate_Year { get; private set; } = string.Empty;
        public string ToDate_Month { get; private set; } = string.Empty;
        public string ToDate_Day { get; private set; } = string.Empty;
        public string Barei { get; private set; } = string.Empty;
        public string Price { get; private set; } = string.Empty;
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
            HansyokuFNum = FixedLengthParser.ReadString(span, 21, 10);
            HansyokuMNum = FixedLengthParser.ReadString(span, 31, 10);
            BirthYear = FixedLengthParser.ReadString(span, 41, 4);
            SaleCode = FixedLengthParser.ReadString(span, 45, 6);
            SaleHostName = FixedLengthParser.ReadString(span, 51, 40);
            SaleName = FixedLengthParser.ReadString(span, 91, 80);
            FromDate_Year = FixedLengthParser.ReadString(span, 171, 4);
            FromDate_Month = FixedLengthParser.ReadString(span, 175, 2);
            FromDate_Day = FixedLengthParser.ReadString(span, 177, 2);
            ToDate_Year = FixedLengthParser.ReadString(span, 179, 4);
            ToDate_Month = FixedLengthParser.ReadString(span, 183, 2);
            ToDate_Day = FixedLengthParser.ReadString(span, 185, 2);
            Barei = FixedLengthParser.ReadString(span, 187, 1);
            Price = FixedLengthParser.ReadString(span, 188, 10);
            crlf = FixedLengthParser.ReadString(span, 198, 2);
        }
    }
}
