namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_Reference
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_Reference()
        {
            SYS_FileList = new HashSet<SYS_FileList>();
            SYS_OperationLog = new HashSet<SYS_OperationLog>();
        }

        [Key]
        public int ReferenceId { get; set; }

        public int? ReferencedId { get; set; }

        public int? ReferencedSid { get; set; }

        public int? ReferencedModule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_FileList> SYS_FileList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_OperationLog> SYS_OperationLog { get; set; }
    }
}
