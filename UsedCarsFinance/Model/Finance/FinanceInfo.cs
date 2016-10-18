using System.Collections.Generic;

namespace Model.Finance
{
    /// <summary>
    /// 融资申请信息
    /// </summary>
    /// qiy    16.03.31
    /// qiy    16.05.31    增加金融手续费、最终手续费、月供
    /// yangj   16.07.26    增加融资预估金额
    /// zouql   16.07.28    增加厂商指导价
    /// zouql   16.07.28    增加保证金金额、先付月供金额、一次性付息金额、实际用款金额
    /// zouql   16.08.02    增加建议融资金额
    /// zouql   16.08.04    增加融资实际金额
    public class FinanceInfo
    {
        public enum TypeEnum
        {
            车辆融资 = 1
        }

        public int? FinanceId { get; set; }

        public int ProduceId { get; set; }

        /// <summary>
        /// 融资类型
        /// </summary>
        public TypeEnum Type { get; set; }

        /// <summary>
        /// 意向融资本金
        /// </summary>
        public decimal? IntentionPrincipal { get; set; }

        /// <summary>
        /// 审批价值
        /// </summary>
        public decimal? ApprovalValue { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 一次性付款期数
        /// </summary>
        public int? OncePayMonths { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 归属者
        /// </summary>
        public int CreateOf { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal? MarginMoney { get; set; }

        /// <summary>
        /// 先付月供金额
        /// </summary>
        public decimal? PaymonthlyMoney { get; set; }

        /// <summary>
        /// 一次性付息金额
        /// </summary>
        public decimal? OnepayInterestMoney { get; set; }

        /// <summary>
        /// 实际用款金额
        /// </summary>
        public decimal? ActualcashMoney { get; set; }

        /// <summary>
        /// 实例ID
        /// </summary>
        public int InstanceId { get; set; }
    }
}