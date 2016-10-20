namespace Application
{
	using System.Reflection;
	using Autofac;
	using Core.Entities;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	public partial class Startup
	{
		public void ConfigureAutofac(ContainerBuilder builder)
		{
			builder.RegisterType<Data.MyContext>().AsSelf().InstancePerRequest();

			builder.RegisterAssemblyTypes(typeof(Data.Repositories.UserRepository).Assembly)
				.Where(m => m.Name.EndsWith("Repository"))
				.AsImplementedInterfaces()
				.InstancePerRequest();
			builder.RegisterAssemblyTypes(typeof(Core.Entities.ApplicationUser).Assembly)
				.Where(m => m.Name.EndsWith("Service"))
				.AsSelf()
				.InstancePerRequest();
			builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.Where(m => m.Name.EndsWith("AppService"))
				.AsSelf()
				.InstancePerRequest();

			builder.Register(c =>
				new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(c.Resolve<Data.MyContext>())) {
					UserValidator = new UserValidator<ApplicationUser>(this) {
						AllowOnlyAlphanumericUserNames = true,
						RequireUniqueEmail = false
					},
					PasswordValidator = new PasswordValidator {
						RequiredLength = 6,
						RequireNonLetterOrDigit = false,
						RequireDigit = false,
						RequireLowercase = false,
						RequireUppercase = false
					}
				})
				.As<UserManager<ApplicationUser>>()
				.InstancePerRequest();
		}
	}
}
