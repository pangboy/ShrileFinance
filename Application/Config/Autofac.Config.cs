namespace Application
{
    using System.Reflection;
    using Autofac;

    public partial class Startup
    {
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<Data.MyContext>().AsSelf().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(Data.Repositories.UserRepository).Assembly)
                .Where(m => m.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(Core.Entities.User).Assembly)
                .Where(m => m.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(m => m.Name.EndsWith("AppService"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }
    }
}
