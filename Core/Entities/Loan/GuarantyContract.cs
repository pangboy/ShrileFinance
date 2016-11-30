using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Loan
{
    /// <summary>
    /// 担保合同
    /// </summary>
    public abstract class GuarantyContract : Entity
    {
        /// <summary>
        /// 担保人
        /// </summary>
        public IGuarantor IGuarantor { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        public DateTime SigningDate{ get; set; }

        /// <summary>
        /// 担保形式
        /// </summary>
        public string GuaranteeForm{ get; set; }

        /// <summary>
        /// 有效状态
        /// </summary>
        public string EffectiveState { get; set; }

        /// <summary>
        /// 保证金额
        /// </summary>
        public decimal Margin { get; set; }
    }
}
