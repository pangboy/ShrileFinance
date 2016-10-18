using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BankCredit
{
    /// <summary>
    /// 数据段规则实体
    /// </summary>
    /// yand    16.07.07
    public class SegmentRulesInfo
    {
        [Alias("BSR_ID")]
        public int SegmentRulesId { get; set; }
        public int Position { get; set; }
        public string IsRequired { get; set; }
        public string Description { get; set; }
        public int MetaCode { get; set; }
        public int BDS_ID { get; set; }
        public MetaInfo MetaInfo { get; set; }
    }
}
