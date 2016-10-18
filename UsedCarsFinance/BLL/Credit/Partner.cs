using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Model.Credit;

namespace BLL.Credit
{
	public class Partner : Credit
	{
		private readonly static DAL.Credit.PartnerInfoMapper partnerMapper = new DAL.Credit.PartnerInfoMapper();

		/// <summary>
		/// 获取渠道主体
		/// </summary>
		/// qiy		16.03.29
		/// <param name="creditId">授信主体标识</param>
		/// <returns></returns>
		public new PartnerInfo Get(int creditId)
		{
			PartnerInfo partner = partnerMapper.Find(creditId);

			if (partner != null)
				Model.ConvertHelper.Copy(base.Get(creditId), partner);

			return partner;
		}

		/// <summary>
		/// 添加渠道主体
		/// </summary>
		/// qiy		16.03.29
		/// <param name="value">值</param>
		/// <returns></returns>
		public bool Add(PartnerInfo value)
		{
			bool result = true;

			using (TransactionScope scope = new TransactionScope())
			{
				result &= base.Add(value);

				if (result)
					partnerMapper.Insert(value);

				if (result)
					scope.Complete();
			}

			return result;
		}

		/// <summary>
		/// 修改渠道主体
		/// </summary>
		/// qiy		16.03.29
		/// <param name="value">值</param>
		/// <returns></returns>
		public bool Modify(PartnerInfo value)
		{
			bool result = true;
			PartnerInfo partner = Get(value.CreditId);

			if (partner == null) return false;

			partner.Bail = value.Bail;
			partner.Address = value.Address;
			partner.ProxyArea = value.ProxyArea;
			partner.VehicleManage = value.VehicleManage;
			partner.ControllerName = value.ControllerName;
			partner.ControllerIdentity = value.ControllerIdentity;
			partner.ControllerTelephone = value.ControllerTelephone;
            partner.Province = value.Province;
            partner.City = value.City;

			using (TransactionScope scpoe = new TransactionScope())
			{
				result &= base.Modify(value);

				result &= partnerMapper.Update(partner) > 0;

				if (result)
					scpoe.Complete();
			}

			return result;
		}

		/// <summary>
		/// 分页查询
		/// </summary>
		/// qiy		16.03.29
		/// <param name="page">分页信息</param>
		/// <param name="filter">筛选条件</param>
		/// <returns></returns>
		public System.Data.DataTable List(Model.Pagination page, NameValueCollection filter)
		{
			return partnerMapper.List(page, filter);
		}
	}
}
