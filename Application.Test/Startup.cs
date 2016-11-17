namespace Application.Test
{
    using System;
    using System.Security.Principal;

    public class Startup : Application.Startup
    {
        public override void ConfigureAutofac(Autofac.ContainerBuilder builder)
        {
            builder.Build();
            throw new NotImplementedException();
        }

        protected override IPrincipal CurrentPrincipal()
        {
            throw new NotImplementedException();
        }
    }
}
