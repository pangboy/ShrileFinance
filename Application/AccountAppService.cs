namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ViewModels.AccountViewModels;
    using X.PagedList;

    public class AccountAppService
    {
        private readonly AppUserManager userManager;
        private readonly AppRoleManager roleManager;

        public AccountAppService(AppUserManager userManager, AppRoleManager roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public System.Security.Principal.IPrincipal User { get; set; }

        /// <summary>
        /// 获取当前用户 [已弃用]
        /// </summary>
        /// <returns></returns>
        public AppUser CurrentUser()
        {
            return GetUser(User.Identity.GetUserId());
        }

        /// <summary>
        /// 获取当前角色的标识 [已弃用]
        /// </summary>
        /// <returns></returns>
        public AppRole CurrentRole()
        {
            var roleId = CurrentUser().Roles.First().RoleId;

            return GetRole(roleId);
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
        /// 根据角色获取用户
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <returns></returns>
        public IEnumerable<AppUser> GetByRole(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                throw new ArgumentNullException(roleId);
            }

            return userManager.Users.Where(m => m.Roles.Any(n => n.RoleId == roleId));
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="searchString">用户名或姓名</param>
        /// <param name="pageNumber">分页页码</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <returns></returns>
        public IPagedList<AppUser> List(string searchString, int pageNumber, int pageSize)
        {
            var user = userManager.Users;

            if (!string.IsNullOrEmpty(searchString))
            {
                user = user.Where(m => m.Name.Contains(searchString)
                    || m.UserName.Contains(searchString));
            }

            return user.ToPagedList(pageNumber, pageSize);
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
        /// <param name="model">修改密码模型</param>
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
        /// <param name="model">登录模型</param>
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
        /// 获取角色
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <returns></returns>
        public AppRole GetRole(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                throw new ArgumentNullException(nameof(roleId));
            }

            return roleManager.FindById(roleId);
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AppRole> GetRoles()
        {
            return roleManager.Roles;
        }

        /// <summary>
        /// 将用户添加到角色
        /// </summary>
        /// <param name="userId">用户标识</param>
        /// <param name="role">角色</param>
        /// <returns></returns>
        public Task<IdentityResult> AddToRoleAsync(string userId, AppRole role)
        {
            return userManager.AddToRoleAsync(userId, role.Id);
        }
    }
}
