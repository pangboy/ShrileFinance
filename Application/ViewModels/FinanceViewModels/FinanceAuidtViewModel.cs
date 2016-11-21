namespace Application.ViewModels.FinanceViewModels
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 融资审核
    /// </summary>
    public class FinanceAuidtViewModel
    {
        /// <summary>
        /// 融资标识
        /// </summary>
        public Guid FinanceId { get; set; }

        /// <summary>
        /// 融资项（Id、（Name、Maney））
        /// </summary>
        public ICollection<KeyValuePair<Guid, KeyValuePair<string, decimal?>>> FinancingItems { get; set; }

        /// <summary>
        /// 厂商指导价
        /// </summary>
        public decimal? ManufacturerGuidePrice { get; set; }

        /// <summary>
        /// 最小融资比例
        /// </summary>
        public decimal MinFinancingRatio { get; set; }

        /// <summary>
        /// 最大融资比例
        /// </summary>
        public decimal MaxFinancingRatio { get; set; }

        /// <summary>
        /// 建议融资金额
        /// </summary>
        public decimal? AdviceMoney { get; set; }

        /// <summary>
        /// 建议融资比例
        /// </summary>
        public decimal? AdviceRatio { get; set; }

        /// <summary>
        /// 审批融资金额
        /// </summary>
        public decimal? ApprovalMoney { get; set; }

        /// <summary>
        /// 审批融资比例
        /// </summary>
        public decimal? ApprovalRatio { get; set; }

        /// <summary>
        /// 月供额度
        /// </summary>
        public decimal? Payment { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal? Cost { get; set; }

        /// <summary>
        /// 是否为复审
        /// </summary>
        public bool IsReview { get; set; }
    }
}
