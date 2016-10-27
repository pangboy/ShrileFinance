namespace Application.Mappings
{
    using AutoMapper;
    using Core.Entities;

    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ViewModels.AccountViewModels.LoginViewModel, AppUser>();
            CreateMap<ViewModels.AccountViewModels.RegisterViewModel, AppUser>();

            CreateMap<ViewModels.OrganizationViewModels.AssociatedEnterpriseViewModel, Core.Entities.Customers.Enterprise.AssociatedEnterprise>();
            CreateMap<ViewModels.OrganizationViewModels.ParentViewModel, Core.Entities.Customers.Enterprise.OrganizationParent>();
            CreateMap<ViewModels.OrganizationViewModels.PropertiesViewModel, Core.Entities.Customers.Enterprise.OrganizationProperties>();
            CreateMap<ViewModels.OrganizationViewModels.StateViewModel, Core.Entities.Customers.Enterprise.OrganizationState>();
            CreateMap<ViewModels.OrganizationViewModels.ManagerViewModel, Core.Entities.Customers.Enterprise.Manager>();
            CreateMap<ViewModels.OrganizationViewModels.BaseViewModel, Core.Entities.Customers.Enterprise.Organization>();
            CreateMap<ViewModels.OrganizationViewModels.StockholderViewModel, Core.Entities.Customers.Enterprise.Stockholder>();
            CreateMap<ViewModels.OrganizationViewModels.Organization, Core.Entities.Customers.Enterprise.Organization>();
            CreateMap<ViewModels.OrganizationViewModels.ContactViewModel, Core.Entities.Customers.Enterprise.OrganizationContact>();
            CreateMap<ViewModels.OrganizationViewModels.FamilyMemberViewModel, Core.Entities.Customers.Enterprise.FamilyMember>();

            //名称不相同时的映射
            //CreateMap<ViewModels.OrganizationViewModels.BaseViewModel, Core.Entities.Customers.Enterprise.Organization>()
            //    .ForMember(d => d.ManagementerCode, opt => opt.MapFrom(s => s.ManagementerCode));
        }
    }
}
