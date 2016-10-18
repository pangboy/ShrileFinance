//using Model;
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web;
//using System.Web.Http;

//namespace Web.Controllers
//{
//    public class InstanceController : ApiController
//    {
//        private readonly static BLL.Flow.FlowInstance instance = new BLL.Flow.FlowInstance();

//        /// <summary>
//        /// 获取当前用户ID
//        /// </summary>
//        /// yand    15.11.27
//        public static int CurrentUserId
//        {
//            get { return Convert.ToInt32(HttpContext.Current.User.Identity.Name); }
//        }

//        /// <summary>
//        /// 获取代办列表
//        /// </summary>
//        /// yand    15.11.27
//        /// <param name="page"></param>
//        /// <param name="rows"></param>
//        /// <returns></returns>
//        [HttpGet]
//        public Datagrid FindDoingList(int page, int rows)
//        {
//            Pagination pagination = new Pagination(page, rows);
//            NameValueCollection filter = ApiHelper.GetParameters();

//            filter.Add("status", Convert.ToString((int)FlowStatus.流转));
//            filter.Add("userId", CurrentUserId.ToString());

//            return new Datagrid
//            {
//                rows = instance.FindDoingList(pagination, filter),
//                total = pagination.Total
//            };
//        }

//        /// <summary>
//        /// 获取已办列表
//        /// </summary>
//        /// yand    15.11.27
//        /// <param name="page"></param>
//        /// <param name="rows"></param>
//        /// <returns></returns>
//        [HttpGet]
//        public Datagrid FindDoneList(int page, int rows)
//        {
//            Pagination pagination = new Pagination(page, rows);
//            NameValueCollection filter = ApiHelper.GetParameters();

//            filter.Add("userId", CurrentUserId.ToString());

//            return new Datagrid
//            {
//                rows = instance.FindDoneList(pagination, filter),
//                total = pagination.Total
//            };
//        }
//    }
//}
