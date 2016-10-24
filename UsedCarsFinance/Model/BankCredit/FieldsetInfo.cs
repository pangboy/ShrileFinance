using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BankCredit
{
   public  class FieldsetInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ParagraphCode { get; set; }
        [Alias("BRC_Status")]
        public string Status { get; set; }
        public int Min { get; set; }
        public string Max { get; set; }
        public List<ComponentInfo> ComponentList { get; set; }
    }
}
