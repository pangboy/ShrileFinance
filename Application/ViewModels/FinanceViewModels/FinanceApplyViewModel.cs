using System;
using System.Collections.Generic;
using Core.Entities.Finance;

namespace Application.ViewModels.FinanceViewModels
{
    public class FinanceApplyViewModel
    {
        /// <summary>
        /// 融资标识
        /// </summary>
        public Guid FinanceId { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public Guid ProduceId { get; set; }

        /// <summary>
        /// 厂商指导价
        /// </summary>
        public decimal ManufacturerGuidePrice { get; set; }

        /// <summary>
        /// 建议融资金额
        /// </summary>
        public decimal AdviceMoney { get; set; }

        /// <summary>
        /// 建议融资比例
        /// </summary>
        public decimal AdviceRatio { get; set; }

        /// <summary>
        /// 审批融资金额
        /// </summary>
        public decimal ApprovalMoney { get; set; }

        /// <summary>
        /// 审批融资比例
        /// </summary>
        public decimal ApprovalRatio { get; set; }

        /// <summary>
        /// 月供额度
        /// </summary>
        public decimal Payment { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// 是否为复审
        /// </summary>
        public bool IsReview { get; set; }

        /// <summary>
        /// 融资本金
        /// </summary>
        public decimal Principal { get; set; }

        /// <summary>
        /// 利率
        /// </summary>
        public double InterestRate { get; set; }

        /// <summary>
        /// 融资期限 (月)
        /// </summary>
        public int Periods { get; set; }

        /// <summary>
        /// 还款间隔 (月)
        /// </summary>
        public int RepaymentInterval { get; set; }

        /// <summary>
        /// 还款日
        /// </summary>
        public DateTime? RepaymentDate { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal Bail { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public FinanceStateEnum State { get; set; }

        /// <summary>
        /// 放款日期
        /// </summary>
        public DateTime? DateEffective { get; set; }

        /// <summary>
        /// 意向融资金额
        /// </summary>
        public decimal IntentionPrincipal { get; set; }

        /// <summary>
        /// 月供先付期数
        /// </summary>
        public int OncePayMonths { get; set; }

        /// <summary>
        /// 首次租金支付日期
        /// </summary>
        public DateTime? RepayRentDate { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public virtual ICollection<ApplicationViewModel> Applicant { get; set; }

        /// <summary>
        /// 车辆信息
        /// </summary>
        public virtual VehicleViewModel.VehicleViewModel Vehicle { get; set; }
        /// <summary>
        /// 合同
        /// </summary>
        public virtual ICollection<ContractViewModel> Contact { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual ProduceViewModel.ProduceViewModel Produce { get; set; }

        public virtual ICollection<FinanceProduce> FinanceProduce { get; set; }
        /// <summary>
        /// 信审报告
        /// </summary>
        public virtual CreditExamineViewModel CreditExamine { get; set; }
    }
}
