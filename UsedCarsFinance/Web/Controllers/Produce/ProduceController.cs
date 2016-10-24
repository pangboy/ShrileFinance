using Models;
using Models.Produce;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Http;

namespace Web.Controllers.Produce
{
    public class ProduceController : ApiController
    {
        private readonly static BLL.Produce.Produce _produce = new BLL.Produce.Produce();

        /// <summary>
        /// 获得产品列表
        /// </summary>
        ///  cais    16.03.25
        /// <param name="page">第几页</param>
        /// <param name="rows">每页行数</param>
        /// <returns></returns>
        public Datagrid GetAll(int page, int rows)
        {
            Pagination pagination = new Pagination(page, rows);
            NameValueCollection filter = ApiHelper.GetParameters();

            return new Datagrid
            {
                rows = _produce.List(pagination, filter),
                total = pagination.Total
            };
        }

        /// <summary>
        /// 通过一个产品ID，返回一个产品
        /// </summary>
        /// cais    16.03.28
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProduceInfo Get(int productId)
        {
            return _produce.Get(productId);
        }

        /// <summary>
        /// 通过实体，增加一个产品
        /// </summary>
        /// cais    16.03.28
        /// <param name="produce"></param>
        /// <returns></returns>
        public bool Post([FromBody]ProduceInfo produce)
        {
            return _produce.Add(produce);
        }

        /// <summary>
        /// 根据一个产品ID ，修改对应的产品
        /// </summary>
        /// cais    16.03.29
        /// <param name="produce"></param>
        /// <returns></returns>
        public bool Put([FromBody]ProduceInfo produce)
        {
            return _produce.Modify(produce);
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// cais    16.03.28
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> Option()
        {
            return _produce.Option();
        }


        /// <summary>
        /// 获取产品列表（还款方式）
        /// </summary>
        /// yangj    16.08.02
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetByRepaymentMethod()
        {
            List<ComboInfo> cbi = _produce.GetByRepaymentMethod();
            ComboInfo cb = new ComboInfo(string.Empty, "　");
            cbi.Add(cb);
            return cbi;
        }

        /// <summary>
        /// 获取产品列表（产品名）
        /// </summary>
        /// yangj    16.08.02
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetByProduceName()
        {
            List<ComboInfo> cbi = _produce.GetByProduceName();
            ComboInfo cb = new ComboInfo(string.Empty, "　");
            cbi.Add(cb);
            return cbi;
        }

        /// <summary>
        /// 获取产品列表（融资期限）
        /// </summary>
        /// yangj    16.08.02
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetByFinancingPeriods()
        {
            List<ComboInfo> cbi = _produce.GetByFinancingPeriods();
            ComboInfo cb = new ComboInfo(string.Empty, "　");
            cbi.Add(cb);
            return cbi;
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// yangj    16.08.02
        /// <param name="produceName">产品名</param>
        /// <param name="repaymentMethod">还款方式</param>
        /// <param name="financingPeriods">融资期限</param>
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetProduct(string produceName, string repaymentMethod, string financingPeriods)
        {
            return _produce.GetProduct(produceName, repaymentMethod, financingPeriods);
        }
    }
}