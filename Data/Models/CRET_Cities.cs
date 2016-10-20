namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CRET_Cities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityCode { get; set; }

        [StringLength(100)]
        public string CityName { get; set; }

        public int? ProvinceCode { get; set; }

        [StringLength(100)]
        public string ProvinceName { get; set; }
    }
}
