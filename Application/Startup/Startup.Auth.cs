namespace Application
{
	using Microsoft.AspNet.Identity;
	using Microsoft.Owin;
	using Microsoft.Owin.Security.Cookies;
	using Owin;
	using User;

	public partial class Startup
    {
		public void ConfigureAuth(IAppBuilder app)
		{
			// Enable the application to use a cookie to store information for the signed in user
			app.UseCookieAuthentication(new CookieAuthenticationOptions {
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Account/Login")
			});
		}
    }
}

namespace Application.User
{
	using Core.Entities;
	using Data;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using Microsoft.AspNet.Identity.Owin;
	using Microsoft.Owin;

	public class AppUserManager : UserManager<ApplicationUser>
	{
		public AppUserManager(IUserStore<ApplicationUser> store) : base(store) { }

		public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
		{
			var db = context.Get<MyContext>();
			AppUserManager manager = new AppUserManager(new UserStore<ApplicationUser>(db));

			manager.UserValidator = new UserValidator<ApplicationUser>(manager) {
				AllowOnlyAlphanumericUserNames = true,
				RequireUniqueEmail = false
			};
			manager.PasswordValidator = new PasswordValidator {
				RequiredLength = 6,
				RequireNonLetterOrDigit = false,
				RequireDigit = false,
				RequireLowercase = false,
				RequireUppercase = false
			};

			return manager;
		}
	}
}
