namespace Web
{
    using System.Reflection;
    using System.Web.Http;
    using Autofac;
    using Autofac.Integration.WebApi;

    public class Startup : Application.Startup
    {
        public override void ConfigureAutofac(ContainerBuilder builder)
        {
            var config = GlobalConfiguration.Configuration;
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterApiControllers(assembly);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}