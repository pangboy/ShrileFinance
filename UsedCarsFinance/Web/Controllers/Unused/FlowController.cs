//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace Web.Controllers
//{
//    public class FlowController : ApiController
//    {
//        private readonly static BLL.Flow.Flow flow = new BLL.Flow.Flow();
//        /// <summary>
//        /// 根据实例id查询信息用于判断框架页是否显示信息
//        /// </summary>
//        /// yand    15.12.03
//        /// <param name="Instance_id">实例ID</param>
//        /// <returns></returns>
//        [HttpGet]
//        public object FindByInstance_id(int Instance_id)
//        {
//            return flow.FindByInstance_id(Instance_id);
//        }

//    }
//}
