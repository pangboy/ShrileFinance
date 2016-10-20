namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FANC_Borrow
    {
        [Key]
        public int BI_ID { get; set; }

        public int FinanceId { get; set; }

        public decimal? ApprovalPrincipal { get; set; }

        public double? InterestRate { get; set; }

        public int? FinancingPeriods { get; set; }

        public int? RepaymentInterval { get; set; }

        [StringLength(20)]
        public string RepaymentMethod { get; set; }

        public int? RepaymentDate { get; set; }

        public DateTime? FinanceAddDate { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        public int? OncePayMonths { get; set; }

        public double? FinalRatio { get; set; }

        public double? CustomerBailRatio { get; set; }

        public decimal? FinalCost { get; set; }

        public decimal? ExtralCost { get; set; }

        public virtual FANC_FinanceInfo FANC_FinanceInfo { get; set; }
    }
}
