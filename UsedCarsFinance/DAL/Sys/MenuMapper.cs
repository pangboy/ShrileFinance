using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;
using Models.Sys;

namespace DAL.Sys
{
	public class MenuMapper : AbstractMapper<MenuInfo>
	{
		/// <summary>
		/// 查询菜单
		/// </summary>
		/// yand    15.11.16
		/// qiy		16.03.08
		/// <param name="id">标识</param>
		/// <returns></returns>
		public MenuInfo Find(int id)
		{
			string findStatement =
				"SELECT MN_ID, ParentId, Name, Link, Sort FROM SYS_Menu WHERE MN_ID = @ID";

			return AbstractFind(findStatement, id);
		}

		/// <summary>
		/// 查询所有列表
		/// </summary>
		/// yand    15.11.24
		/// qiy		16.03.08
		/// <returns></returns>
		public List<MenuInfo> FindALL()
		{
			List<MenuInfo> result = new List<MenuInfo>();

			SqlCommand comm = DHelper.GetSqlCommand(
				@"SELECT MN_ID, ParentId, Name, Link, Sort FROM SYS_Menu WHERE Sort <> 255 ORDER BY Sort"
			);

			return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
		}

		/// <summary>
		/// 查找子菜单的数量
		/// </summary>
		/// qiy		16.03.09
		/// <param name="menuId">菜单标识</param>
		/// <returns></returns>
		public int CountChildren(int menuId)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"SELECT COUNT(*) FROM SYS_Menu WHERE ParentId = @ParentId"
				);
			DHelper.AddParameter(comm, "@ParentId", SqlDbType.Int, menuId);

			return Convert.ToInt32(DHelper.ExecuteScalar(comm));
		}

		/// <summary>
		/// 插入
		/// </summary>
		/// yand    15.11.16
		/// qiy		16.03.08
		/// <param name="value"></param>
		/// <returns></returns>
		public void Insert(MenuInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"INSERT INTO SYS_Menu (ParentId, Name, Link, Sort) " +
				"VALUES (@ParentId, @Name, @Link, @Sort) SELECT SCOPE_IDENTITY() "
				);

			DHelper.AddParameter(comm, "@ParentId", SqlDbType.Int, value.ParentId);
			DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
			DHelper.AddParameter(comm, "@Link", SqlDbType.NVarChar, value.Link);
			DHelper.AddParameter(comm, "@Sort", SqlDbType.TinyInt, value.Sort);

			value.MenuId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
		}

		/// <summary>
		/// 更新记录
		/// </summary>
		/// yand	15.11.16
		/// qiy		16.03.08
		/// <param name="menuId">标识</param>
		/// <param name="value">值</param>
		/// <returns></returns>
		public bool Update(MenuInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				@"UPDATE SYS_Menu SET 
                    ParentId=@ParentId, 
					Name = @Name, 
					Link = @Link, 
                    Sort = @Sort 
				WHERE MN_ID = @MenuId
				");
			DHelper.AddParameter(comm, "@MenuId", SqlDbType.Int, value.MenuId);

			DHelper.AddParameter(comm, "@ParentId", SqlDbType.Int, value.ParentId);
			DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
			DHelper.AddParameter(comm, "@Link", SqlDbType.NVarChar, value.Link);
			DHelper.AddParameter(comm, "@Sort", SqlDbType.TinyInt, value.Sort);

			return DHelper.ExecuteNonQuery(comm) > 0;
		}

		/// <summary>
		/// 删除菜单
		/// </summary>
		/// yand    15.11.24
		/// <param name="menuId"></param>
		/// <returns></returns>
		public void Delete(int menuId)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"Delete SYS_Menu WHERE MN_ID = @MenuId"
				);
			DHelper.AddParameter(comm, "@MenuId", SqlDbType.Int, menuId);

			DHelper.ExecuteNonQuery(comm);
		}

		/// <summary>
		/// 查询菜单列表
		/// </summary>
		/// yand    15.11.24
		/// <returns></returns>
		public DataTable MenuList()
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				@"SELECT sm.MN_ID, sm.ParentId, sm.Name, smp.Name AS ParentName, sm.Link, sm.Sort FROM SYS_Menu AS sm
	                LEFT JOIN SYS_Menu AS smp ON sm.ParentId = smp.MN_ID
                WHERE sm.Sort <> 255
	                ORDER BY smp.Sort, smp.MN_ID, sm.Sort, sm.MN_ID
			");

			return DHelper.ExecuteDataTable(comm);
		}

		/// <summary>
		/// 查询父级菜单
		/// </summary>
		/// yand    15.11.24
		/// <returns></returns>
		public List<ComboInfo> GetPanrent()
		{
			List<ComboInfo> Parent = new List<ComboInfo>();

			SqlCommand comm = DHelper.GetSqlCommand(
			   @"SELECT MN_ID, Name FROM SYS_Menu WHERE ParentId IS NULL
			");

			DataTable dt = DHelper.ExecuteDataTable(comm);

			foreach (DataRow dr in dt.Rows)
			{
				ComboInfo Parents = new ComboInfo(dr["MN_ID"].ToString(), dr["Name"].ToString());

				Parent.Add(Parents);
			}

			return Parent;
		}

	}
}
