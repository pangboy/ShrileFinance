//using Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using BLL.WorkFlowCore;

//namespace Web.Controllers
//{
//    public class WorkFlowController : ApiController
//    {
//        // GET api/<controller>
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<controller>/5
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<controller>
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/<controller>/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/<controller>/5
//        public void Delete(int id)
//        {
//        }
//        [HttpGet]
//        public IHttpActionResult Start(int workFlowId)
//        {
//            WorkFlowEngine workFlowEngine = new WorkFlowEngine(new Process());
//            bool result = workFlowEngine.StartProcess(workFlowId,BLL.User.User.CurrentUserId, "{\"ID\":1}");
//            return result ? (IHttpActionResult)Ok() : BadRequest("发起流程失败!");
//        }
//        [HttpGet]
//        [AllowAnonymous]
//        public IHttpActionResult Submit(int actionId,int instanceId)
//        {
//            WorkFlowEngine workFlowEngine = new WorkFlowEngine(new Process());
//            bool result = workFlowEngine.ContinueProcess(actionId,instanceId,BLL.User.User.CurrentUserId);
//            return result ? (IHttpActionResult)Ok() : BadRequest("更新流程失败!");
//        }

//        /// <summary>
//        /// 分配测试
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet]
//        [AllowAnonymous]
//        public IHttpActionResult Point(int actionId,int instanceId,int pointId)
//        {
//            WorkFlowEngine workFlowEngine = new WorkFlowEngine(new Process());
//            bool result = workFlowEngine.ContinueProcess(actionId, instanceId, BLL.User.User.CurrentUserId, pointId);
//            return result ? (IHttpActionResult)Ok() : BadRequest("分配流程失败!");
//        }

//        [HttpGet]
//        public int GetMessage()
//        {
//            WorkFlowEngine workFlowEngine = new WorkFlowEngine(new Process());
//            return workFlowEngine.GetMessageAlerts(BLL.User.User.CurrentUserId);
//        }
//    }
//}