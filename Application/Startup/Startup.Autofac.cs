namespace Application
{
    using System.Reflection;
    using Autofac;
    using Core.Entities;
    using Microsoft.AspNet.Identity;

    public partial class Startup
    {
        public static void ConfigureAutofac(ContainerBuilder builder)
        {
            builder.RegisterType<Data.MyContext>().AsSelf().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(Data.Repositories.BaseRepository<>).Assembly)
                .Where(m => m.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(Core.Entities.AppUser).Assembly)
                .Where(m => m.Name.EndsWith("Service"))
                .AsSelf()
                .InstancePerRequest();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(m => m.Name.EndsWith("AppService"))
                .AsSelf()
                .InstancePerRequest();

            builder.RegisterType<Data.Repositories.AppUserStore>()
                .As<IUserStore<AppUser>>()
                .InstancePerRequest();
            builder.RegisterType<AppUserManager>()
                .As<UserManager<AppUser>>()
                .InstancePerRequest()
                .OnActivated(ConfigUserManager);
        }
    }
}
