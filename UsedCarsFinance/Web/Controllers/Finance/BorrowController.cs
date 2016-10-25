using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.Finance
{
    public class BorrowController : ApiController
    {
        private static readonly BLL.Finance.Borrow borrow = new BLL.Finance.Borrow();

        /// <summary>
        /// 获取借贷信息
        /// </summary>
        /// zouql   16.08.30
        /// <param name="financeId">融资标识</param>
        /// <returns>借贷信息</returns>
        [HttpGet]
        public IHttpActionResult Get(int financeId)
        {
            var result = borrow.Get(financeId);

            return result!=null ? (IHttpActionResult)Ok(result) : BadRequest("获取失败");
        }

        /// <summary>
        /// 获取所有借贷信息
        /// </summary>
        /// zouql   16.08.30
        /// <returns>借贷信息</returns>
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = borrow.GetAll();

            return result != null ? (IHttpActionResult)Ok(result) : BadRequest("获取失败");
        }

        /// <summary>
        /// 添加借贷信息
        /// </summary>
        /// zouql   16.08.30
        /// <param name="financeId">融资标识</param>
        /// <returns>添加结果</returns>
        [HttpPost]
        public IHttpActionResult Add(int financeId)
        {
            return borrow.Add(financeId) ? (IHttpActionResult)Ok("保存成功"):BadRequest("保存失败");
        }

        /// <summary>
        /// 修改借贷信息
        /// </summary>
        /// zouql   16.08.30
        /// <param name="value">借贷信息</param>
        /// <returns>修改结果</returns>
        [HttpPost]
        public IHttpActionResult Modify(Models.Finance.BorrowInfo value)
        {
            var result = borrow.Moddify(value);

            return result ? (IHttpActionResult)Ok("修改成功") : BadRequest("修改失败");
        }
    }
}
