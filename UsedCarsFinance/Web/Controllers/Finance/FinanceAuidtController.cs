namespace Web.Controllers.Finance
{
    using System;
    using System.Web.Http;
    using Application;
    using Application.ViewModels.FinanceViewModels;

    public class FinanceAuidtController : ApiController
    {
        private readonly FinanceAppService financeAppService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceAuidtController" /> class.
        /// </summary>
        /// <param name="financeAppService">融资仓储</param>
        public FinanceAuidtController(FinanceAppService financeAppService)
        {
            this.financeAppService = financeAppService;
        }

        /// <summary>
        /// 通过融资标识获取融资审核ViewModel
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>融资审核ViewModel</returns>
        [HttpGet]
        public FinanceAuidtViewModel GetFinanceAuidt(Guid financeId)
        {
            var financeAuidtViewModel = financeAppService.GetFinanceAuidtByFinanceId(financeId);

            return financeAuidtViewModel;
        }

        /// <summary>
        /// 编辑融资审核
        /// </summary>
        /// <param name="value">融资审核ViewModel</param>
        /// <returns>处理结果</returns>
        [HttpPost]
        public IHttpActionResult EditFinanceAuidt(FinanceAuidtViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ValidModel.ShowErrorFirst(ModelState));
            }

            financeAppService.EditFinanceAuidt(value: value, isReview: value.isReview);

            return Ok(value);
        }
    }
}
