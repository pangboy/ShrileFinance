using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BankCredit
{
    /// <summary>
    /// 字典代码
    /// </summary>
    /// zouql 2016-07-05
    /// yand    16.07.18 (增加CodeID)
    public class DictionaryCodeInfo
    {
        public int CodeID { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父节点代码
        /// </summary>
        public int? ParentCode { get; set; }
        /// <summary>
        /// 字典类型ID（外键）
        /// </summary>
        [Alias("BDI_ID")]
        public int DictionaryTypeId { get; set; }
    }
}
