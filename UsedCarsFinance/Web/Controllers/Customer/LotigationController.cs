namespace ShrileFinance.Controllers.Customer
{
    using Application;
    using Models.Customer.Enterprise.Lotigation;
    using System.Web.Http;
    public class LotigationController : ApiController
    {
        private readonly LawsuitAppService lawsuitAppService;
        public LotigationController(LawsuitAppService lawsuitAppService)
        {
            this.lawsuitAppService = lawsuitAppService;
        }

        public IHttpActionResult Add(LitigationViewModel value)
        {
            return Ok();
        }

        public IHttpActionResult Modify(string value)
        {
            return Ok();
        }
        public IHttpActionResult Get(string value)
        {
            return Ok();
        }
    }
}
