namespace Application.Mappings
{
    using AutoMapper;
    using ViewModels.AccountViewModels;
    using ViewModels.OrganizationViewModels;
    using ViewModels.ProcessViewModels;
    using X.PagedList;

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap(typeof(IPagedList<>), typeof(IPagedList<>)).ConvertUsing(typeof(PagedListTypeConverter<,>));

            CreateMap<Core.Entities.AppUser, UserViewModel>()
                .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.PhoneNumber));

            CreateMap<Core.Entities.Customers.Enterprise.Organization, OrganizationViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.AssociatedEnterprise, AssociatedEnterpriseViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.OrganizationParent, ParentViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.OrganizationProperties, PropertiesViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.OrganizationState, StateViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.Manager, ManagerViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.FinancialAffairs, FinancialAffairsViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.Organization, BaseViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.Stockholder, StockholderViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.Organization, OrganizationViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.OrganizationContact, ContactViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.FamilyMember, FamilyMemberViewModel>();

            CreateMap<Core.Entities.Customers.Enterprise.CashFlow, CashFlowViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.Liabilities, LiabilitiesViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.Litigation, LitigationViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.BigEvent, BigEventViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.Profit, ProfitViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.InstitutionIncomeExpenditure, InstitutionIncomeExpenditureViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.InstitutionLiabilities, InstitutionLiabilitiesViewModel>();

            CreateMap<Core.Entities.Flow.Instance, InstanceViewModel>();
        }
    }
}
