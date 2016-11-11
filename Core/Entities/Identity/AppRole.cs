namespace Core.Entities.Identity
{
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// 角色
    /// </summary>
    public class AppRole : IdentityRole
    {
        public AppRole()
        {
        }

        public int Power { get; set; }
    }
}
