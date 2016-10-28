using System.Web.Http;

namespace Web.Controllers.Customer
{
    using Application;
    using Application.ViewModels.OrganizationViewModels;
    using System;
    using System.Linq;

    public class CustomerController : ApiController
    {
        private readonly OrganizationAppService customerAppService;

        public CustomerController(OrganizationAppService service)
        {
            this.customerAppService = service;
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// yand    16.10.25
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Add(OrganizationViewModel value)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ValidModel.ShowErrorFirst(ModelState));
            //}

            try
            {
                customerAppService.Create(value); 

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yand    16.10.25
        /// <param name="value"></param>
        /// <returns></returns>
        public IHttpActionResult Modify(OrganizationViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            customerAppService.Modify(value);

            return Ok();
        }

        public OrganizationViewModel Get(Guid id)
        {
            return customerAppService.Get(id);
        }
    }
}
