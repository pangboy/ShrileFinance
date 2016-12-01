namespace Application.ViewModels.FinanceViewModels
{
    public class LoanViewModel
    {
        /// <summary>
        /// 审批融资金额
        /// </summary>
        public decimal? ApprovalMoney { get; set; }

        /// <summary>
        /// 保证金金额
        /// </summary>
        public decimal? CustomerBail { get; set; }

        /// <summary>
        /// 月供金额
        /// </summary>
        public double Payment { get; set; }

        /// <summary>
        /// 一次性付息金额
        /// </summary>
        public decimal? OnePayInterest { get; set; }

        /// <summary>
        /// 收款账户
        /// </summary>
        public string CreditAccountName { get; set; }

        /// <summary>
        /// 收款账户开户行
        /// </summary>
        public string CreditBankName { get; set; }

        /// <summary>
        /// 收款账户卡号
        /// </summary>
        public string CreditBankCard { get; set; }

        /// <summary>
        /// 还款账户
        /// </summary>
        public string CustomerAccountName { get; set; }

        /// <summary>
        /// 还款账户开户行
        /// </summary>
        public string CustomerBankName { get; set; }

        /// <summary>
        /// 还款账户卡号
        /// </summary>
        public string CustomerBankCard { get; set; }
    }
}
