using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_H6_HYOSU_SANRENTAN — Auto-generated entity
    /// </summary>
    public class H6Entity : JvEntity
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
        public string HatubaiFlag { get; private set; } = string.Empty;
        public string HenkanUma { get; private set; } = string.Empty;
        public string HyoSanrentan_Kumi { get; private set; } = string.Empty;
        public string HyoSanrentan_Hyo { get; private set; } = string.Empty;
        public string HyoSanrentan_Ninki { get; private set; } = string.Empty;
        public string HyoTotal { get; private set; } = string.Empty;
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
            HatubaiFlag = FixedLengthParser.ReadString(span, 31, 1);
            var list_HenkanUma = new List<string>();
            for (int i = 0; i < 18; i++)
            {
                list_HenkanUma.Add(FixedLengthParser.ReadString(span, 32 + (i * 1), 1));
            }
            HenkanUma = JsonSerializer.Serialize(list_HenkanUma);
            var list_HyoSanrentan_Kumi = new List<string>();
            for (int i = 0; i < 4896; i++)
            {
                list_HyoSanrentan_Kumi.Add(FixedLengthParser.ReadString(span, 50 + (i * 21), 6));
            }
            HyoSanrentan_Kumi = JsonSerializer.Serialize(list_HyoSanrentan_Kumi);
            var list_HyoSanrentan_Hyo = new List<string>();
            for (int i = 0; i < 4896; i++)
            {
                list_HyoSanrentan_Hyo.Add(FixedLengthParser.ReadString(span, 56 + (i * 21), 11));
            }
            HyoSanrentan_Hyo = JsonSerializer.Serialize(list_HyoSanrentan_Hyo);
            var list_HyoSanrentan_Ninki = new List<string>();
            for (int i = 0; i < 4896; i++)
            {
                list_HyoSanrentan_Ninki.Add(FixedLengthParser.ReadString(span, 67 + (i * 21), 4));
            }
            HyoSanrentan_Ninki = JsonSerializer.Serialize(list_HyoSanrentan_Ninki);
            var list_HyoTotal = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                list_HyoTotal.Add(FixedLengthParser.ReadString(span, 102866 + (i * 11), 11));
            }
            HyoTotal = JsonSerializer.Serialize(list_HyoTotal);
            crlf = FixedLengthParser.ReadString(span, 102888, 2);
        }
    }
}
