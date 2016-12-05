namespace Application.ViewModels.Loan.CreditViewModel
{
    using System;
    using Core.Entities.Loan;

    /// <summary>
    /// 自然人（继承于担保人）
    /// </summary>
    public class GuarantyPersonViewModel:Guarantor
    {
        /// <summary>
        /// 标识
        /// </summary>
        public new Guid? Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public new string Name { get; set; }

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
