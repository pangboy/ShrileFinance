using System.Collections.Generic;
using Models;
using Models.User;

namespace BLL.User
{
	public class Role
    {
        private readonly static DAL.User.RoleMapper roleMapper = new DAL.User.RoleMapper();

        /// <summary>
        /// 获取所有角色列表
        /// </summary>
        /// yaoy    15.11.25
        /// <returns></returns>
        public List<ComboInfo> Option()
        {
			RoleInfo role = new Role().Get(new User().CurrentUser().RoleId);

            return roleMapper.Option(role.Power);
        }

        /// <summary>
        /// 通过id查询
        /// </summary>
        /// yaoy    15.11.25
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleInfo Get(int id)
        {
            return roleMapper.Find(id);
        }
    }
}
