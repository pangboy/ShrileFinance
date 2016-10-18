//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace Web.Controllers
//{
//    public class AuditOpinionController : ApiController
//    {
//        private readonly static BLL.Flow.FlowAuditOpinion auditopinion = new BLL.Flow.FlowAuditOpinion();

//        /// <summary>
//        /// 查找审核意见通过实例ID
//        /// </summary>
//        /// yand    15.12.07
//        /// <param name="Instance_id"></param>
//        /// <returns></returns>
//        [HttpGet]
//        public DataTable FindByInstance_id(int Instance_id)
//        {
//            return auditopinion.FindByInstance_id(Instance_id);
//        }
//    }
//}
