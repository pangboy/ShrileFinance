namespace Core.Entities
{
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// 用户
    /// </summary>
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
        }

        public string Name { get; set; }
    }
}
