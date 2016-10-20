namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CRET_ProcessUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreditId { get; set; }

        public int? User1 { get; set; }

        public int? User2 { get; set; }

        public int? User3 { get; set; }

        public int? User4 { get; set; }

        public int? User5 { get; set; }

        public int? User6 { get; set; }

        public virtual CRET_CreditInfo CRET_CreditInfo { get; set; }

        public virtual USER_UserInfo USER_UserInfo { get; set; }

        public virtual USER_UserInfo USER_UserInfo1 { get; set; }

        public virtual USER_UserInfo USER_UserInfo2 { get; set; }

        public virtual USER_UserInfo USER_UserInfo3 { get; set; }

        public virtual USER_UserInfo USER_UserInfo4 { get; set; }

        public virtual USER_UserInfo USER_UserInfo5 { get; set; }
    }
}
