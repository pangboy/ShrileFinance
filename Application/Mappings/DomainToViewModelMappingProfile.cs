namespace Application.Mappings
{
    using AutoMapper;
    using ViewModels.OrganizationViewModels;

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap< Core.Entities.Customers.Enterprise.Organization,OrganizationViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.AssociatedEnterprise,AssociatedEnterpriseViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.OrganizationParent,ParentViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.OrganizationProperties,PropertiesViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.OrganizationState,StateViewModel >();
            CreateMap<Core.Entities.Customers.Enterprise.Manager,ManagerViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.FinancialAffairs, FinancialAffairsViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.Organization,BaseViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.Stockholder,StockholderViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.Organization,OrganizationViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.OrganizationContact,ContactViewModel>();
            CreateMap<Core.Entities.Customers.Enterprise.FamilyMember,FamilyMemberViewModel>();
        }
    }
}
