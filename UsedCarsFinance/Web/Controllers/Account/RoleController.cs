using Model;
using Model.User;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.Account
{
    public class RoleController : ApiController
    {
        private readonly static BLL.User.Role _role = new BLL.User.Role();

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// yaoy    15.11.25
        /// <returns></returns>
        public List<ComboInfo> GetAll()
        {
            return _role.Option();
        }
    }
}
