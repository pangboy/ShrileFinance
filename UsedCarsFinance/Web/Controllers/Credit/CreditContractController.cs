namespace Web.Controllers.Credit
{
    using System;
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.LoanViewModels;

    public class CreditContractController : ApiController
    {
        private readonly CreditContractAppService service;

        public CreditContractController(CreditContractAppService service)
        {
            this.service = service;
        }

        public IHttpActionResult Create(CreditContractViewModel model)
        {
            service.Create(model);

            return Ok();
        }

        public IHttpActionResult Modify(CreditContractViewModel model)
        {
            service.Modify(model);

            return Ok();
        }

        public IHttpActionResult Get(Guid id)
        {
            var creditContract = service.Get(id);
              return Ok(creditContract);
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
