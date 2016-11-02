namespace Application
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
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

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public AppUser GetUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return userManager.FindById(userId);
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="model">用户</param>
        /// <returns></returns>
        public Task<IdentityResult> CreateUserAsync(UserViewModel model)
        {
            var user = Mapper.Map<AppUser>(model);

            return userManager.CreateAsync(user, AppUser.DEFAULTPASSWORD);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model">用户</param>
        /// <returns></returns>
        public Task<IdentityResult> ModifyUserAsync(UserViewModel model)
        {
            var user = GetUser(model.Id);
            Mapper.Map(model, user);

            return userManager.UpdateAsync(user);
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public bool CheckUsername(string username)
        {
            return userManager.CheckUsername(username);
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public async Task<IdentityResult> ResetPasswordAsync(string userId)
        {
            var token = await userManager.GeneratePasswordResetTokenAsync(userId);

            var result = await userManager.ResetPasswordAsync(userId, token, AppUser.DEFAULTPASSWORD);

            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="currentPassword">当前密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        public Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            return userManager.ChangePasswordAsync(model.Id, model.CurrentPassword, model.NewPassword);
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public Task<IdentityResult> EnableAsync(string userId)
        {
            return userManager.SetLockoutEnabledAsync(userId, false);
        }

        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public Task<IdentityResult> DisableAsync(string userId)
        {
            return userManager.SetLockoutEnabledAsync(userId, true);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> Login(LoginViewModel model)
        {
            var user = await userManager.FindAsync(model.Username, model.Password);

            if (user == null)
            {
                throw new ApplicationException("Invalid name or password.");
            }

            return await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        }

        /// <summary>
        /// 将用户添加到角色
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="role">角色</param>
        /// <returns></returns>
        public Task<IdentityResult> AddToRoleAsync(string userId, Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            return userManager.AddToRoleAsync(userId, role.Id);
        }
    }
}
