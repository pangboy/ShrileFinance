namespace Core.Entities.Finance
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Produce;

    public class Finance : Entity, IAggregateRoot
    {
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
        public DateTime RepaymentDate { get; set; }

        /// <summary>
        /// 还款方案
        /// </summary>
        public  RepaymentSchemeEnum RepaymentScheme { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal Bail { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public FinanceStateEnum State { get; set; }

        /// <summary>
        /// 放款日期
        /// </summary>
        public DateTime DateEffective { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// 合同
        /// </summary>
        public virtual ICollection<Contact> Contact { get; set; }

        /// <summary>
        /// 产品
        /// </summary>
        public virtual Produce Produce { get; set; }

        /// <summary>
        /// 信审报告
        /// </summary>
        public CreditExamine CreditExamine { get; set; }

        /// <summary>
        /// 意向融资金额
        /// </summary>
        public decimal IntentionPrincipal { get; set; }

        /// <summary>
        /// 月供先付期数
        /// </summary>
        public int OncePayMonths { get; set; }

        /// <summary>
        /// 建议融资金额
        /// </summary>
        public decimal AdviceMoney { get; set; }

        /// <summary>
        /// 建议融资比例
        /// </summary>
        public decimal AdviceRatio { get; set; }

        /// <summary>
        /// 审批金额
        /// </summary>
        public decimal ApprovalMoney { get; set; }

        /// <summary>
        /// 审批融资比例
        /// </summary>
        public decimal ApprovalRatio { get; set; }

        /// <summary>
        /// 月供金额
        /// </summary>
        public decimal Payment { get; set; }

        /// <summary>
        /// 还款日
        /// </summary>
        public DateTime  RepayDate { get; set; }

        /// <summary>
        /// 首次租金支付日期
        /// </summary>
        public DateTime RepayRentDate { get; set; }


        /// <summary>
        /// 联系人
        /// </summary>
        public virtual ICollection<Applicant> Applicant { get; set; }

        /// <summary>
        /// 车辆信息
        /// </summary>
        public virtual Vehicle.Vehicle VehicleInfo { get; set; }

        /// <summary>
        /// 融资扩展
        /// </summary>
        public virtual FinanceExtension FinanceExtension { get; set; }

        public enum RepaymentSchemeEnum : byte
        {
            /// <summary>
            /// 等额本息
            /// </summary>
            等额本息 =1,

            /// <summary>
            /// 月供提前付
            /// </summary>
            月供提前付 = 2,

            /// <summary>
            /// 一次性付息
            /// </summary>
            一次性付息 = 3
        }
    }
}
