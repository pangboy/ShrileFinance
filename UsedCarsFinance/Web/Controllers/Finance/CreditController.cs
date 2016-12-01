using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;
using Application.ViewModels.LoanViewModels;

namespace Web.Controllers.Finance
{
    public class CreditController : ApiController
    {
        private readonly CreditAppService creditAppService;

        public CreditController(CreditAppService creditAppService)
        {
            this.creditAppService = creditAppService;
        }

        public IHttpActionResult Create(CreditViewModel model)
        {
            creditAppService.Create(model);

            return Ok();
        }
    }
}
