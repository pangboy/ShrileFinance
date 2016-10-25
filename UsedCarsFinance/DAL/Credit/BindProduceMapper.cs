using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Credit
{
	public class BindProduceMapper : AbstractMapper<Object>
	{
		/// <summary>
		/// 通过授信主体查找
		/// </summary>
		/// qiy		16.03.30
		/// <param name="creditId">授信主体标识</param>
		/// <returns></returns>
		public List<int> FindByCredit(int creditId)
		{
			List<int> result = new List<int>();

			SqlCommand comm = DHelper.GetSqlCommand(
				"SELECT ProduceId FROM CRET_BindProduce WHERE CreditId = @CreditId"
			);

			DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, creditId);

			DataTable dt = DHelper.ExecuteDataTable(comm);

			foreach (DataRow dr in dt.Rows)
			{
				result.Add(Convert.ToInt32(dr[0]));
			}

			return result;
		}

		/// <summary>
		/// 批量插入
		/// </summary>
		/// qiy		16.03.30
		/// <param name="creditId">授信主体标识</param>
		/// <param name="produces">产品列表</param>
		/// <returns></returns>
		public int InsertByCredit(int creditId, List<Models.Produce.ProduceInfo> produces)
		{
			SqlCommand comm = DHelper.GetSqlCommand(string.Empty);
			DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, creditId);

			StringBuilder commStr = new StringBuilder();

			for (int i = 0; i < produces.Count; i++)
			{
				commStr.AppendFormat("INSERT INTO CRET_BindProduce (CreditId, ProduceId) VALUES (@CreditId, @ProduceId{0});", i);
				DHelper.AddParameter(comm, "@ProduceId" + i, SqlDbType.Int, produces[i].ProduceId);
			}

			comm.CommandText = commStr.ToString();

			return DHelper.ExecuteNonQuery(comm);
		}

		/// <summary>
		/// 通过授信主体删除
		/// </summary>
		/// qiy		16.03.30
		/// <param name="creditId"></param>
		/// <returns></returns>
		public void DeleteByCredit(int creditId)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"DELETE CRET_BindProduce WHERE CreditId = @CreditId"
			);
			DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, creditId);

			DHelper.ExecuteNonQuery(comm);
		}
	}
}
