namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FLOW_Action
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FLOW_Action()
        {
            FLOW_Log = new HashSet<FLOW_Log>();
            Notice_ActionNotice = new HashSet<Notice_ActionNotice>();
        }

        [Key]
        public int ActionId { get; set; }

        public int NodeId { get; set; }

        public int? Transfer { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public byte Type { get; set; }

        public byte? AllocationType { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Method { get; set; }

        [StringLength(50)]
        public string BusinessMethod { get; set; }

        public virtual FLOW_Node FLOW_Node { get; set; }

        public virtual FLOW_Node FLOW_Node1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_Log> FLOW_Log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notice_ActionNotice> Notice_ActionNotice { get; set; }
    }
}
