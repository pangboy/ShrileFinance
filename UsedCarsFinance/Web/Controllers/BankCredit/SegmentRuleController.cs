using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.BankCredit;
using Models;
using Models.BankCredit;

namespace Web.Controllers.BankCredit
{
    /// <summary>
    /// 段规则控制器
    /// </summary>
    /// zouql zouql 2016-07-06
    public class SegmentRuleController : ApiController
    {
        private static readonly SegmentRules Segmentrule = new SegmentRules();
        private static readonly Meta MetaMapper = new Meta();

        /// <summary>
        /// 获取段规则列表
        /// </summary>
        /// zouql 2016-07-06
        /// <param name="page">页码</param>
        /// <param name="rows">数据</param>
        /// <returns>字典代码表</returns>
        [HttpGet]
        public Datagrid PageList(int page, int rows)
        {
            Pagination pagination = new Pagination(page, rows);
            NameValueCollection filter = ApiHelper.GetParameters();

            return new Datagrid
            {
                rows = Segmentrule.PageList(pagination, filter),
                total = pagination.Total
            };
        }

        /// <summary>
        /// 获取字典代码实体
        /// </summary>
        /// zouql 16.07.06
        /// <param name="bsrId">字典代码</param>
        /// <param name="metaCode">字典类型ID</param>
        /// <returns>字典代码实体</returns>
        [HttpGet]
        public object Get(string bsrId, string metaCode)
        {
            var c = Segmentrule.Get(bsrId, metaCode);
            var m = MetaMapper.Find(Convert.ToInt32(metaCode));

            return new { c.Position, c.Description, c.IsRequired, MetaCode = m.Name, EP = m.Type };
        }

        /// <summary>
        /// 添加字典
        /// </summary>
        /// zouql 2016-07-05
        /// <param name="value">字典代码实体</param>
        /// <returns>添加成功与否</returns>
        [HttpPost]
        public IHttpActionResult Create(SegmentRulesInfo value)
        {
            string messages = string.Empty;
            return Segmentrule.Create(value, out messages) ? (IHttpActionResult)Ok() : BadRequest(messages);
        }

        /// <summary>
        /// 修改字典
        /// </summary>
        /// zouql 2016-07-06
        /// <param name="value">字典代码实体</param>
        /// <returns>修改结果</returns>
        [HttpPost]
        public IHttpActionResult Modify(SegmentRulesInfo value)
        {
            return Segmentrule.Modify(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
        }

        /// <summary>
        /// 模糊查询元代码名称
        /// </summary>
        /// zouql  16.07.06
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetComListMateName()
        {
            var list = Segmentrule.GetComListMateName();
            list.Add(new ComboInfo(string.Empty, string.Empty));
            return list;
        }

        /// <summary>
        /// 模糊查询元代码名称
        /// </summary>
        /// zouql  16.07.06
        /// <param name="t">类型</param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetComListMateName(string t)
        {
            var list = Segmentrule.GetComListMateName(t);
            list.Add(new ComboInfo(string.Empty, string.Empty));
            return list;
        }

        /// <summary>
        /// 模糊查询元代码名称
        /// </summary>
        /// zouql  16.07.06
        /// <param name="value">字典类型ID</param>
        /// <param name="type">类型</param>
        /// <returns>结果</returns>
        [HttpGet]
        public List<ComboInfo> GetComListMateName(string value, string type)
        {
            var list = Segmentrule.GetComListMateName(value, type);

            return list;
        }
    }
}
