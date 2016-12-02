namespace Application.ViewModels.Loan.LoanViewModels
{
    using System;

    public class PaymentHistoryViewModel
    {
        /// <summary>
        /// 还款记录标识
        /// </summary>
        public Guid? Id { get; private set; }

        /// <summary>
        /// 应还本金
        /// </summary>
        public decimal ScheduledPaymentPrincipal { get; private set; }

        /// <summary>
        /// 应还利息
        /// </summary>
        public decimal ScheduledPaymentInterest { get; private set; }

        /// <summary>
        /// 实际偿还本金
        /// </summary>
        public decimal ActualPaymentPrincipal { get; private set; }

        /// <summary>
        /// 实际偿还利息
        /// </summary>
        public decimal ActualPaymentInterest { get; private set; }

        /// <summary>
        /// 还款日期
        /// </summary>
        public DateTime DatePayment { get; private set; }

        /// <summary>
        /// 还款方式
        /// </summary>
        public string PaymentTypes { get; private set; }
    }
}
