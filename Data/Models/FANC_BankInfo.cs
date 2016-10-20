namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FANC_BankInfo
    {
        [Key]
        public int BankId { get; set; }

        public int FinanceId { get; set; }

        [Required]
        [StringLength(100)]
        public string BankCard { get; set; }

        public int? CreditId { get; set; }

        public int? ApplicantId { get; set; }

        [StringLength(100)]
        public string BankName { get; set; }

        public virtual CRET_CreditInfo CRET_CreditInfo { get; set; }

        public virtual FANC_ApplicantInfo FANC_ApplicantInfo { get; set; }

        public virtual FANC_FinanceInfo FANC_FinanceInfo { get; set; }
    }
}
