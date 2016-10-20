namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_Menu()
        {
            SYS_Menu1 = new HashSet<SYS_Menu>();
            USER_Role = new HashSet<USER_Role>();
        }

        [Key]
        public int MN_ID { get; set; }

        public int? ParentId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Link { get; set; }

        public byte Sort { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Menu> SYS_Menu1 { get; set; }

        public virtual SYS_Menu SYS_Menu2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_Role> USER_Role { get; set; }
    }
}
