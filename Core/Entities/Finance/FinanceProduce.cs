using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Finance
{
    public class FinanceProduce : Entity
    {
        /// <summary>
        /// 是否融资项
        /// </summary>
        public bool IsFinancing { get; set; }

        /// <summary>
        /// 是否可编辑
        /// </summary>

        public bool IsEdit { get; set; }

        /// <summary>
        /// 金额
        /// </summary>

        public decimal Money { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
