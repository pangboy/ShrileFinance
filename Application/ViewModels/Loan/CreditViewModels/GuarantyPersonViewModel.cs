namespace Application.ViewModels.Loan.CreditViewModel
{
    /// <summary>
    /// 自然人（继承于担保人）
    /// </summary>
    public class GuarantyPersonViewModel : GuarantorViewModel
    {
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertificateNumber { get; set; }
    }
}
