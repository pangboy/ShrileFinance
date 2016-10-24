using Models.Credit;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Credit
{
    public class PartnerInfoMapper : AbstractMapper<PartnerInfo>
    {
        /// <summary>
        /// 查找
        /// </summary>
        /// qiy		16.03.29
        /// cais    16.05.09
        /// <param name="id">标识</param>
        /// <returns></returns>
        public PartnerInfo Find(int creditId)
        {
            string findStatement =
                "SELECT CreditId, Bail, Address, ProxyArea, VehicleManage, ControllerName, ControllerIdentity, ControllerTelephone,Province,City FROM CRET_PartnerInfo WHERE CreditId = @ID";

            return AbstractFind(findStatement, creditId);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// qiy		16.03.29
        /// <param name="value">值</param>
        public void Insert(PartnerInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO CRET_PartnerInfo (CreditId, Bail, Address, ProxyArea, VehicleManage, ControllerName, ControllerIdentity, ControllerTelephone ,Province,City )
				VALUES (@CreditId, @Bail, @Address, @ProxyArea, @VehicleManage, @ControllerName, @ControllerIdentity, @ControllerTelephone ,@Province,@City)
			");
            DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, value.CreditId);
            DHelper.AddParameter(comm, "@Bail", SqlDbType.Decimal, value.Bail);
            DHelper.AddParameter(comm, "@Address", SqlDbType.NVarChar, value.Address);
            DHelper.AddParameter(comm, "@ProxyArea", SqlDbType.NVarChar, value.ProxyArea);
            DHelper.AddParameter(comm, "@VehicleManage", SqlDbType.NVarChar, value.VehicleManage);
            DHelper.AddParameter(comm, "@ControllerName", SqlDbType.NVarChar, value.ControllerName);
            DHelper.AddParameter(comm, "@ControllerIdentity", SqlDbType.NVarChar, value.ControllerIdentity);
            DHelper.AddParameter(comm, "@ControllerTelephone", SqlDbType.NVarChar, value.ControllerTelephone);
            DHelper.AddParameter(comm, "@Province", SqlDbType.NVarChar, value.Province);
            DHelper.AddParameter(comm, "@City", SqlDbType.NVarChar, value.City);

            DHelper.ExecuteNonQuery(comm);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// qiy		16.03.29
        /// <param name="value">值</param>
        /// <returns></returns>
        public int Update(PartnerInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				UPDATE CRET_PartnerInfo SET
					Bail = @Bail,
					Address = @Address,
					ProxyArea = @ProxyArea,
					VehicleManage = @VehicleManage,
					ControllerName = @ControllerName,
					ControllerIdentity = @ControllerIdentity,
					ControllerTelephone = @ControllerTelephone,
                    Province=@Province,
                    City=@City

				WHERE CreditId = @CreditId
			");
            DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, value.CreditId);

            DHelper.AddParameter(comm, "@Bail", SqlDbType.Decimal, value.Bail);
            DHelper.AddParameter(comm, "@Address", SqlDbType.NVarChar, value.Address);
            DHelper.AddParameter(comm, "@ProxyArea", SqlDbType.NVarChar, value.ProxyArea);
            DHelper.AddParameter(comm, "@VehicleManage", SqlDbType.NVarChar, value.VehicleManage);
            DHelper.AddParameter(comm, "@ControllerName", SqlDbType.NVarChar, value.ControllerName);
            DHelper.AddParameter(comm, "@ControllerIdentity", SqlDbType.NVarChar, value.ControllerIdentity);
            DHelper.AddParameter(comm, "@ControllerTelephone", SqlDbType.NVarChar, value.ControllerTelephone);
            DHelper.AddParameter(comm, "@Province", SqlDbType.NVarChar, value.Province);
            DHelper.AddParameter(comm, "@City", SqlDbType.NVarChar, value.City);

            return DHelper.ExecuteNonQuery(comm);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// qiy		16.03.29
        /// <param name="page">分页信息</param>
        /// <param name="filter">筛选条件</param>
        /// <returns></returns>
        public DataTable List(Models.Pagination page, NameValueCollection filter)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				SELECT tmp.rownum, ci.CreditId,
					ci.Name, ci.Type, dbo.Dic(4, ci.Type) AS TypeDesc, ci.LineOfCredit, ci.AddDate, ci.Remarks,
					cpi.Bail, cpi.ControllerName, cpi.ControllerTelephone
				FROM CRET_CreditInfo AS ci
					RIGHT JOIN (
						SELECT TOP (@End) ROW_NUMBER() OVER (ORDER BY CreditId DESC) AS rownum, CreditId FROM CRET_CreditInfo
					) AS tmp ON ci.CreditId = tmp.CreditId
					LEFT JOIN CRET_PartnerInfo AS cpi ON ci.CreditId = cpi.CreditId
				WHERE tmp.rownum > @Begin
			");
            DHelper.AddParameter(comm, "@Begin", SqlDbType.Int, page.Begin);
            DHelper.AddParameter(comm, "@End", SqlDbType.Int, page.End);

            SqlCommand commPage = DHelper.GetSqlCommand(@"
				SELECT COUNT(*) FROM CRET_CreditInfo
			");

            page.Total = Convert.ToInt32(DHelper.ExecuteScalar(commPage));

            return DHelper.ExecuteDataTable(comm);
        }
    }
}