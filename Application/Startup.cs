namespace Application
{
    using Owin;

    /// <summary>
    /// 启动配置
    /// </summary>
    public abstract partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);

            this.ConfigureAutofac();
        }
    }
}
