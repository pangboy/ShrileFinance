namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FANC_FinanceExtra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FinanceId { get; set; }

        public decimal? VehiclePrice { get; set; }

        public decimal? PurchaseTaxPrice { get; set; }

        public decimal? BusinessInsurancePrice { get; set; }

        public decimal? TafficCompulsoryInsurancePrice { get; set; }

        public decimal? VehicleVesselTaxPrice { get; set; }

        public decimal? ExtendedWarrantyInsurancePrice { get; set; }

        public decimal? OtherPrice { get; set; }

        public decimal? ActualVehiclePrice { get; set; }

        public decimal? ActualPurchaseTaxPrice { get; set; }

        public decimal? ActualBusinessInsurancePrice { get; set; }

        public decimal? ActualTafficCompulsoryInsurancePrice { get; set; }

        public decimal? ActualVehicleVesselTaxPrice { get; set; }

        public decimal? ActualExtendedWarrantyInsurancePrice { get; set; }

        public decimal? ActualOtherPrice { get; set; }

        public byte? OperationType { get; set; }

        public virtual FANC_FinanceInfo FANC_FinanceInfo { get; set; }
    }
}
