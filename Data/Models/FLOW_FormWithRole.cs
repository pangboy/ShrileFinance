namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FLOW_FormWithRole
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FormId { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte Status { get; set; }

        public virtual FLOW_Form FLOW_Form { get; set; }

        public virtual USER_Role USER_Role { get; set; }
    }
}
