namespace Application.Mappings
{
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Customers.Enterprise;
    using Core.Entities.Finance;
    using Core.Entities.Produce;
    using ViewModels.AccountViewModels;
    using ViewModels.FinanceViewModels;
    using ViewModels.OrganizationViewModels;
    using ViewModels.PartnerViewModels;
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

            CreateMap<Core.Entities.Flow.Instance, InstanceViewModel>();

            CreateMap<Core.Entities.Partner.Partner, PartnerViewModel>()
                .ForMember(d => d.Accounts, opt => opt.ResolveUsing(s => s.Accounts.Select(m => m.Id)));

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

            CreateMap<CreditExamine, CreditExamineViewModel>();
            CreateMap<FinanceAuidtViewModel, FinanceAuidtViewModel>();
        }
    }
}
