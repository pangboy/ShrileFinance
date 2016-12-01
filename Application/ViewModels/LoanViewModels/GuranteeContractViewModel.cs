namespace Application.ViewModels.LoanViewModels
{
    public class GuranteeContractViewModel
    {
        /// <summary>
        /// 机构
        /// </summary>
        public GuarantyOrganizationViewModel GuarantyOrganizationViewModel { get; set; }

        /// <summary>
        /// 自然人
        /// </summary>
        public GuarantyPersonViewModel GuarantyPersonViewModel { get; set; }

        /// <summary>
        /// 抵押
        /// </summary>
        public MortgageGuarantyContractViewModel MortgageGuarantyContractViewModel { get; set; }

        /// <summary>
        /// 质押
        /// </summary>
        public PledgeGuarantyContractViewModel PledgeGuarantyContractViewModel { get; set; }
    }
}
