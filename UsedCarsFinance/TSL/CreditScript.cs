using Model;
using Model.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TSL
{
	public class CreditScript
	{
		//private readonly static BLL.Flow.Flow _flow = new BLL.Flow.Flow();
		//private readonly static BLL.Flow.Engine _engine = new BLL.Flow.Engine();

		//public bool 授信申请(FlowData<CreditInfo> data)
		//{
		//	bool result = true;

		//	using (TransactionScope scope = new TransactionScope())
		//	{
		//		int creditId = 1;

		//		result &= creditId > 0;//保存授信信息	data.BData

		//		_engine.Start(data.FData);

		//		_flow.SetData(data.FData.InstanceId.Value, new { creditId = creditId });

		//		scope.Complete();
		//	}

		//	return result;
		//}

		//public bool 审批(FlowData data)
		//{
		//	bool result = true;

		//	using (TransactionScope scope = new TransactionScope())
		//	{
		//		_engine.Process(data);

		//		scope.Complete();
		//	}

		//	return result;
		//}

		//public bool 分配(FlowData data)
		//{
		//	bool result = true;

		//	using (TransactionScope scope = new TransactionScope())
		//	{
		//		_engine.Process(data);

		//		scope.Complete();
		//	}

		//	return result;
		//}
	}
}
