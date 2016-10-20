namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FLOW_Instance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FLOW_Instance()
        {
            FLOW_Log = new HashSet<FLOW_Log>();
        }

        [Key]
        public int InstanceId { get; set; }

        public int FlowId { get; set; }

        public int? CurrentNode { get; set; }

        public int? CurrentUser { get; set; }

        public int? ProcessUser { get; set; }

        public DateTime? ProcessTime { get; set; }

        public int? StartUser { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public byte Status { get; set; }

        [Column(TypeName = "text")]
        public string InstanceData { get; set; }

        [Column(TypeName = "xml")]
        public string KeyXML { get; set; }

        public virtual FLOW_Node FLOW_Node { get; set; }

        public virtual USER_UserInfo USER_UserInfo { get; set; }

        public virtual FLOW_WorkFlow FLOW_WorkFlow { get; set; }

        public virtual USER_UserInfo USER_UserInfo1 { get; set; }

        public virtual USER_UserInfo USER_UserInfo2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLOW_Log> FLOW_Log { get; set; }
    }
}
