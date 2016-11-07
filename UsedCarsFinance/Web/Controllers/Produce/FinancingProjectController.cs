using System.Collections.Generic;
using System.Web.Http;
using Application;
using Application.ViewModels.ProduceViewModel;

namespace Web.Controllers.Produce
{
    public class FinancingProjectController : ApiController
    {
        private readonly FinancingProjectAppService financingProjectAppService;

        public FinancingProjectController(FinancingProjectAppService financingProjectAppService)
        {
            this.financingProjectAppService = financingProjectAppService;
        }

        public List<FinancingItemListViewModel> GetAll()
        {
            return financingProjectAppService.GetAll();
        }
    }
}
