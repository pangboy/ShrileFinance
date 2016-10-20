namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_OperationLog
    {
        [Key]
        public long OL_ID { get; set; }

        public int ReferenceId { get; set; }

        public byte Type { get; set; }

        [StringLength(300)]
        public string Content { get; set; }

        public int UserId { get; set; }

        public DateTime AddDate { get; set; }

        public virtual SYS_Reference SYS_Reference { get; set; }

        public virtual USER_UserInfo USER_UserInfo { get; set; }
    }
}
