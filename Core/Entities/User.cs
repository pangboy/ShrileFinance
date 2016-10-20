namespace Core.Entities
{
    using System;
    using Interfaces;
	using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// 用户
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public string Name { get; set; }
    }
}
