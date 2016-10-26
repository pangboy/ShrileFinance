﻿using System.Web.Http;

namespace Web.Controllers.Customer
{
    using Application;
    using Application.ViewModels.OrganizationViewModels;
    using System;

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
        public IHttpActionResult Add(Base1ViewModel value)
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
        public IHttpActionResult Modify(Base1ViewModel value)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            customerAppService.Create(value);
            return Ok();
        }

        public Base1ViewModel Get(Guid id)
        {
            return null;//customerAppService.Get(id);
        }
    }
}
