namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PROD_ProduceInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROD_ProduceInfo()
        {
            FANC_FinanceInfo = new HashSet<FANC_FinanceInfo>();
            CRET_CreditInfo = new HashSet<CRET_CreditInfo>();
        }

        [Key]
        public int ProduceId { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double InterestRate { get; set; }

        public byte RepaymentMethod { get; set; }

        public int MinFinancingRatio { get; set; }

        public int MaxFinancingRatio { get; set; }

        public int FinalRatio { get; set; }

        public int FinancingPeriods { get; set; }

        public int RepaymentInterval { get; set; }

        public double? CustomerBailRatio { get; set; }

        public decimal? CustomerPoundage { get; set; }

        public DateTime AddDate { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        public decimal? AdditionalGPSCost { get; set; }

        public decimal? AdditionalOtherCost { get; set; }

        public bool IsVehiclePrice { get; set; }

        public bool IsPurchaseTax { get; set; }

        public bool IsBusinessInsurance { get; set; }

        public bool IsTafficCompulsoryInsurance { get; set; }

        public bool IsVehicleVesselTax { get; set; }

        public bool IsExtendedWarrantyInsurance { get; set; }

        public bool IsOther { get; set; }

        public double? Rate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FANC_FinanceInfo> FANC_FinanceInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRET_CreditInfo> CRET_CreditInfo { get; set; }
    }
}
