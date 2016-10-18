using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BankCredit
{
    public class ComponentInfo
    {
        public int Type { get; set; }
        public int HtmlelementId { get; set; }
        public string HtmlElement { get; set; }
        public int SegmentRulesId { get; set; }
        public string MetaName { get; set; }
        public int Length { get; set; }
        public string IsRequired { get; set; }
        public string Description { get; set; }
        public string DataType { get; set; }
        public int MetaCode { get; set; }

        public RuleTypeInfo RuleType { get; set; }

    }
}
