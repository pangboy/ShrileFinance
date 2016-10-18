using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Finance
{
    /// <summary>
    /// 运营审核类型
    /// yangj   2016.09.09
    /// </summary>
    public enum OperationType : byte
    {
        初审 = 1,
        复审 = 2
    }

    /// <summary>
    /// 融资扩展信息实体
    /// </summary>
    /// yangj   2016.08.29
    public class FinanceExtraInfo
    {
        public int? FinanceId { get; set; }

        /// <summary>
        /// 裸车价
        /// </summary>
        public decimal? VehiclePrice { get; set; }

        /// <summary>
        /// 购置税
        /// </summary>
        public decimal? PurchaseTaxPrice { get; set; }

        /// <summary>
        /// 商业险
        /// </summary>
        public decimal? BusinessInsurancePrice { get; set; }

        /// <summary>
        /// 交强险
        /// </summary>
        public decimal? TafficCompulsoryInsurancePrice { get; set; }

        /// <summary>
        /// 车船税
        /// </summary>
        public decimal? VehicleVesselTaxPrice { get; set; }

        /// <summary>
        /// 延保险
        /// </summary>
        public decimal? ExtendedWarrantyInsurancePrice { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public decimal? OtherPrice { get; set; }

        /// <summary>
        /// 裸车价(实际)
        /// </summary>
        public decimal? ActualVehiclePrice { get; set; }

        /// <summary>
        /// 购置税(实际)
        /// </summary>
        public decimal? ActualPurchaseTaxPrice { get; set; }

        /// <summary>
        /// 商业险(实际)
        /// </summary>
        public decimal? ActualBusinessInsurancePrice { get; set; }

        /// <summary>
        /// 交强险(实际)
        /// </summary>
        public decimal? ActualTafficCompulsoryInsurancePrice { get; set; }

        /// <summary>
        /// 车船税(实际)
        /// </summary>
        public decimal? ActualVehicleVesselTaxPrice { get; set; }

        /// <summary>
        /// 延保险(实际)
        /// </summary>
        public decimal? ActualExtendedWarrantyInsurancePrice { get; set; }

        /// <summary>
        /// 其他(实际)
        /// </summary>
        public decimal? ActualOtherPrice { get; set; }

        /// <summary>
        /// 运营审核类型
        /// </summary>
        public OperationType OperationType { get; set; }
    }
}
