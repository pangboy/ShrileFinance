namespace Application.Mappings
{
    using AutoMapper;
    using ViewModels.OrganizationViewModels;
    using Core.Entities.Customers.Enterprise;
    using Core.Entities.Produce;
    using Core.Entities.Finance;
    using ViewModels.ProduceViewModel;
    using ViewModels.FinanceViewModels;

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Organization,OrganizationViewModel>();
            CreateMap<AssociatedEnterprise,AssociatedEnterpriseViewModel>();
            CreateMap<OrganizationParent,ParentViewModel>();
            CreateMap<OrganizationProperties,PropertiesViewModel>();
            CreateMap<OrganizationState,StateViewModel >();
            CreateMap<Manager,ManagerViewModel>();
            CreateMap<FinancialAffairs, FinancialAffairsViewModel>();
            CreateMap<Organization,BaseViewModel>();
            CreateMap<Stockholder,StockholderViewModel>();
            CreateMap<Organization,OrganizationViewModel>();
            CreateMap<OrganizationContact,ContactViewModel>();
            CreateMap<FamilyMember,FamilyMemberViewModel>();

            CreateMap<CashFlow, CashFlowViewModel>();
            CreateMap<Liabilities, LiabilitiesViewModel>();
            CreateMap<Litigation, LitigationViewModel>();
            CreateMap<BigEvent,BigEventViewModel>();
            CreateMap<Profit,ProfitViewModel > ();
            CreateMap<InstitutionIncomeExpenditure, InstitutionIncomeExpenditureViewModel>();
            CreateMap<InstitutionLiabilities, InstitutionLiabilitiesViewModel>();

            CreateMap<Produce, ProduceViewModel>();
            CreateMap<FinancingItem, FinancingItemViewModel>();
            CreateMap<FinancingProject, FinancingProjectViewModel>();

            // 信审报告
            CreateMap<CreditExamine,CreditExamineViewModel>();

            // 融资审核
            CreateMap<FinanceAudit, FinanceAuidtViewModel>();
        }
    }
}
