using System;
using System.Collections.Generic;

namespace Application.ViewModels.TreeGrid
{
    public class CreditCountViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime  EndDate { get; set; }

        public string state { get; set; }

        public ICollection<CreditCountViewModel> children { get; set; }
    }
}
