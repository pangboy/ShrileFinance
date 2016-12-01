namespace Application.ViewModels.LoanViewModels
{
    using Core.Entities.Loan;

    /// <summary>
    /// 质押保证合同
    /// </summary>
    public class PledgeGuarantyContractViewModel : GuarantyContractViewModel
    {
        /// <summary>
        /// 质押序号
        /// </summary>
        public string PledgeNumber { get; set; }

        /// <summary>
        /// 质押物价值
        /// </summary>
        public decimal? CollateralValue { get; set; }

        /// <summary>
        /// 质押物种类
        /// </summary>
        public PledgeGuarantyContract.PledgeTypeEnum? PledgeType { get; set; }
    }
}
