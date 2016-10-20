namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER_Role()
        {
            FLOW_Node = new HashSet<FLOW_Node>();
            FLOW_FormWithRole = new HashSet<FLOW_FormWithRole>();
            SYS_Menu = new HashSet<SYS_Menu>();
            USER_UserInfo = new HashSet<USER_UserInfo>();
        }

        [Key]
        public int UR_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public byte Sort { get; set; }

        public byte Power { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_Node> FLOW_Node { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_FormWithRole> FLOW_FormWithRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Menu> SYS_Menu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_UserInfo> USER_UserInfo { get; set; }
    }
}
