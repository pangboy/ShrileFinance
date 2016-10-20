namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CRET_PartnerInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreditId { get; set; }

        public decimal Bail { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string ProxyArea { get; set; }

        [StringLength(100)]
        public string VehicleManage { get; set; }

        [StringLength(50)]
        public string ControllerName { get; set; }

        [StringLength(50)]
        public string ControllerIdentity { get; set; }

        [StringLength(50)]
        public string ControllerTelephone { get; set; }

        [StringLength(50)]
        public string Province { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public virtual CRET_CreditInfo CRET_CreditInfo { get; set; }
    }
}
