using System.Web.Http;

namespace Web.Controllers.Customer
{
    using Application;
    using Application.ViewModels.CustomerViewModels;
    using System;

    public class CustomerController : ApiController
    {
        private readonly CustomerAppService customerAppService;

        public CustomerController(CustomerAppService service)
        {
            this.customerAppService = service;
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// yand    16.10.25
        /// <param name="value"></param>
        /// <returns></returns>
        public IHttpActionResult Add(CustomerViewModel value)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            customerAppService.Create(value);
            return Ok();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yand    16.10.25
        /// <param name="value"></param>
        /// <returns></returns>
        public IHttpActionResult Modify(CustomerViewModel value)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            customerAppService.Create(value);
            return Ok();
        }

        public CustomerViewModel Get(Guid id)
        {
            return null;//customerAppService.Get(id);
        }
    }
}
