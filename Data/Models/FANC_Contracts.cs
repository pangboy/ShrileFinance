namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FANC_Contracts
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FinanceId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string ContractMainCode { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime ContractCreateDateTime { get; set; }

        public virtual FANC_FinanceInfo FANC_FinanceInfo { get; set; }
    }
}
