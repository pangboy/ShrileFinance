using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using Application;
using Models;

namespace Web.Controllers.Account
{
    public class RoleController : ApiController
    {
        private AccountAppService service;

        public RoleController(AccountAppService service)
        {
            this.service = service;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// yaoy    15.11.25
        /// <returns></returns>
        public IEnumerable<ComboInfo> GetAll()
        {
            return service.GetRoles().Select(m => new ComboInfo(m.Id, m.Name));
        }
    }
}
