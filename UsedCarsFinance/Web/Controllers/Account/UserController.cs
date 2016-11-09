using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Application;
using Application.ViewModels.AccountViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Models;

namespace Web.Controllers.Account
{
    public class UserController : ApiController
    {
        private readonly AccountAppService service;
        private IAuthenticationManager AuthManager
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        public UserController(AccountAppService userService)
        {
            service.User = User;
            this.service = userService;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// qiy		15.11.17
        /// <param name="page">页码</param>
        /// <param name="rows">尺寸</param>
        /// <returns></returns>
        public IHttpActionResult GetAll(string searchString, int page, int rows)
        {
            var list = service.List(searchString, page, rows);

            return Ok(new {
                rows = list,
                total = list.TotalItemCount
            });
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// qiy		15.11.12
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public IHttpActionResult Get(string userId)
        {
            var user = service.GetUser(userId);

            return user != null ? (IHttpActionResult)Ok(user) : NotFound();
        }

        /// <summary>
        /// 用户选项
        /// </summary>
        /// qiy     16.05.31
        /// <param name="roleId">角色标识</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ComboInfo> Option(int? roleId)
        {
            return service.GetRoles().Select(m => new ComboInfo(m.Id, m.Name));
        }

        /// <summary>
        /// 注册帐号
        /// </summary>
        /// qiy		15.11.12
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(UserViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.CreateUserAsync(value);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// 修改帐号
        /// </summary>
        /// qiy		15.11.12
        /// <param name="userId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IHttpActionResult> Put(UserViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.ModifyUserAsync(value);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// qiy		15.11.12
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> SignIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var ident = await service.Login(model);

                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties {
                    IsPersistent = false
                }, ident);

                return Ok();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// qiy		15.11.12
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult SignOut()
        {
            AuthManager.SignOut();

            return Ok();
        }

        /// <summary>
        /// 查询当前用户信息
        /// </summary>
        /// yand     15.11.24
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult CurrentUser()
        {
            var user = service.CurrentUser();

            return Ok(user);
        }

        [HttpGet]
        /// <summary>
        /// 检查用户名
        /// </summary>
        /// qiy		15.11.25
        /// <returns></returns>
        public IHttpActionResult CheckUsername(string username)
        {
            return !service.CheckUsername(username) ? (IHttpActionResult)Ok() : BadRequest();
        }

        /// <summary>
        /// 启用帐号
        /// </summary>
        /// qiy		15.11.25
        /// <param name="userId">用户标识</param>
        [HttpGet]
        public async Task<IHttpActionResult> Enable(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest($"{nameof(userId)} 不可为空.");
            }

            var result = await service.EnableAsync(userId);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// 禁用帐号
        /// </summary>
        /// qiy		15.11.12
        /// <param name="userId">用户标识</param>
        [HttpGet]
        public async Task<IHttpActionResult> Disable(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest($"{nameof(userId)} 不可为空.");
            }

            var result = await service.DisableAsync(userId);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// qiy		15.11.25
        /// <param name="userId">用户标识</param>
        [HttpGet]
        public async Task<IHttpActionResult> ResetPassword(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest($"{nameof(userId)} 不可为空.");
            }

            var result = await service.ResetPasswordAsync(userId);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// yaoy    15.11.25
        /// <param name="UserId"></param>
        /// <param name="Old_Password"></param>
        /// <param name="New_Password"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> PasswordEdit(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.Id = User.Identity.GetUserId();

            var result = await service.ChangePasswordAsync(model);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// 编辑权限
        /// </summary>
        /// yaoy    15.11.25
        /// qiy		16.03.09
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PermissionEdit(MenuPermissionsInfo value)
        {
            BLL.User.Permissions menuPermissions = new BLL.User.Permissions();

            return menuPermissions.MenuPermissionEdit(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // 没有可发送的 ModelState 错误，因此仅返回空 BadRequest。
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
