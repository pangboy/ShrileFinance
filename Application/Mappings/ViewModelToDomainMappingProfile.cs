namespace Application.Mappings
{
    using AutoMapper;
    using Core.Entities;
    using ViewModels.OrganizationViewModels;

    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ViewModels.AccountViewModels.LoginViewModel, AppUser>();
            CreateMap<ViewModels.AccountViewModels.RegisterViewModel, AppUser>();

            CreateMap<AssociatedEnterpriseViewModel, Core.Entities.Customers.Enterprise.AssociatedEnterprise>();
            CreateMap<ParentViewModel, Core.Entities.Customers.Enterprise.OrganizationParent>();
            CreateMap<PropertiesViewModel, Core.Entities.Customers.Enterprise.OrganizationProperties>();
            CreateMap<StateViewModel, Core.Entities.Customers.Enterprise.OrganizationState>();
            CreateMap<ManagerViewModel, Core.Entities.Customers.Enterprise.Manager>();
            CreateMap<BaseViewModel, Core.Entities.Customers.Enterprise.Organization>();
            CreateMap<StockholderViewModel, Core.Entities.Customers.Enterprise.Stockholder>();
            CreateMap<OrganizationViewModel, Core.Entities.Customers.Enterprise.Organization>();
            CreateMap<ContactViewModel, Core.Entities.Customers.Enterprise.OrganizationContact>();
            CreateMap<FamilyMemberViewModel, Core.Entities.Customers.Enterprise.FamilyMember>();
        }
    }
}
