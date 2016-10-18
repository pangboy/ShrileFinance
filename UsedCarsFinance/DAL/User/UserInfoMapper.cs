using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using Model.User;

namespace DAL.User
{
	public class UserInfoMapper : AbstractMapper<UserInfo>
	{
		/// <summary>
		/// 分页查询
		/// </summary>
		/// qiy		15.11.17
		/// qiy		16.03.07
		/// <param name="page">分页信息</param>
		/// <param name="filter">筛选条件</param>
		/// <returns></returns>
		public DataTable List(Model.Pagination page, NameValueCollection filter)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				@"SELECT tmp.rownum, ui.UI_ID,
					ui.Username, ui.RealName, ui.Email, ui.Mobile, ui.Status, dbo.Dic(2, ui.Status) AS StatusDesc, ui.RegisterDate, ui.Remarks,
					ur.UR_ID AS RoleId, ur.Name AS RoleName
				FROM USER_UserInfo AS ui
					RIGHT JOIN (SELECT TOP (@End) ROW_NUMBER() OVER (ORDER BY UI_ID DESC) AS rownum, UI_ID FROM USER_UserInfo
						WHERE (@RoleId IS NULL OR UI_ID IN (SElECT UI_ID FROM USER_Permissions WHERE RoleId = @RoleId))
							AND (@RealName IS NULL OR RealName Like '%'+@RealName+'%')
					) AS tmp ON ui.UI_ID = tmp.UI_ID
					LEFT JOIN USER_Relation AS ure ON ure.UserId = ui.UI_ID
					LEFT JOIN USER_Role AS ur ON ur.UR_ID = ure.RoleId
				WHERE tmp.rownum > @Begin
			");
			DHelper.AddParameter(comm, "@Begin", SqlDbType.Int, page.Begin);
			DHelper.AddParameter(comm, "@End", SqlDbType.Int, page.End);

			DHelper.AddParameter(comm, "@RoleId", SqlDbType.Int, filter["RoleId"]);
			DHelper.AddParameter(comm, "@RealName", SqlDbType.NVarChar, filter["RealName"]);


			SqlCommand commPage = DHelper.GetSqlCommand(
				@"SELECT COUNT(*) FROM USER_UserInfo 
					WHERE (@RoleId IS NULL OR UI_ID IN (SElECT UI_ID FROM USER_Permissions WHERE RoleId = @RoleId))
						AND (@RealName IS NULL OR RealName Like '%'+@RealName+'%')
			");
			DHelper.AddParameter(commPage, "@RoleId", SqlDbType.Int, filter["RoleId"]);
			DHelper.AddParameter(commPage, "@RealName", SqlDbType.NVarChar, filter["RealName"]);

			page.Total = Convert.ToInt32(DHelper.ExecuteScalar(commPage));

			return DHelper.ExecuteDataTable(comm);
		}

		/// <summary>
		/// 查找用户
		/// </summary>
		/// qiy		15.11.12
		/// qiy		16.03.07
		/// <param name="userId">标识</param>
		/// <returns></returns>
		public UserInfo Find(int userId)
		{
			string findStatement =
				"SELECT UI_ID, Username, Password, Realname, Email, Mobile, Status, RegisterDate, Remarks FROM USER_UserInfo WHERE UI_ID = @ID";

			//通用方法查找实体
			return AbstractFind(findStatement, userId);
		}

		/// <summary>
		/// 查找账户
		/// </summary>
		/// qiy		15.11.12
		/// <param name="username">用户名</param>
		/// <param name="password">密码(密文)</param>
		/// <returns></returns>
		public UserInfo FindByAccount(string username, string password)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"SELECT UI_ID, Username, Password, Realname, Email, Mobile, Status, RegisterDate, Remarks FROM USER_UserInfo WHERE Username = @Username AND Password = @Password"
				);
			DHelper.AddParameter(comm, "@Username", SqlDbType.NVarChar, username);
			DHelper.AddParameter(comm, "@Password", SqlDbType.NVarChar, password);

			DataTable dt = DHelper.ExecuteDataTable(comm);

