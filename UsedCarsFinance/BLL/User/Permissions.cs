using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLL.User
{
	public class Permissions
	{
		private readonly static DAL.User.UserInfoMapper userMapper = new DAL.User.UserInfoMapper();
		private readonly static DAL.User.PermissionsMapper permissionsMapper = new DAL.User.PermissionsMapper();

		/// <summary>
		/// 权限保存
		/// </summary>
		/// yaoy    15.11.25
		/// qiy		15.12.30	修改保存权限的逻辑
		/// <param name="value"></param>
		/// <returns></returns>
		public bool MenuPermissionEdit(MenuPermissionsInfo value)
		{
			bool result = true;

			permissionsMapper.DeleteByRole(value.RoleId);

			if (value.Menus != null)
			{
				result &= permissionsMapper.Insert(value) > 0;
			}

			return result;
		}
	}
}
