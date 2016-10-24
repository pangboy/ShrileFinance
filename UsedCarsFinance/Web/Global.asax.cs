namespace Web
{
    using System.Web;
    using System.Web.Http;
    using Infrastructure;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(Register);
        }

        protected void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

            //初始化log4net配置
            log4net.Config.XmlConfigurator.Configure();

            config.Filters.Add(new AuthorizeAttribute());
            config.Filters.Add(new ExceptionFilter());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = RouteParameter.Optional }
            );
        }
    }
}
