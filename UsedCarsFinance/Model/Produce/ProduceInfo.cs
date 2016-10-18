using System;

namespace Model.Produce
{
    /// <summary>
    /// 产品信息
    /// </summary>
    /// cais    16.03.25
    /// qiy		16.04.01	增加还款方式描述字段
    /// yangj   16.07.25	增加融资范围7个字段
    /// yand    16.07.25    增加费率字段
    public class ProduceInfo
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProduceId { get; set; }

        /// <summary>
        /// 产品代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 月利率
        /// </summary>
        public double InterestRate { get; set; }
        /// <summary>
        /// 费率
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// 还款方式
        /// </summary>
        public RepaymentMethodEnum RepaymentMethod { get; set; }

        /// <summary>
        /// 还款方式描述
        /// </summary>
        public string RepaymentMethodDesc { get { return RepaymentMethod.ToString(); } }

        /// <summary>
        /// 最小车价融资比
        /// </summary>
        public int MinFinancingRatio { get; set; }

        /// <summary>
        /// 最大车价融资比
        /// </summary>
        public int MaxFinancingRatio { get; set; }

        /// <summary>
        /// 最终比（尾款比例）
        /// </summary>
        public int FinalRatio { get; set; }

        /// <summary>
        /// 融资期限
        /// </summary>
        public int FinancingPeriods { get; set; }

        /// <summary>
        /// 还款间隔
        /// </summary>
        public int RepaymentInterval { get; set; }

        /// <summary>
        /// 客户保证金比例
        /// </summary>
        public double CustomerBailRatio { get; set; }

        /// <summary>
        /// 客户手续费
        /// </summary>
        public decimal CustomerPoundage { get; set; }

        /// <summary>
        /// 数据添加时间
        /// </summary>
        public DateTime AddDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// GPS费用
        /// </summary>
        public decimal AdditionalGPSCost { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal AdditionalOtherCost { get; set; }

        /// <summary>
        /// 还款方式枚举
        /// </summary>
        public enum RepaymentMethodEnum : byte
        {
            等额本息 = 1,
            月供提前付 = 2,
            一次性付息 = 3
        }

        /// <summary>
        /// 裸车价
        /// </summary>
        public bool IsVehiclePrice { get; set; }

        /// <summary>
        /// 购置税
        /// </summary>
        public bool IsPurchaseTax { get; set; }

        /// <summary>
        /// 商业险
        /// </summary>
        public bool IsBusinessInsurance { get; set; }

        /// <summary>
        /// 交强险
        /// </summary>
        public bool IsTafficCompulsoryInsurance { get; set; }

        /// <summary>
        /// 车船税
        /// </summary>
        public bool IsVehicleVesselTax { get; set; }

        /// <summary>
        /// 延保险
        /// </summary>
        public bool IsExtendedWarrantyInsurance { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public bool IsOther { get; set; }
    }
}