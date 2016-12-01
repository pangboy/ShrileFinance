namespace Application.ViewModels.LoanViewModels
{
    using System;

    /// <summary>
    /// 机构（继承于担保人）
    /// </summary>
    public class GuarantyOrganizationViewModel
    {
        /// <summary>
        /// 标识
        /// </summary>
        public Guid Id { get; set; }

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
