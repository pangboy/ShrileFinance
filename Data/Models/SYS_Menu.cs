namespace Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core.Entities.Identity;

    public partial class SYS_Menu
    {
        public SYS_Menu()
        {
            USER_Role = new HashSet<AppRole>();
        }

        [Key]
        public int MN_ID { get; set; }

        public int? ParentId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Link { get; set; }

        public byte Sort { get; set; }

        public virtual ICollection<AppRole> USER_Role { get; set; }
    }
}
