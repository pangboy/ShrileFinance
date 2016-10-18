using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Specialized;
using Model;
using Model.Credit;

namespace Web.Controllers.Credit
{
    public class CreditAccountController : ApiController
    {
        private readonly static BLL.Credit.Account _account = new BLL.Credit.Account();

        /// <summary>
        /// 获取授信主体账号信息列表
        /// </summary>
        /// yaoy    16.03.30
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [HttpGet]
        public Datagrid List(int page, int rows)
        {
            Pagination pagination = new Pagination(page, rows);
            NameValueCollection data = ApiHelper.GetParameters();

            return new Datagrid
            {
                rows = _account.List(pagination, data),
                total = pagination.Total
            };
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// yaoy    16.03.31
        /// <param name="userId"></param>
        /// <returns></returns>
        public AccountInfo Get(int userId)
        {
            return _account.Get(userId);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// yaoy    16.03.31
        /// <param name="value"></param>
        /// <returns></returns>
        public IHttpActionResult Post(AccountInfo value)
        {
            return _account.Add(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yaoy    16.03.31
        /// <param name="value"></param>
        /// <returns></returns>
        public IHttpActionResult Put(AccountInfo value)
        {
            return _account.Modify(value) ? (IHttpActionResult)Ok() : BadRequest("修改失败");
        }
    }
}
