using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;
using Model.Credit;

namespace DAL.Credit
{
	public class CreditInfoMapper : AbstractMapper<CreditInfo>
	{
		/// <summary>
		/// 查找
		/// </summary>
		/// qiy		16.03.29
		/// <param name="id">标识</param>
		/// <returns></returns>
		public CreditInfo Find(int id)
		{
			string findStatement =
				"SELECT CreditId, Name, Type, LineOfCredit, AddDate, Remarks FROM CRET_CreditInfo WHERE CreditId = @ID";

			return AbstractFind(findStatement, id);
		}

		/// <summary>
		/// 查询选项
		/// </summary>
		/// qiy		16.03.29
		/// <returns></returns>
		public List<ComboInfo> Option()
		{
			List<ComboInfo> list = new List<ComboInfo>();

			SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT CreditId, Name FROM CRET_CreditInfo
            ");

			DataTable dt = DHelper.ExecuteDataTable(comm);

			foreach (DataRow dr in dt.Rows)
			{
				list.Add(new ComboInfo(dr[0].ToString(), dr[1].ToString()));
			}

			return list;
		}

		/// <summary>
		/// 插入
		/// </summary>
		/// qiy		16.03.29
		/// <param name="value">值</param>
		public void Insert(CreditInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO CRET_CreditInfo (Name, Type, LineOfCredit, AddDate, Remarks) 
				VALUES (@Name, @Type, @LineOfCredit, DEFAULT, @Remarks) SELECT SCOPE_IDENTITY()
			");
			DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
			DHelper.AddParameter(comm, "@Type", SqlDbType.TinyInt, value.Type);
			DHelper.AddParameter(comm, "@LineOfCredit", SqlDbType.Decimal, value.LineOfCredit);
			DHelper.AddParameter(comm, "@Remarks", SqlDbType.NVarChar, value.Remarks);

			value.CreditId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// qiy		16.03.29
		/// <param name="value">值</param>
		/// <returns></returns>
		public int Update(CreditInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
				UPDATE CRET_CreditInfo SET 
					Name = @Name,
					Type = @Type, 
					LineOfCredit = @LineOfCredit, 
					Remarks = @Remarks 
				WHERE CreditId = @CreditId
			");
			DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, value.CreditId);

			DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
			DHelper.AddParameter(comm, "@Type", SqlDbType.TinyInt, value.Type);
			DHelper.AddParameter(comm, "@LineOfCredit", SqlDbType.Decimal, value.LineOfCredit);
			DHelper.AddParameter(comm, "@Remarks", SqlDbType.NVarChar, value.Remarks);

			return DHelper.ExecuteNonQuery(comm);
		}
	}
}
