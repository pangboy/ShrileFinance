using System;
using System.Collections.Specialized;
using System.Web.Http;
using Model;
using Model.Flow;
using Model.Finance;
using System.Collections.Generic;

namespace Web.Controllers.Flow
{
    public class InstanceController : ApiController
    {
        private readonly static BLL.Flow.Instance _instance = new BLL.Flow.Instance();

        /// <summary>
        /// 待办列表
        /// </summary>
        /// qiy     16.04.29
        /// <param name="page">页数</param>
        /// <param name="rows">行数</param>
        /// <returns></returns>
        [HttpGet]
        public Datagrid DoingList(int page, int rows)
        {
            Pagination pagination = new Pagination(page, rows);
            NameValueCollection filter = ApiHelper.GetParameters();

            return new Datagrid
            {
                rows = _instance.DoingList(pagination, filter),
                total = pagination.Total
            };
        }

        /// <summary>
        /// 已办列表
        /// </summary>
        /// qiy     16.04.29
        /// <param name="page">页数</param>
        /// <param name="rows">行数</param>
        /// <returns></returns>
        [HttpGet]
        public Datagrid DoneList(int page, int rows)
        {
            Pagination pagination = new Pagination(page, rows);
            NameValueCollection filter = ApiHelper.GetParameters();

            return new Datagrid
            {
                rows = _instance.DoneList(pagination, filter),
                total = pagination.Total
            };
        }

        /// <summary>
        /// 添加待发起流程
        /// </summary>
        /// yaoy    16.07.26
        /// <returns></returns>
        [HttpPost]
        public int StartProcess()
        {
            return _instance.StartProcess();
        }

        /// <summary>
        /// 流程撤回
        /// </summary>
        /// yaoy    16.08.30
        /// <param name="instanceId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Revoke(int instanceId)
        {
            var result = false;
            string message = string.Empty;

            result = new BLL.Flow.RevokeUtil().RevokeFlow(instanceId, ref message);

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(message);
            }
        }

        /// <summary>
        /// 保存临时数据
        /// </summary>
        /// yaoy    16.08.29
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult SaveTempData(FlowData data)
        {
            var instanceId = Convert.ToInt32(data.InstanceId);
            var value = data.BusinessData;
            var result = _instance.ModifyTempData(instanceId, value);

            return Ok(result);
        }

        /// <summary>
        /// 查询临时数据
        /// </summary>
        /// yaoy    16.07.26
        /// <param name="instanceId"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetTempData(int instanceId)
        {
            return _instance.GetData(instanceId);
        }

        /// <summary>
        /// 查询KeyXML数据
        /// </summary>
        /// yaoy    16.07.27
        /// <param name="instanceId"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetXMLData(int instanceId)
        {
            return _instance.GetXMLData(instanceId);
        }
    }
}
