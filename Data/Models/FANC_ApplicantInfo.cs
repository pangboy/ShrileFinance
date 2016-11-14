namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FANC_ApplicantInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FANC_ApplicantInfo()
        {
            FANC_BankInfo = new HashSet<FANC_BankInfo>();
        }

        [Key]
        public int ApplicantId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Sex { get; set; }

        public byte Type { get; set; }

        [StringLength(50)]
        public string RelationWithMaster { get; set; }

        [StringLength(50)]
        public string Identity { get; set; }

        [StringLength(50)]
        public string IdentityType { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string MaritalStatus { get; set; }

        [StringLength(50)]
        public string WifeName { get; set; }

        [StringLength(50)]
        public string Degree { get; set; }

        [StringLength(100)]
        public string RegisteredAddress { get; set; }

        [StringLength(50)]
        public string OfficeName { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(50)]
        public string IndustryType { get; set; }

        [StringLength(50)]
        public string ProfessionType { get; set; }

        [StringLength(50)]
        public string OfficePhone { get; set; }

        [StringLength(50)]
        public string OfficeAddress { get; set; }

        [StringLength(50)]
        public string LiveHouseType { get; set; }

        [StringLength(50)]
        public string LiveHouseArea { get; set; }

        [StringLength(100)]
        public string LiveHouseAddress { get; set; }

        [StringLength(50)]
        public string OwnHouseType { get; set; }

        [StringLength(100)]
        public string OwnHouseAddress { get; set; }

        [StringLength(100)]
        public string ContactAddress { get; set; }

        [StringLength(50)]
        public string ContactAddressType { get; set; }

        [StringLength(50)]
        public string TotalMonthlyIncome { get; set; }

        [StringLength(50)]
        public string HomeMonthlyIncome { get; set; }

        [StringLength(50)]
        public string HomeMonthlyExpend { get; set; }

        [StringLength(50)]
        public string OtherIncome { get; set; }

        [StringLength(50)]
        public string FamilyNumber { get; set; }

        public DateTime AddDate { get; set; }

        public int? Age { get; set; }

        [StringLength(50)]
        public string EMail { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Postcode { get; set; }

        public virtual FANC_FinanceInfo FANC_FinanceInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FANC_BankInfo> FANC_BankInfo { get; set; }
    }
}
