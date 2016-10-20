namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notice_Notice
    {
        [Key]
        public int NR_ID { get; set; }

        public int UserId { get; set; }

        [StringLength(800)]
        public string Content { get; set; }

        public DateTime? Time { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public bool IsRead { get; set; }

        [Required]
        [StringLength(12)]
        public string NoticeType { get; set; }

        public virtual USER_UserInfo USER_UserInfo { get; set; }
    }
}
