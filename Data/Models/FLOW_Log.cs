namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FLOW_Log
    {
        [Key]
        public long LogId { get; set; }

        public int InstanceId { get; set; }

        public int NodeId { get; set; }

        public int ActionId { get; set; }

        public int ProcessUser { get; set; }

        public DateTime ProcessTime { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        [StringLength(500)]
        public string InOpinion { get; set; }

        [StringLength(500)]
        public string ExOpinion { get; set; }

        public virtual FLOW_Action FLOW_Action { get; set; }

        public virtual FLOW_Instance FLOW_Instance { get; set; }

        public virtual FLOW_Node FLOW_Node { get; set; }

        public virtual USER_UserInfo USER_UserInfo { get; set; }
    }
}
