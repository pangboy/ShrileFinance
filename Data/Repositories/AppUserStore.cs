namespace Data.Repositories
{
    using Core.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AppUserStore : UserStore<AppUser>
    {
        public AppUserStore(MyContext context) : base(context)
        {
        }
    }
}
