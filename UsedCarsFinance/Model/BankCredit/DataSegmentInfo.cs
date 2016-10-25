using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BankCredit
{
    /// <summary>
    /// 数据段实体
    /// </summary>
    /// yand    16.05.25
    public class DataSegmentInfo
    {
        [Alias("BDS_ID")]
        public int DataSegmentId { get; set; }
        public string ParagraphName { get; set; }
        public string ParagraphCode { get; set; }
        public string Describe { get; set; }
        public string times { get; set; }
        public string BRC_Status { get; set; }
        public int BIT_ID { get; set; }
        public List<SegmentRulesInfo> SegmnetRulesList { get; set; }
    }
}
