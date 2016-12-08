namespace Application.ViewModels.Loan.CreditViewModel
{
    using System;

    /// <summary>
    /// 担保合同(服务页面)
    /// </summary>
    public class GuranteeContractViewModel : IEntityViewModel
    {
        /// <summary>
        /// 合同类型
        /// </summary>
        public enum ContractTypeEnum : byte
        {
            保证 = 0,
            质押 = 1,
            抵押 = 2
        }

        /// <summary>
        /// 保证人类型
        /// </summary>
        public enum GuarantorTypeEnum : byte
        {
            自然人 = 1,
            机构 = 2
        }

        public Guid? Id { get; set; }

        /// <summary>
        /// 保证
        /// </summary>
        public GuarantyContractViewModel GuarantyContractViewModel { get; set; }

        /// <summary>
        /// 抵押
        /// </summary>
        public GuarantyContractMortgageViewModel MortgageGuarantyContractViewModel { get; set; }

        /// <summary>
        /// 质押
        /// </summary>
        public GuarantyContractPledgeViewModel PledgeGuarantyContractViewModel { get; set; }

        /// <summary>
        /// 自然人
        /// </summary>
        public GuarantyPersonViewModel GuarantyPersonViewModel { get; set; }

        /// <summary>
        /// 机构
        /// </summary>
        public GuarantyOrganizationViewModel GuarantyOrganizationViewModel { get; set; }

        /// <summary>
        /// 保证人类型
        /// </summary>
        public GuarantorTypeEnum? GuarantorType { get; set; }

        /// <summary>
        /// 合同类型
        /// </summary>
        public ContractTypeEnum? ContractType { get; set; }
    }
}
