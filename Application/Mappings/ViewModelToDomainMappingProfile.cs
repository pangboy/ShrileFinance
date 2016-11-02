namespace Application.Mappings
{
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Customers.Enterprise;
    using ViewModels.AccountViewModels;
    using ViewModels.OrganizationViewModels;

    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, AppUser>();

            CreateMap<AssociatedEnterpriseViewModel, Core.Entities.Customers.Enterprise.AssociatedEnterprise>();
            CreateMap<ParentViewModel, Core.Entities.Customers.Enterprise.OrganizationParent>();
            CreateMap<PropertiesViewModel, Core.Entities.Customers.Enterprise.OrganizationProperties>();
            CreateMap<StateViewModel, Core.Entities.Customers.Enterprise.OrganizationState>();
            CreateMap<ManagerViewModel, Core.Entities.Customers.Enterprise.Manager>();
            CreateMap<BaseViewModel, Core.Entities.Customers.Enterprise.Organization>();
            CreateMap<FinancialAffairsViewModel, Core.Entities.Customers.Enterprise.FinancialAffairs>();
            CreateMap<StockholderViewModel, Core.Entities.Customers.Enterprise.Stockholder>();
            CreateMap<OrganizationViewModel, Core.Entities.Customers.Enterprise.Organization>();
            CreateMap<ContactViewModel, Core.Entities.Customers.Enterprise.OrganizationContact>();
            CreateMap<FamilyMemberViewModel, Core.Entities.Customers.Enterprise.FamilyMember>();

            CreateMap<CashFlowViewModel, Core.Entities.Customers.Enterprise.CashFlow>();
            CreateMap<LiabilitiesViewModel, Core.Entities.Customers.Enterprise.Liabilities>();
            CreateMap<LitigationViewModel, Core.Entities.Customers.Enterprise.Litigation>();
            CreateMap<BigEventViewModel, Core.Entities.Customers.Enterprise.BigEvent>();
            CreateMap<ProfitViewModel, Core.Entities.Customers.Enterprise.Profit>();
            CreateMap<InstitutionIncomeExpenditureViewModel, Core.Entities.Customers.Enterprise.InstitutionIncomeExpenditure>();
            CreateMap<InstitutionLiabilitiesViewModel, Core.Entities.Customers.Enterprise.InstitutionLiabilities>();

        }
    }
}
