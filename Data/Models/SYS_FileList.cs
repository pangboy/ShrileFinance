namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_FileList
    {
        [Key]
        public int FL_ID { get; set; }

        public int? ReferenceId { get; set; }

        [Required]
        [StringLength(100)]
        public string OldName { get; set; }

        [Required]
        [StringLength(100)]
        public string NewName { get; set; }

        [Required]
        [StringLength(10)]
        public string ExtName { get; set; }

        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        public DateTime AddDate { get; set; }

        public virtual SYS_Reference SYS_Reference { get; set; }
    }
}
