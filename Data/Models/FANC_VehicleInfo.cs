namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FANC_VehicleInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FinanceId { get; set; }

        [Required]
        [StringLength(50)]
        public string VehicleKey { get; set; }

        [StringLength(50)]
        public string BuyCarPrice { get; set; }

        [StringLength(50)]
        public string RegisterCity { get; set; }

        [StringLength(50)]
        public string SallerName { get; set; }

        [StringLength(50)]
        public string PlateNo { get; set; }

        [StringLength(50)]
        public string FrameNo { get; set; }

        [StringLength(50)]
        public string EngineNo { get; set; }

        [StringLength(50)]
        public string RegisterDate { get; set; }

        [StringLength(50)]
        public string RunningMiles { get; set; }

        [StringLength(50)]
        public string FactoryDate { get; set; }

        [StringLength(50)]
        public string BuyCarYears { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public virtual FANC_FinanceInfo FANC_FinanceInfo { get; set; }
    }
}
