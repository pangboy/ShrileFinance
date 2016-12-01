namespace Application.ViewModels.LoanViewModels
{
    using System;
    using Core.Entities.Loan;

    /// <summary>
    /// 担保合同
    /// </summary>
    public abstract class GuarantyContractViewModel
    {
        /// <summary>
        /// 标识
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        public DateTime? SigningDate { get; set; }

        /// <summary>
        /// 担保形式
        /// </summary>
        public GuarantyContract.GuaranteeFormEnum? GuaranteeForm { get; set; }

        /// <summary>
        /// 有效状态
        /// </summary>
        public GuarantyContract.EffectiveStateEnum? EffectiveState { get; set; }

        /// <summary>
        /// 保证金额
        /// </summary>
        public decimal? Margin { get; set; }

        /// <summary>
        /// 担保人
        /// </summary>
        public IGuarantor IGuarantor { get; set; }
    }
}
