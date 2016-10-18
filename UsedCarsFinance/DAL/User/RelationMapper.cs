using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.User
{
	public class RelationMapper : AbstractMapper<object>
	{
		/// <summary>
		/// 通过用户查找
		/// </summary>
		/// qiy		16.03.09
		/// <param name="userId">用户标识</param>
		/// <returns></returns>
		public List<int> FindByUser(int userId)
		{
			List<int> result = new List<int>();

			SqlCommand comm = DHelper.GetSqlCommand(
				"SELECT RoleId FROM USER_Relation WHERE UserId = @UserId"
			);

			DHelper.AddParameter(comm, "@UserId", SqlDbType.Int, userId);

			DataTable dt = DHelper.ExecuteDataTable(comm);

			foreach (DataRow dr in dt.Rows)
			{
				result.Add(Convert.ToInt32(dr[0]));
			}

			return result;
		}


		/// <summary>
		/// 批量插入关系
		/// </summary>
		/// qiy		16.03.09
		/// <param name="userId">用户标识</param>
		/// <param name="roles">角色列表</param>
		/// <returns></returns>
		public int InserByUser(int userId, List<int> roles)
		{
			SqlCommand comm = DHelper.GetSqlCommand(string.Empty);
			DHelper.AddParameter(comm, "@UserId", SqlDbType.Int, userId);

			StringBuilder commStr = new StringBuilder();

			for (int i = 0; i < roles.Count; i++)
			{
				commStr.AppendFormat("INSERT INTO USER_Relation (UserId, RoleId) VALUES (@UserId, @RoleId{0});", i);
				DHelper.AddParameter(comm, "@RoleId" + i, SqlDbType.Int, roles[i]);
			}

			comm.CommandText = commStr.ToString();

			return DHelper.ExecuteNonQuery(comm);
		}

		/// <summary>
		/// 通过用户删除
		/// </summary>
		/// qiy		16.03.09
		/// <param name="userId">用户标识</param>
		/// <returns></returns>
		public void DeleteByUser(int userId)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"DELETE USER_Relation WHERE UserId = @UserId"
				);
			DHelper.AddParameter(comm, "@UserId", SqlDbType.Int, userId);

			DHelper.ExecuteNonQuery(comm);
		}
	}
}
