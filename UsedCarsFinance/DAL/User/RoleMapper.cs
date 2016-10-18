using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;
using Model.User;

namespace DAL.User
{
	public class RoleMapper : AbstractMapper<RoleInfo>
	{
		/// <summary>
		/// 查找
		/// </summary>
		/// qiy		16.03.09
		/// <param name="id">标识</param>
		/// <returns></returns>
		public RoleInfo Find(int id)
		{
			string findStatement = "SELECT UR_ID, Name, Power FROM USER_Role WHERE UR_ID = @ID";

			return AbstractFind(findStatement, id);
		}

		/// <summary>
		/// 获取所有角色列表(Combo)
		/// </summary>
		/// yaoy    15.11.25 
		/// qiy		16.03.08
		/// <returns></returns>
		public List<ComboInfo> Option(byte power)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT UR_ID, Name FROM USER_Role WHERE Power >= @Power ORDER BY Sort
            ");
			DHelper.AddParameter(comm, "@Power", SqlDbType.TinyInt, power);

			DataTable dt = DHelper.ExecuteDataTable(comm);

			List<ComboInfo> list = new List<ComboInfo>();

			foreach (DataRow dr in dt.Rows)
			{
				ComboInfo cbi = new ComboInfo(dr["UR_ID"].ToString(), dr["Name"].ToString());

				list.Add(cbi);
			}

			return list;
		}
	}
}
