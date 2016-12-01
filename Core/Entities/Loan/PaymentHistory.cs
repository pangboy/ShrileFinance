namespace Core.Entities.Loan
{
    using System;
    using Interfaces;

    /// <summary>
    /// 还款记录
    /// </summary>
    public class PaymentHistory : Entity, IAggregateRoot
    {
        public PaymentHistory(
            decimal schedulePaymentPrincipal,
            decimal scheduledPaymentInterest,
            decimal actualPaymentPrincipal,
            decimal actualPaymentInterest)
        {
            ScheduledPaymentPrincipal = ScheduledPaymentPrincipal;
            ScheduledPaymentInterest = scheduledPaymentInterest;
            ActualPaymentPrincipal = actualPaymentPrincipal;
            ActualPaymentInterest = actualPaymentInterest;
            DatePayment = DateTime.Now;
        }

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
