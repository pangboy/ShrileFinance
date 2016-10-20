namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FLOW_Form
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FLOW_Form()
        {
            FLOW_FormWithRole = new HashSet<FLOW_FormWithRole>();
            FLOW_FormWithNode = new HashSet<FLOW_FormWithNode>();
        }

        [Key]
        public int FormId { get; set; }

        public int FlowId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Link { get; set; }

        public int Sort { get; set; }

        public virtual FLOW_WorkFlow FLOW_WorkFlow { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_FormWithRole> FLOW_FormWithRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_FormWithNode> FLOW_FormWithNode { get; set; }
    }
}
