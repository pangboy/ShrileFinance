namespace Core.Entities.Identity
{
    using Microsoft.AspNet.Identity;

    public class AppRoleManager : RoleManager<AppRole>
    {
        public AppRoleManager(IRoleStore<AppRole> store) : base(store)
        {
        }
    }
}
