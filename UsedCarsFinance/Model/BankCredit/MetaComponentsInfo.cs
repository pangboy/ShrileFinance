using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BankCredit
{
    public class MetaComponentsInfo
    {
        [Alias("BHE_ID")]
        public int HtmlElementId{ get; set; }
        public int MetaCode { get; set; }

        [Alias("BHE_Type")]
        public int Type { get; set; }
    }
}
