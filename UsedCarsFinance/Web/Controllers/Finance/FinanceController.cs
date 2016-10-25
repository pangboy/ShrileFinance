using System.Collections.Generic;
using System.Web.Http;
using Models;
using Models.Finance;

namespace Web.Controllers.Finance
{
    public class FinanceController : ApiController
    {
        private static readonly BLL.Finance.Finance Finance = new BLL.Finance.Finance();
        private static readonly BLL.Finance.FinanceExtra FinanceExtra = new BLL.Finance.FinanceExtra();
        private static readonly BLL.Finance.Review Review = new BLL.Finance.Review();
        private static readonly BLL.Finance.Vehicle Vehicle = new BLL.Finance.Vehicle();

        /// <summary>
        /// 获取融资信息
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// qiy 16.03.31
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(int financeId)
        {
            FinanceNodeGroupInfo finance = Finance.GetFinanceNodeGroupInfo(financeId);

            return finance != null ? (IHttpActionResult)Ok(finance) : NotFound();
        }

        /// <summary>
        /// 获取当前授信主体所拥有的产品选项
        /// </summary>
        /// qiy     16.04.07
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult ProducesOption()
        {
            List<ComboInfo> options = Finance.ProducesOptionByCredit();

            return options != null ? (IHttpActionResult)Ok(options) : BadRequest("当前角色非授信主体角色");
        }

        /// <summary>
        /// 加载财务放还款人信息(根据放款人是否存在区分放还款)
        /// </summary>
        /// zouql   16.07.27
        /// <param name="financeId">融资标识</param>
        /// <returns>银行信息</returns>
        [HttpGet]
        public List<BankInfo> LoanBankInfoLoad(int financeId)
        {
            return new BLL.Finance.Bank().List(financeId);
        }

        /// <summary>
        /// 获取审核信息
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// yangj   16.08.30
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetReviewInfo(int financeId)
        {
            var result = Review.Get(financeId);

            return Ok(result);
        }

        /// <summary>
        /// 获取车辆信息
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// yangj   16.09.09
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetVehicleInfo(int financeId)
        {
            var result = Vehicle.Get(financeId);

            return result != null ? (IHttpActionResult)Ok(result) : NotFound();
        }
    }
}
