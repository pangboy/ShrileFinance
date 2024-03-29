﻿namespace Web.Controllers.Credit
{
    using System;
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.Loan.CreditViewModel;

    public class CreditContractController : ApiController
    {
        private readonly CreditContractAppService service;

        public CreditContractController(CreditContractAppService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IHttpActionResult Create(CreditContractViewModel model)
        {
            service.Create(model);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Modify(CreditContractViewModel model)
        {
            service.Modify(model);

            return Ok(model);
        }

        public IHttpActionResult Get(Guid id)
        {
            var creditContract = service.Get(id);

            return Ok(creditContract);
        }

        public IHttpActionResult GetCreditBalance(Guid id, decimal limit)
        {
            var getCreditBalanc = service.GetCreditBalanc(id, limit);

            return Ok(getCreditBalanc);
        }

        [HttpGet]
        public IHttpActionResult Option()
        {
            return Ok(service.Option());
        }

        [HttpGet]
        public IHttpActionResult GetPageList(int page, int rows, string Search)
        {
            var list = service.GetPageList(Search, page, rows);

            return Ok(new PagedListViewModel<CreditContractViewModel>(list));
        }
    }
}
