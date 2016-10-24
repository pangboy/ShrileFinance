using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Finance
{
    /// <summary>
    /// 审核类型
    /// yangj   2016.08.30
    /// </summary>
    public enum ReviewType : byte
    {
        初审 = 1,
        复审 = 2
    }

    /// <summary>
    /// 初审审核信息实体
    /// yangj   2016.08.30
    /// </summary>
    public class ReviewInfo
    {
        public int FinanceId { get; set; }

        /// <summary>
        /// 建议融资金额
        /// </summary>
        public decimal? AdvicefinanceMoney { get; set; }

        /// <summary>
        /// 审批融资本金
        /// </summary>
        public decimal ApprovalPrincipal { get; set; }

        /// <summary>
        /// 审批融资比例
        /// </summary>
        public double ApprovalFinanceRatio { get; set; }

        /// <summary>
        /// 金融手续费
        /// </summary>
        public decimal? FinanceCost { get; set; }

        /// <summary>
        /// 最终手续费
        /// </summary>
        public decimal? FinalCost { get; set; }

        /// <summary>
        /// 月供额度
        /// </summary>
        public decimal? Payment { get; set; }

        /// <summary>
        /// 确定还款日
        /// </summary>
        public int? RepaymentDate { get; set; }

        /// <summary>
        /// 审核类型
        /// </summary>
        public byte? ReviewType { get; set; }
    }
}
