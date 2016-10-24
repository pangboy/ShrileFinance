using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace DAL.User
{
	public class PermissionsMapper : AbstractMapper<MenuPermissionsInfo>
    {
		/// <summary>
		/// 通过角色查找
		/// </summary>
		/// qiy		16.03.08
		/// <param name="roleId"></param>
		/// <returns></returns>
		public List<int> FindByRole(int roleId)
		{
			List<int> result = new List<int>();

			SqlCommand comm = DHelper.GetSqlCommand(
				"SELECT MenuId FROM USER_Permissions WHERE RoleId = @RoleId"
			);

			DHelper.AddParameter(comm, "@RoleId", SqlDbType.Int, roleId);

			DataTable dt = DHelper.ExecuteDataTable(comm);

			foreach (DataRow dr in dt.Rows)
			{
				result.Add(Convert.ToInt32(dr[0]));
			}

			return result;
		}

        /// <summary>
        /// 批量插入权限列表
        /// </summary>
        /// qiy     15.11.26
        /// <param name="value"></param>
        /// <returns></returns>
        public int Insert(MenuPermissionsInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(string.Empty);
            DHelper.AddParameter(comm, "@RoleId", SqlDbType.Int, value.RoleId);

            StringBuilder commStr = new StringBuilder();

            for (int i = 0; i < value.Menus.Count; i++)
            {
                commStr.AppendFormat("INSERT INTO USER_Permissions (RoleId, MenuId) VALUES (@RoleId, @MenuId{0});", i);
                DHelper.AddParameter(comm, "@MenuId" + i, SqlDbType.Int, value.Menus[i]);
            }

            comm.CommandText = commStr.ToString();

            return DHelper.ExecuteNonQuery(comm);
        }

		/// <summary>
		/// 通过角色删除
		/// </summary>
		/// yaoy    15.11.26
		/// qiy		16.03.08
		/// <param name="roleId"></param>
		/// <returns></returns>
		public void DeleteByRole(int roleId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(
				"DELETE USER_Permissions WHERE RoleId = @RoleId"
				);
            DHelper.AddParameter(comm, "@RoleId", SqlDbType.Int, roleId);

            DHelper.ExecuteNonQuery(comm);
        }

		/// <summary>
		/// 通过菜单删除
		/// </summary>
		/// yand	15.11.24
		/// qiy		16.03.08
		/// <param name="menuId"></param>
		/// <returns></returns>
		public void DeleteByMenu(int menuId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(
				"DELETE USER_Permissions WHERE MenuId = @MenuId"
				);
            DHelper.AddParameter(comm, "@MenuId", SqlDbType.Int, menuId);

            DHelper.ExecuteNonQuery(comm);
        }
    }
}
