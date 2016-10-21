namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    //using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;
    //using Microsoft.Owin.Security.OAuth;
    using Core.Entities;

    public class TestController : ApiController
    {
        private readonly AppUserManager manager;

        public TestController(AppUserManager manager)
        {
            this.manager = manager;
        }

        [AllowAnonymous]
        public async Task<IHttpActionResult> Login(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await manager.FindAsync("admin", "admin");

            if (user == null)
            {
                return BadRequest("Invalid name or password.");
            }

            ClaimsIdentity ident = await manager.CreateIdentityAsync(user,
                DefaultAuthenticationTypes.ApplicationCookie);

            //AuthManager.SignOut();
            //AuthManager.SignIn(new AuthenticationProperties {
            //    IsPersistent = false
            //}, ident);

            return Ok();
        }
    }
}
