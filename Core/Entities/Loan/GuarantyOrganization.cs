namespace Core.Entities.Loan
{
    /// <summary>
    /// 机构（继承于担保人）
    /// </summary>
    public class GuarantyOrganization : Entity, IGuarantor
    {
        /// <summary>
        /// 机构名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 贷款卡编码
        /// </summary>
        public string CreditcardCode { get; set; }
    }
}
