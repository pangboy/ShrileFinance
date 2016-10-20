namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FANC_FinanceInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FANC_FinanceInfo()
        {
            FANC_ApplicantInfo = new HashSet<FANC_ApplicantInfo>();
            FANC_BankInfo = new HashSet<FANC_BankInfo>();
            FANC_Borrow = new HashSet<FANC_Borrow>();
            FANC_CreditExamineReport = new HashSet<FANC_CreditExamineReport>();
            FANC_Contracts = new HashSet<FANC_Contracts>();
        }

        [Key]
        public int FinanceId { get; set; }

        public int ProduceId { get; set; }

        public byte Type { get; set; }

        public decimal? IntentionPrincipal { get; set; }

        public decimal? ApprovalValue { get; set; }

        public int? CreateBy { get; set; }

        public int? CreateOf { get; set; }

        public DateTime AddDate { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        public int? OncePayMonths { get; set; }

        public decimal? MarginMoney { get; set; }

        public decimal? PaymonthlyMoney { get; set; }

        public decimal? OnepayInterestMoney { get; set; }

        public decimal? ActualcashMoney { get; set; }

        public virtual CRET_CreditInfo CRET_CreditInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FANC_ApplicantInfo> FANC_ApplicantInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FANC_BankInfo> FANC_BankInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FANC_Borrow> FANC_Borrow { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FANC_CreditExamineReport> FANC_CreditExamineReport { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FANC_Contracts> FANC_Contracts { get; set; }

        public virtual USER_UserInfo USER_UserInfo { get; set; }

        public virtual PROD_ProduceInfo PROD_ProduceInfo { get; set; }

        public virtual FANC_VehicleInfo FANC_VehicleInfo { get; set; }

        public virtual FANC_ReviewInfo FANC_ReviewInfo { get; set; }

        public virtual FANC_FinanceExtra FANC_FinanceExtra { get; set; }
    }
}
