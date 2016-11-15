namespace Application.ViewModels.FinanceViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 运营
    /// </summary>
    public class OperationViewModel
    {
        /// <summary>
        /// 融资标识
        /// </summary>
        public Guid FinanceId { get; set; }

        /// <summary>
        /// 融资项（Id、(Name、Maney)）
        /// </summary>
        public ICollection<KeyValuePair<Guid, KeyValuePair<string, decimal>>> FinancingItems { get; set; }

        /// <summary>
        /// 选择还款日
        /// </summary>
        [Required(ErrorMessage = "选择还款日 不可为空")]
        public int? RepaymentDate { get; set; }

        /// <summary>
        /// 首次租金支付日期
        /// </summary>
        [Required(ErrorMessage = "首次租金支付日期 不可为空")]
        public DateTime? FirstPaymentDate { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        [Required(ErrorMessage = "保证金 不可为空")]
        public decimal? Margin { get; set; }

        /// <summary>
        /// 先付月供
        /// </summary>
        [Required(ErrorMessage = "先付月供 不可为空")]
        public decimal? PayMonthly { get; set; }

        /// <summary>
        /// 一次性付息
        /// </summary>
        [Required(ErrorMessage = "一次性付息 不可为空")]
        public decimal? OnePayInterest { get; set; }

        /// <summary>
        /// 实际用款额
        /// </summary>
        [Required(ErrorMessage = "实际用款额 不可为空")]
        public decimal? ActualAmount { get; set; }

        /// <summary>
        /// 放款主体
        /// </summary>
        [Required(ErrorMessage = "放款主体 不可为空")]
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
