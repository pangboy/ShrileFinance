namespace Web.Controllers.Loan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Application;
    using Application.ViewModels;
    using Application.ViewModels.Loan.LoanViewModels;
    using Core.Entities.Loan;

    public class LoanController : ApiController
    {
        private readonly LoanAppService service;

        public LoanController(LoanAppService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IHttpActionResult Get(Guid Id)
        {
            var model = service.Get(Id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Post(LoanViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.ApplyLoan(model);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult SearchList(string searchString, int page, int rows, LoanStatusEnum? status = null)
        {
            var models = service.PagedList(searchString, page, rows, status);

            return Ok(new PagedListViewModel<LoanViewModel>(models));
        }
    }
}
