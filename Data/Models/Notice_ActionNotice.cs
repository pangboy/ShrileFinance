namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notice_ActionNotice
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ActionID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        public int? FindPeopleType { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool SystemNotice { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool EmailNotice { get; set; }

        public virtual FLOW_Action FLOW_Action { get; set; }
    }
}
