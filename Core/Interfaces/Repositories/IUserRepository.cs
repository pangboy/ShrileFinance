namespace Core.Interfaces.Repositories
{
    using Entities;

    /// <summary>
    /// 用户仓储
    /// </summary>
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        bool UsernameExists(string username);
    }
}
