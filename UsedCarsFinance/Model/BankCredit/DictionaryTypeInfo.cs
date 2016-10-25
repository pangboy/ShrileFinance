using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BankCredit
{
    public class DictionaryTypeInfo
    {
        [Alias("BDT_ID")]
        public int DictionaryTypeId { get; set; }
        public string Name { get; set; }
        public int ParentType { get; set; }
    }
}
