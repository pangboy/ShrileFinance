using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Finance
{
    /// <summary>
    /// 借贷信息
    /// </summary>
    /// zouql   16.08.30
    public class BorrowInfo
    {
        /// <summary>
        /// 标识
        /// </summary>
        [Alias("BI_ID")]
        public int Id { get; set; }

        /// <summary>
        /// 融资标识
        /// </summary>
        public int FinanceId { get; set; }

        /// <summary>
        /// 本金（审批融资本金）
        /// </summary>
        public decimal? ApprovalPrincipal { get; set; }

        /// <summary>
        /// 利率（产品月利率）
        /// </summary>
        public double InterestRate { get; set; }

        /// <summary>
        /// 期限（产品融资期限）
        /// </summary>
        public int FinancingPeriods { get; set; }

        /// <summary>
        /// 还款间隔（产品还款间隔）
        /// </summary>
        public int RepaymentInterval { get; set; }

        /// <summary>
        /// 还款方式
        /// </summary>
        public Produce.ProduceInfo.RepaymentMethodEnum RepaymentMethod { get;set; }

        /// <summary>
        /// 还款日
        /// </summary>
        public int? RepaymentDate { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime FinanceAddDate { get; set; }

        /// <summary>
        /// 当前期数
        /// </summary>
        public int CurrentMonths { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal? Balance { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 月供提前付期数（一次性付款期数）
        /// </summary>
        public int OncePayMonths { get; set; }

        /// <summary>
        /// 尾款比例
        /// </summary>
        public double FinalRatio { get; set; }

        /// <summary>
        /// 保证金比例
        /// </summary>
        public double CustomerBailRatio { get; set; }

        /// <summary>
        /// 手续费(最终手续费)
        /// </summary>
        public decimal? FinalCost { get; set; }

        /// <summary>
        /// 额外费用(产品 GPS与其他)
        /// </summary>
        public decimal? ExtralCost { get; set; }
    }
}
