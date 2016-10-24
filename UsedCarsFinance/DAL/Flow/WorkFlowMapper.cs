using System;
using System.Data;
using System.Data.SqlClient;
using Models.Flow;

namespace DAL.Flow
{
	public class WorkFlowMapper : AbstractMapper<FlowInfo>
	{
		/// <summary>
		/// 查找[未使用]
		/// </summary>
		/// qiy		16.03.08
		/// <param name="id">标识</param>
		/// <returns></returns>
		public FlowInfo Find(int id)
		{
			string findStatement =
                "SELECT FlowId, Name, Description FROM FLOW_WorkFlow WHERE FlowId = @ID";

			return AbstractFind(findStatement, id);
		}

		/// <summary>
		/// 插入[未使用]
		/// </summary>
		/// qiy		16.03.08
		/// <param name="value"></param>
		/// <returns></returns>
		public void Insert(FlowInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"INSERT INTO FLOW_WorkFlow (Name, Description) " +
				"VALUES (@Name, @Description) SELECT SCOPE_IDENTITY() "
				);
			DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
			DHelper.AddParameter(comm, "@Description", SqlDbType.NVarChar, value.Description);

			value.FlowId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
		}
	}
}
