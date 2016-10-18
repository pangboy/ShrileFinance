//using Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace Web.Controllers
//{
//    public class NodeController : ApiController
//    {
//        private readonly static BLL.Flow.FlowNode node = new BLL.Flow.FlowNode();

//        /// <summary>
//        /// 查询所有节点
//        /// </summary>
//        /// yand    15.11.27
//        /// <returns></returns>
//        public IList<ComboInfo> GetAll()
//        {
//            IList<ComboInfo> result = node.GetAll();

//            return result;
//        }

//        /// <summary>
//        /// 根据流程ID和角色ID查询hasfile
//        /// </summary>
//        /// yand    15.12.01
//        /// <param name="workflow_id">流程ID</param>
//        /// <returns></returns>
//        [HttpGet]
//        public NodeInfo FindHisFile(int workflow_id)
//        {
//            return node.FindHasFile(workflow_id);
//        }
//    }
//}
