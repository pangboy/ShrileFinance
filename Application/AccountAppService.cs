namespace Application
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Core.Entities;
    using Microsoft.AspNet.Identity;
    using ViewModels.AccountViewModels;

    public class AccountAppService
    {
        private readonly AppUserManager userManager;

        public AccountAppService(AppUserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ClaimsIdentity> Login(LoginViewModel model)
        {
            var user = await userManager.FindAsync(model.Username, model.Password);

            if (user == null)
            {
                throw new ApplicationException("Invalid name or password.");
            }

            return await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public Task<IdentityResult> Create(RegisterViewModel model)
        {
            var user = new AppUser() {
                UserName = model.Username,
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.Phone
            };
            return userManager.CreateAsync(user, model.Password);
        }
    }
}
