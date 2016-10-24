using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BankCredit
{
    /// <summary>
    /// 数据元实体
    /// </summary>
    /// yand    16.07.04
   public class MetaInfo
    {
       public int MetaCode { get; set; }
        public string Name { get; set; }
        public int OldMetaCode { get; set; }
        public string DataType { get; set; }
        public int DatasLength { get; set; }
        public int Type { get; set; }
        public int OldType { get; set; }

        public RuleTypeInfo RuleType { get; set; }

        public List<HtmlElementInfo> Element { get; set; }
    }
}
