//using BLL;
//using BLL.Flow;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace Web.Controllers
//{
//    public class ActionController : ApiController
//    {
//        private readonly static FlowAction action = new FlowAction();
//        private readonly static BLL.Flow.Action action1 = new BLL.Flow.Action();


//        [AllowAnonymous]
//        public Model.FlowAction Get(int id)
//        {
//            return action.Get(id);
//        }

//        /// <summary>
//        /// 根据节点ID查找行为信息
//        /// </summary>
//        /// yand    15.12.01
//        /// <param name="Node_ID"></param>
//        /// <returns></returns>
//        [HttpGet]
//        public List<Model.FlowAction> FindByNode_ID(int Node_ID)
//        {

//            List<Model.FlowAction> Action = action1.FindByNode(Node_ID);

//            return Action;
//        }
//    }
//}