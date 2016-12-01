namespace Core.Services.Loan
{
    using Entities.Loan;

    /// <summary>
    /// 还款服务
    /// </summary>
    public class PaymentService
    {
        /// <summary>
        /// 还款
        /// </summary>
        /// <param name="loan">借据</param>
        /// <param name="payment">还款记录</param>
        public void Payment(Loan loan, PaymentHistory payment)
        {
            if (payment.ScheduledPaymentPrincipal == payment.ActualPaymentPrincipal
                && payment.ScheduledPaymentInterest == payment.ActualPaymentInterest)
            {
                // 还款
                // 新增还款记录
                loan.AddPaymentHistory(payment);

                // 调整四级分类
                loan.SetFourCategoryAssetsClassification(FourCategoryAssetsClassificationEnum.正常);
            }
            else if (payment.ScheduledPaymentPrincipal > payment.ActualPaymentPrincipal)
            {
                // 逾期
                // 新增还款记录
                loan.AddPaymentHistory(payment);

                // 调整四级分类
                loan.SetFourCategoryAssetsClassification(FourCategoryAssetsClassificationEnum.逾期);
            }
            else
            {
                // 欠息
                // 新增还款记录
                loan.AddPaymentHistory(payment);
            }
        }
    }
}
