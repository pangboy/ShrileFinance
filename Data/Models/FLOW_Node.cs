namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FLOW_Node
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FLOW_Node()
        {
            FLOW_Action = new HashSet<FLOW_Action>();
            FLOW_Action1 = new HashSet<FLOW_Action>();
            FLOW_Instance = new HashSet<FLOW_Instance>();
            FLOW_Log = new HashSet<FLOW_Log>();
            FLOW_FormWithNode = new HashSet<FLOW_FormWithNode>();
        }

        [Key]
        public int NodeId { get; set; }

        public int FlowId { get; set; }

        public int? RoleId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_Action> FLOW_Action { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_Action> FLOW_Action1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_Instance> FLOW_Instance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_Log> FLOW_Log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_FormWithNode> FLOW_FormWithNode { get; set; }

        public virtual FLOW_WorkFlow FLOW_WorkFlow { get; set; }

        public virtual USER_Role USER_Role { get; set; }
    }
}
