namespace Core.Entities.Loan
{
    /// <summary>
    /// 机构（继承于担保人）
    /// </summary>
    public class GuarantorOrganization : Guarantor
    {
        /// <summary>
        /// 贷款卡编码
        /// </summary>
        public string CreditcardCode { get; set; }
    }
}
