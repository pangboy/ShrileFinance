namespace Application.ViewModels.Loan.CreditViewModel
{
    /// <summary>
    /// 机构（继承于担保人）
    /// </summary>
    public class GuarantyOrganizationViewModel: GuarantorViewModel
    {
        /// <summary>
        /// 贷款卡编码
        /// </summary>
        public string CreditcardCode { get; set; }
    }
}
