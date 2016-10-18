//using Model;
//using Model.Flow;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace Web.Controllers
//{
//	public class FlowTesterController : ApiController
//	{
//		private readonly static TSL.CreditScript creditScript = new TSL.CreditScript();

//		[HttpGet]
//		public IHttpActionResult Test(int InstanceId, int ActionId, int FindUserValue)
//		{
//			FlowData<CreditInfo> data = new FlowData<CreditInfo>()
//			{
//				FData = new FlowData()
//				{
//					InstanceId = InstanceId,
//					ActionId = ActionId,
//					FindUserValue = FindUserValue
//				}
//			};

//			//creditScript.授信申请(data);
//			//creditScript.审批(data.FData);
//            //creditScript.分配(data.FData);

//			return Ok();
//		}
//	}
//}
