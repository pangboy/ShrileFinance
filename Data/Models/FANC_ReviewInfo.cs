namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FANC_ReviewInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FinanceId { get; set; }

        public int? RepaymentDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? FinanceCost { get; set; }

        [Column(TypeName = "money")]
        public decimal? FinalCost { get; set; }

        [Column(TypeName = "money")]
        public decimal? Payment { get; set; }

        public decimal? AdvicefinanceMoney { get; set; }

        public decimal? ApprovalPrincipal { get; set; }

        public double? ApprovalFinanceRatio { get; set; }

        public byte? ReviewType { get; set; }

        public virtual FANC_FinanceInfo FANC_FinanceInfo { get; set; }
    }
}
