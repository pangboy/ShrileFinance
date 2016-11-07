using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Entities.Produce.Produce;

namespace Application.ViewModels.ProduceViewModel
{
    public class ProduceListViewModel
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 产品代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 还款方式
        /// </summary>
        public RepaymentMethodEnum RepaymentMethod { get; set; }

        /// <summary>
        /// 融资期限
        /// </summary>
        public int FinancingPeriods { get; set; }

        /// <summary>
        /// 数据添加时间
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
