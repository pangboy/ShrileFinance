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
        }
    }
}
