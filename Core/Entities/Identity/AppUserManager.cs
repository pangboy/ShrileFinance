namespace Core.Entities
{
    using System.Security.Principal;
    using Microsoft.AspNet.Identity;

    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        {
            // 配置用户名的验证逻辑
            this.UserValidator = new UserValidator<AppUser>(this) {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = false
            };

            // 配置密码的验证逻辑
            this.PasswordValidator = new PasswordValidator {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            UserTokenProvider = new EmailTokenProvider<AppUser>();
        }

        public IPrincipal User { get; set; }

        public bool CheckUsername(string username)
        {
            var user = this.FindByName(username);

            return user != null;
        }

        public AppUser CurrentUser()
        {
            var userId = User.Identity.GetUserId();

            return FindByIdAsync(userId).Result;
        }
    }
}
