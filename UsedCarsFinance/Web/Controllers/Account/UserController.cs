using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Http;
using Application;
using Models;
using Models.User;

namespace Web.Controllers.Account
{
    public class UserController : ApiController
    {
        private readonly static BLL.User.User _user = new BLL.User.User();
        private readonly AccountAppService userService;

        public UserController(AccountAppService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// qiy		15.11.17
        /// <param name="page">页码</param>
        /// <param name="rows">尺寸</param>
        /// <returns></returns>
        public Datagrid GetAll(int page, int rows)
        {
            Pagination pagination = new Pagination(page, rows);
            NameValueCollection filter = ApiHelper.GetParameters();

            return new Datagrid {
                rows = _user.List(pagination, filter),
                total = pagination.Total
            };
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// qiy		15.11.12
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public IHttpActionResult Get(int userId)
        {
            UserInfo user = _user.GetUser(userId);

            return user != null ? (IHttpActionResult)Ok(user) : NotFound();
        }

        /// <summary>
        /// 用户选项
        /// </summary>
        /// qiy     16.05.31
        /// <param name="roleId">角色标识</param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> Option(int? roleId)
        {
            return _user.Option(roleId);
        }

        /// <summary>
        /// 注册帐号
        /// </summary>
        /// qiy		15.11.12
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post(UserInfo value)
        {
            return _user.Add(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }

        /// <summary>
        /// 修改帐号
        /// </summary>
        /// qiy		15.11.12
        /// <param name="userId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Put(UserInfo value)
        {
            return _user.Modify(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// qiy		15.11.12
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult SignIn(string username, string password)
        {
            string message;

            return _user.SignIn(username, password, out message) ? (IHttpActionResult)Ok() : BadRequest(message);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// qiy		15.11.12
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult SignOut()
        {
            _user.SignOut();

            return Ok();
        }

        /// <summary>
        /// 查询当前用户信息
        /// </summary>
        /// yand     15.11.24
        /// <returns></returns>
        [HttpGet]
        public object CurrentUser()
        {
            UserInfo user = _user.CurrentUser();

            return new {
                user = user,
                role = new BLL.User.Role().Get(user.RoleId)
            };
        }

        [HttpGet]
        /// <summary>
        /// 检查用户名
        /// </summary>
        /// qiy		15.11.25
        /// <returns></returns>
        public IHttpActionResult CheckUsername(string username)
        {
            return _user.CheckUsername(username) ? (IHttpActionResult)Ok() : BadRequest();
        }

        /// <summary>
        /// 启用帐号
        /// </summary>
        /// qiy		15.11.25
        /// <param name="userId">用户标识</param>
        [HttpGet]
        public IHttpActionResult Enable(int userId)
        {
            return _user.Enable(userId) ? (IHttpActionResult)Ok() : BadRequest("启用失败");
        }

        /// <summary>
        /// 禁用帐号
        /// </summary>
        /// qiy		15.11.12
        /// <param name="userId">用户标识</param>
        [HttpGet]
        public IHttpActionResult Disable(int userId)
        {
            return _user.Disable(userId) ? (IHttpActionResult)Ok() : BadRequest("禁用失败");
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// qiy		15.11.25
        /// <param name="userId">用户标识</param>
        [HttpGet]
        public IHttpActionResult ResetPassword(int userId)
        {
            string message;

            return _user.ResetPassword(userId, out message) ? (IHttpActionResult)Ok() : BadRequest(message);
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
        public IHttpActionResult PasswordEdit(int UserId, string Old_Password, string New_Password)
        {
            string message;

            return _user.ModifyPassword(UserId, Old_Password, New_Password, out message) ? (IHttpActionResult)Ok() : BadRequest(message);
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
    }
}
