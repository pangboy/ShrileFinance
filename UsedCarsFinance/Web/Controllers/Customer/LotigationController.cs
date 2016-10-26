namespace ShrileFinance.Controllers.Customer
{
    using System.Web.Http;
    using Application;
    using Application.ViewModels.LitigationViewModels;

    public class LotigationController : ApiController
    {
        private readonly LawsuitAppService lawsuitAppService;

        public LotigationController(LawsuitAppService lawsuitAppService)
        {
            this.lawsuitAppService = lawsuitAppService;
        }

        public IHttpActionResult Add(LitigationViewModel value)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            lawsuitAppService.Create(value);
            return Ok();
        }

        public IHttpActionResult Modify(string value)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            return Ok();
        }

        public IHttpActionResult Get(string value)
        {
            return Ok();
        }
    }
}
