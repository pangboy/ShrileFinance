namespace Application.ViewModels.LoanViewModels
{
    using System;
    using Core.Entities.Loan;

    /// <summary>
    /// 机构（继承于担保人）
    /// </summary>
    public class GuarantyOrganizationViewModel: Guarantor
    {
        /// <summary>
        /// 标识
        /// </summary>
        public new Guid? Id { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public new string Name { get; set; }

        /// <summary>
        /// 贷款卡编码
        /// </summary>
        public string CreditcardCode { get; set; }
    }
}
