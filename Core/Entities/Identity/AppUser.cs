namespace Core.Entities
{
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// 用户
    /// </summary>
    public class AppUser : IdentityUser
    {
        public const string DEFAULTPASSWORD = "123456";

        public AppUser()
        {
        }

        public string Name { get; set; }
    }
}
