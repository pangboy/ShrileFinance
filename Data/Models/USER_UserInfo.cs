namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_UserInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER_UserInfo()
        {
            FANC_FinanceInfo = new HashSet<FANC_FinanceInfo>();
            FLOW_Instance = new HashSet<FLOW_Instance>();
            FLOW_Instance1 = new HashSet<FLOW_Instance>();
            FLOW_Instance2 = new HashSet<FLOW_Instance>();
            FLOW_Log = new HashSet<FLOW_Log>();
            Notice_Notice = new HashSet<Notice_Notice>();
            SYS_OperationLog = new HashSet<SYS_OperationLog>();
            CRET_ProcessUser = new HashSet<CRET_ProcessUser>();
            CRET_ProcessUser1 = new HashSet<CRET_ProcessUser>();
            CRET_ProcessUser2 = new HashSet<CRET_ProcessUser>();
            CRET_ProcessUser3 = new HashSet<CRET_ProcessUser>();
            CRET_ProcessUser4 = new HashSet<CRET_ProcessUser>();
            CRET_ProcessUser5 = new HashSet<CRET_ProcessUser>();
            CRET_CreditInfo = new HashSet<CRET_CreditInfo>();
            USER_Role = new HashSet<USER_Role>();
        }

        [Key]
        public int UI_ID { get; set; }

        [Required]
        [StringLength(32)]
        public string Username { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        [Required]
        [StringLength(40)]
        public string Realname { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        public byte Status { get; set; }

        public DateTime? RegisterDate { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FANC_FinanceInfo> FANC_FinanceInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_Instance> FLOW_Instance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_Instance> FLOW_Instance1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_Instance> FLOW_Instance2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_Log> FLOW_Log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notice_Notice> Notice_Notice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_OperationLog> SYS_OperationLog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRET_ProcessUser> CRET_ProcessUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRET_ProcessUser> CRET_ProcessUser1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRET_ProcessUser> CRET_ProcessUser2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRET_ProcessUser> CRET_ProcessUser3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRET_ProcessUser> CRET_ProcessUser4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRET_ProcessUser> CRET_ProcessUser5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRET_CreditInfo> CRET_CreditInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_Role> USER_Role { get; set; }
    }
}
