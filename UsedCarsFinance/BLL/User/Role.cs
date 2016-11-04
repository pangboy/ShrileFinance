using Models.User;

namespace BLL.User
{
	public class Role
    {
        private readonly static DAL.User.RoleMapper roleMapper = new DAL.User.RoleMapper();

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
