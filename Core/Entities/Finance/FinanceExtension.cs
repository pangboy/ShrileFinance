﻿namespace Core.Entities.Finance
{
    using System;

    /// <summary>
    /// 融资扩展
    /// </summary>
    public class FinanceExtension : Entity
    {
        /// <summary>
        /// 选择还款日
        /// </summary>
        public DateTime RepaymentDate { get; set; }

        /// <summary>
        /// 首次租金支付日期
        /// </summary>
        public DateTime FirstPaymentDate { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal Margin { get; set; }

        /// <summary>
        /// 先付月供
        /// </summary>
        public decimal PayMonthly { get; set; }

        /// <summary>
        /// 一次性付息
        /// </summary>
        public decimal OnePayInterest { get; set; }

        /// <summary>
        /// 实际用款额
        /// </summary>
        public decimal ActualAmount { get; set; }

        /// <summary>
        /// 放款主体
        /// </summary>
        public string LoanPrincipal { get; set; }

        /// <summary>
        /// 放款账户
        /// </summary>
        public string CreditAccountId { get; set; }

        /// <summary>
        /// 放款账户开户行
        /// </summary>
        public string CreditBankName { get; set; }

        /// <summary>
        /// 放款账户卡号
        /// </summary>
        public string CreditBankCard { get; set; }

        /// <summary>
        /// 合同Json
        /// </summary>
        public string ContactJson { get; set; }
    }
}
