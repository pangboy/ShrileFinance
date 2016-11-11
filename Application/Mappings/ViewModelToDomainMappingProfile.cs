namespace Application.Mappings
{
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Customers.Enterprise;
    using Core.Entities.Finance;
    using Core.Entities.Produce;
    using ViewModels.AccountViewModels;
    using ViewModels.FinanceViewModels;
    using ViewModels.OrganizationViewModels;
    using ViewModels.ProduceViewModel;

    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, AppUser>()
                .ForMember(d => d.Id, opt => opt.Condition(s => !string.IsNullOrEmpty(s.Id)))
                .ForMember(d => d.UserName, opt => opt.Ignore())
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.Phone));

            CreateMap<AssociatedEnterpriseViewModel, AssociatedEnterprise>();
            CreateMap<ParentViewModel, OrganizationParent>();
            CreateMap<PropertiesViewModel, OrganizationProperties>();
            CreateMap<StateViewModel, OrganizationState>();
            CreateMap<ManagerViewModel, Manager>();
            CreateMap<BaseViewModel, Organization>();
            CreateMap<FinancialAffairsViewModel, FinancialAffairs>();
            CreateMap<StockholderViewModel, Stockholder>();
            CreateMap<OrganizationViewModel, Organization>();
            CreateMap<ContactViewModel, OrganizationContact>();
            CreateMap<FamilyMemberViewModel, FamilyMember>();
            CreateMap<CashFlowViewModel, CashFlow>();
            CreateMap<LiabilitiesViewModel, Liabilities>();
            CreateMap<LitigationViewModel, Litigation>();
            CreateMap<BigEventViewModel, BigEvent>();
            CreateMap<ProfitViewModel, Profit>();
            CreateMap<InstitutionIncomeExpenditureViewModel, InstitutionIncomeExpenditure>();
            CreateMap<InstitutionLiabilitiesViewModel, InstitutionLiabilities>();

            CreateMap<ProduceViewModel, Produce>();
            CreateMap<FinancingItemViewModel, FinancingItem>();
            CreateMap<FinancingProjectViewModel, FinancingProject>();

            // 信审报告
            CreateMap<CreditExamineViewModel, CreditExamine>();

            // 融资审核
            CreateMap<FinanceAuidtViewModel,FinanceAudit>();
        }
    }
}
