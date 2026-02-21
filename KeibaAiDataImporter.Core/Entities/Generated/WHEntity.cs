using KeibaAiDataImporter.Core.Utils;
using System.Text.Json;
using System.Collections.Generic;

namespace KeibaAiDataImporter.Core.Entities
{
    /// <summary>
    /// JV_WH_BATAIJYU — Auto-generated entity
    /// </summary>
    public class WHEntity : JvEntity
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
        public string HappyoTime_Month { get; private set; } = string.Empty;
        public string HappyoTime_Day { get; private set; } = string.Empty;
        public string HappyoTime_Hour { get; private set; } = string.Empty;
        public string HappyoTime_Minute { get; private set; } = string.Empty;
        public string BataijyuInfo_Umaban { get; private set; } = string.Empty;
        public string BataijyuInfo_Bamei { get; private set; } = string.Empty;
        public string BataijyuInfo_BaTaijyu { get; private set; } = string.Empty;
        public string BataijyuInfo_ZogenFugo { get; private set; } = string.Empty;
        public string BataijyuInfo_ZogenSa { get; private set; } = string.Empty;
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
            HappyoTime_Month = FixedLengthParser.ReadString(span, 27, 2);
            HappyoTime_Day = FixedLengthParser.ReadString(span, 29, 2);
            HappyoTime_Hour = FixedLengthParser.ReadString(span, 31, 2);
            HappyoTime_Minute = FixedLengthParser.ReadString(span, 33, 2);
            var list_BataijyuInfo_Umaban = new List<string>();
            for (int i = 0; i < 18; i++)
            {
                list_BataijyuInfo_Umaban.Add(FixedLengthParser.ReadString(span, 35 + (i * 45), 2));
            }
            BataijyuInfo_Umaban = JsonSerializer.Serialize(list_BataijyuInfo_Umaban);
            var list_BataijyuInfo_Bamei = new List<string>();
            for (int i = 0; i < 18; i++)
            {
                list_BataijyuInfo_Bamei.Add(FixedLengthParser.ReadString(span, 37 + (i * 45), 36));
            }
            BataijyuInfo_Bamei = JsonSerializer.Serialize(list_BataijyuInfo_Bamei);
            var list_BataijyuInfo_BaTaijyu = new List<string>();
            for (int i = 0; i < 18; i++)
            {
                list_BataijyuInfo_BaTaijyu.Add(FixedLengthParser.ReadString(span, 73 + (i * 45), 3));
            }
            BataijyuInfo_BaTaijyu = JsonSerializer.Serialize(list_BataijyuInfo_BaTaijyu);
            var list_BataijyuInfo_ZogenFugo = new List<string>();
            for (int i = 0; i < 18; i++)
            {
                list_BataijyuInfo_ZogenFugo.Add(FixedLengthParser.ReadString(span, 76 + (i * 45), 1));
            }
            BataijyuInfo_ZogenFugo = JsonSerializer.Serialize(list_BataijyuInfo_ZogenFugo);
            var list_BataijyuInfo_ZogenSa = new List<string>();
            for (int i = 0; i < 18; i++)
            {
                list_BataijyuInfo_ZogenSa.Add(FixedLengthParser.ReadString(span, 77 + (i * 45), 3));
            }
            BataijyuInfo_ZogenSa = JsonSerializer.Serialize(list_BataijyuInfo_ZogenSa);
            crlf = FixedLengthParser.ReadString(span, 845, 2);
        }
    }
}