			return Load(dt);
		}


        public UserInfo FindByRole(string role)
        {
            SqlCommand comm = DHelper.GetSqlCommand(
                @"SELECT UI_ID, Username, Password, Realname, Email, Mobile, Status, RegisterDate, Remarks FROM USER_UserInfo  AS uui
                        LEFT JOIN USER_Relation AS ur ON uui.UI_ID = ur.UserId
                        LEFT JOIN USER_Role AS r ON r.UR_ID = ur.RoleId
                WHERE r.Name = @Name"
                );
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, role);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return Load(dt);
        }
        /// <summary>
        /// 查找用户名
        /// </summary>
        /// qiy		15.11.25
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public int FindByUsername(string username)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"SELECT COUNT(*) FROM USER_UserInfo WHERE Username = @Username"
				);
			DHelper.AddParameter(comm, "@Username", SqlDbType.NVarChar, username);

			return Convert.ToInt32(DHelper.ExecuteScalar(comm));
		}

        /// <summary>
        /// 用户选项
        /// </summary>
        /// qiy     16.05.31
        /// <param name="roleId">角色标识</param>
        /// <returns></returns>
        public List<Model.ComboInfo> Option(int? roleId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(
                @"SELECT UI_ID, Realname FROM USER_UserInfo 
                    WHERE @RoleId IS NULL OR UI_ID IN (SELECT UserId FROM USER_Relation WHERE RoleId = @RoleId)
                ");
            DHelper.AddParameter(comm, "@RoleId", SqlDbType.Int, roleId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            var list = new List<Model.ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                var cbi = new Model.ComboInfo(dr[0].ToString(), dr[1].ToString());

                list.Add(cbi);
            }

            return list;
        }

		/// <summary>
		/// 插入记录
		/// </summary>
		/// qiy		15.11.13
		/// qiy		16.03.07
		/// <param name="value">值</param>
		/// <returns></returns>
		public void Insert(UserInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"INSERT INTO USER_UserInfo (Username, Password, Realname, Email, Mobile, Status, RegisterDate, Remarks) " +
				"VALUES (@Username, @Password, @Name, @Email, @Mobile, @Status, Default, @Remarks) SELECT SCOPE_IDENTITY() "
				);
			DHelper.AddParameter(comm, "@Username", SqlDbType.NVarChar, value.Username);
			DHelper.AddParameter(comm, "@Password", SqlDbType.NVarChar, value.Password);
			DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
			DHelper.AddParameter(comm, "@Email", SqlDbType.VarChar, value.Email);
			DHelper.AddParameter(comm, "@Mobile", SqlDbType.VarChar, value.Mobile);
			DHelper.AddParameter(comm, "@Status", SqlDbType.TinyInt, value.Status);
			DHelper.AddParameter(comm, "@Remarks", SqlDbType.NVarChar, value.Remarks);

			value.UserId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
		}

		/// <summary>
		/// 更新记录
		/// </summary>
		/// qiy		15.11.13
		/// qiy		16.03.07
		/// <param name="value">值</param>
		/// <returns></returns>
		public bool Update(UserInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				@"UPDATE USER_UserInfo SET 
					Password = @Password,
					Realname = @Name, 
					Email = @Email, 
					Mobile = @Mobile, 
					Status = @Status, 
					Remarks = @Remarks 
				WHERE UI_ID = @UserId
				");
			DHelper.AddParameter(comm, "@UserId", SqlDbType.Int, value.UserId);

			DHelper.AddParameter(comm, "@Password", SqlDbType.NVarChar, value.Password);
			DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
			DHelper.AddParameter(comm, "@Email", SqlDbType.VarChar, value.Email);
			DHelper.AddParameter(comm, "@Mobile", SqlDbType.VarChar, value.Mobile);
			DHelper.AddParameter(comm, "@Status", SqlDbType.TinyInt, value.Status);
			DHelper.AddParameter(comm, "@Remarks", SqlDbType.NVarChar, value.Remarks);

			return DHelper.ExecuteNonQuery(comm) > 0;
		}
	}
}
