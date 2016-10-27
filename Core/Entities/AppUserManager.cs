﻿namespace Core.Entities
{
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
        }
    }
}