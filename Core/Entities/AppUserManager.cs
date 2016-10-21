namespace Core.Entities
{
    using Microsoft.AspNet.Identity;

    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        {
        }
    }
}
