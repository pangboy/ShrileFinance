namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_DicType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_DicType()
        {
            SYS_DicCommon = new HashSet<SYS_DicCommon>();
        }

        [Key]
        public int DT_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Field { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsCommon { get; set; }

        public int Seed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_DicCommon> SYS_DicCommon { get; set; }
    }
}
