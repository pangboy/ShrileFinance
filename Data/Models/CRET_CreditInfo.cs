namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CRET_CreditInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CRET_CreditInfo()
        {
            FANC_BankInfo = new HashSet<FANC_BankInfo>();
            FANC_FinanceInfo = new HashSet<FANC_FinanceInfo>();
            USER_UserInfo = new HashSet<USER_UserInfo>();
            PROD_ProduceInfo = new HashSet<PROD_ProduceInfo>();
        }

        [Key]
        public int CreditId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public byte Type { get; set; }

        public decimal LineOfCredit { get; set; }

        public DateTime AddDate { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        public virtual CRET_PartnerInfo CRET_PartnerInfo { get; set; }

        public virtual CRET_ProcessUser CRET_ProcessUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FANC_BankInfo> FANC_BankInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FANC_FinanceInfo> FANC_FinanceInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_UserInfo> USER_UserInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROD_ProduceInfo> PROD_ProduceInfo { get; set; }
    }
}
