using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;

namespace Web.Controllers.Flow
{
    public class FlowController : ApiController
    {
        /// <summary>
        /// 流程记录列表
        /// </summary>
        /// qiy     16.05.09
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        [HttpGet]
        public object LogList(int instanceId)
        {
            var _log = new BLL.Flow.Log();

            return _log.GetOpinion(instanceId);
        }

        /// <summary>
        /// 节点选项
        /// </summary>
        /// qiy     16.05.09
        /// <param name="flowId">流程标识</param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> NodeOption(int? flowId = null)
        {
            var _node = new BLL.Flow.Node();

            return _node.Option(flowId);
        }

        /// <summary>
        /// 获取流程框架信息
        /// </summary>
        /// qiy     16.04.29
        /// yaoy    16.07.26
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Frame(int instanceId)
        {
            var result = new BLL.Flow.Frame().GetFrameAllInfo(instanceId);

            return Ok(result);
        }


        /// <summary>
        /// 获取流程框架信息
        /// </summary>
        /// qiy     16.04.29
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        [HttpGet]
        public object FrameView(int instanceId)
        {
            var _flow = new BLL.Flow.Frame();

            return _flow.GetFrameInfo(instanceId);
        }
    }
}
