namespace Core.Entities.Produce
{
    using System;

    /// <summary>
    /// 融资项
    /// </summary>
    public class FinancingItem : Entity
    {
        /// <summary>
        /// 融资项目标识
        /// </summary>
        public Guid FinancingProjectId { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// 融资项目
        /// </summary>
        public virtual FinancingProject FinancingProject { get; set; }
    }
}
