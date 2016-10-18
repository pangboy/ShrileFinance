using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BankCredit
{
    /// <summary>
    /// html元素实体
    /// </summary>
    /// yand    16.07.04
   public class HtmlElementInfo
    {
       [Alias("BHE_ID")]
       public int HtmlElementID { get; set; }
        public string Name { get; set; }
        public string Html { get; set; }
    }
}
