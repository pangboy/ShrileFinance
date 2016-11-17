namespace Application.Mappings
{
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Customers.Enterprise;
    using Core.Entities.Finance;
    using Core.Entities.Produce;
    using Core.Entities.Vehicle;
    using ViewModels.AccountViewModels;
    using ViewModels.FinanceViewModels;
    using ViewModels.OrganizationViewModels;
    using ViewModels.PartnerViewModels;
    using ViewModels.ProcessViewModels;
    using ViewModels.ProduceViewModel;
    using ViewModels.VehicleViewModel;
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
                .ForMember(d => d.Approvers, opt => opt.ResolveUsing(s => s.Approvers.Select(m => m.Id)));
            CreateMap<Produce, ViewModels.PartnerViewModels.ProduceViewModel>();

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

            CreateMap<Produce, ViewModels.ProduceViewModel.ProduceViewModel>();
            CreateMap<FinancingItem, FinancingItemViewModel>();
            CreateMap<FinancingProject, FinancingProjectViewModel>();
            CreateMap<Finance, FinanceApplyViewModel>();
            CreateMap<Vehicle, VehicleViewModel>();
            CreateMap<Applicant, ApplicationViewModel>();

            CreateMap<CreditExamine, CreditExamineViewModel>();
            // 运营
            CreateMap<FinanceExtension, OperationViewModel>();
            CreateMap<FinanceProduce, FinanceProduceViewModel>();
        }
    }
}
