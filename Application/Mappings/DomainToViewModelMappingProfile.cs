namespace Application.Mappings
{
    using AutoMapper;
    using Core.Entities.Customers.Enterprise;
    using Core.Entities.Finance;
    using Core.Entities.Produce;
    using ViewModels.AccountViewModels;
    using ViewModels.FinanceViewModels;
    using ViewModels.OrganizationViewModels;
    using ViewModels.ProcessViewModels;
    using ViewModels.ProduceViewModel;
    using X.PagedList;

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap(typeof(IPagedList<>), typeof(IPagedList<>)).ConvertUsing(typeof(PagedListTypeConverter<,>));

            CreateMap<Core.Entities.AppUser, UserViewModel>()
                .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.PhoneNumber));

            CreateMap<Organization, OrganizationViewModel>();
            CreateMap<AssociatedEnterprise, AssociatedEnterpriseViewModel>();
            CreateMap<OrganizationParent, ParentViewModel>();
            CreateMap<OrganizationProperties, PropertiesViewModel>();
            CreateMap<OrganizationState, StateViewModel>();
            CreateMap<Manager, ManagerViewModel>();
            CreateMap<FinancialAffairs, FinancialAffairsViewModel>();
            CreateMap<Organization, BaseViewModel>();
            CreateMap<Stockholder, StockholderViewModel>();
            CreateMap<Organization, OrganizationViewModel>();
            CreateMap<OrganizationContact, ContactViewModel>();
            CreateMap<FamilyMember, FamilyMemberViewModel>();

            CreateMap<CashFlow, CashFlowViewModel>();
            CreateMap<Liabilities, LiabilitiesViewModel>();
            CreateMap<Litigation, LitigationViewModel>();
            CreateMap<BigEvent, BigEventViewModel>();
            CreateMap<Profit, ProfitViewModel>();
            CreateMap<InstitutionIncomeExpenditure, InstitutionIncomeExpenditureViewModel>();
            CreateMap<InstitutionLiabilities, InstitutionLiabilitiesViewModel>();

            CreateMap<Produce, ProduceViewModel>();
            CreateMap<FinancingItem, FinancingItemViewModel>();
            CreateMap<FinancingProject, FinancingProjectViewModel>();

            CreateMap<Core.Entities.Flow.Instance, InstanceViewModel>();

            // 信审报告
            CreateMap<CreditExamine, CreditExamineViewModel>();
        }
    }
}
