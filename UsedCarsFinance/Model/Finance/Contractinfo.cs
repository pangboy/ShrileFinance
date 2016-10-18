using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Finance
{ 
    /// <summary>
    /// 合同信息
    /// </summary>
    /// cais    16.05.09
    public class Contractinfo
    {
        /// <summary>
        /// 融资ID
        /// </summary>
        public int FinanceId { get; set; }

        /// <summary>
        /// 合同主要Num
        /// </summary>
        public string ContractMainCode { get; set; }

        /// <summary>
        /// 合同创建时间
        /// </summary>
        public DateTime ContractCreateDateTime { get; set; }
    }
}
