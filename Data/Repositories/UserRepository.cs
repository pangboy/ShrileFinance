namespace Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using Core.Entities;
    using Core.Interfaces.Repositories;

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MyContext context) : base(context)
        {
        }

        public bool UsernameExists(string username)
        {
            return Entities.Count(m => m.Username == username) > 0;
        }
    }
}
