namespace Web
{
    using System.Reflection;
    using System.Web.Http;
    using Autofac;
    using Autofac.Integration.WebApi;

    public static class Bootstrapper
    {
        private static Application.Startup appStartup;

        public static void Run()
        {
            appStartup = new Application.Startup();
            appStartup.Configuration();

            SetContainer();
        }

        private static void SetContainer()
        {
            var config = GlobalConfiguration.Configuration;
            var assembly = Assembly.GetExecutingAssembly();

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(assembly);

            appStartup.ConfigureContainer(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}