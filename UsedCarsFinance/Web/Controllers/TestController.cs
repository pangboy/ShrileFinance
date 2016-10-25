namespace Web.Controllers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    using Application;
    using Application.ViewModels.AccountViewModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    public class TestController : ApiController
    {
        private AccountAppService service;

        private IAuthenticationManager AuthManager
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        public TestController(AccountAppService service)
        {
            this.service = service;
        }

        public IHttpActionResult Get()
        {
            return Ok();
        }

        [AllowAnonymous]
        public async Task<IHttpActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var ident = await service.Login(model);

                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties {
                    IsPersistent = false
                }, ident);

                return Ok();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IHttpActionResult> Create(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.Create(model);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // 没有可发送的 ModelState 错误，因此仅返回空 BadRequest。
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
