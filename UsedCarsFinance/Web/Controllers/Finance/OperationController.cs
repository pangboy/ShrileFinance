namespace Web.Controllers.Finance
{
    using System;
    using System.Web.Http;
    using Application;
    using Application.ViewModels.FinanceViewModels;

    /// <summary>
    /// 运营
    /// </summary>
    public class OperationController : ApiController
    {
        private readonly FinanceAppService financeAppService;

        public OperationController(FinanceAppService financeAppService)
        {
            this.financeAppService = financeAppService;
        }

        /// <summary>
        /// 通过融资标识获取运营ViewModel
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>融资审核ViewModel</returns>
        [HttpGet]
        public IHttpActionResult GetOperation(Guid financeId)
        {
            var operationViewModel = financeAppService.GetOperationByFinanceId(financeId);

            if (operationViewModel == null)
            {
                return BadRequest();
            }

            return Ok(operationViewModel);
        }

        /// <summary>
        /// 编辑运营
        /// </summary>
        /// <param name="value">运营ViewModel</param>
        /// <returns>处理结果</returns>
        [HttpPost]
        public IHttpActionResult EditOperation(OperationViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ValidModel.ShowErrorFirst(ModelState));
            }

            financeAppService.EditOperation(value: value);

            return Ok();
        }
    }
}
