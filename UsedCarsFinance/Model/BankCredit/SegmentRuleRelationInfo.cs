using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BankCredit
{
    public class SegmentRuleRelationInfo
    {
        public int InfoTypeId { get; set; }
        public int GroupId { get; set; }
        public int FirstSegmentRuleId { get; set; }
        public int SecondSegmentRuleId { get; set; }
        public string SegmentRelation { get; set; }
    }
}
