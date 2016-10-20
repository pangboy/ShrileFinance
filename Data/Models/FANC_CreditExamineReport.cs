namespace Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FANC_CreditExamineReport
    {
        [Key]
        public int CreditExamineReportID { get; set; }

        public int? MainNameType { get; set; }

        [StringLength(50)]
        public string MainNameReason { get; set; }

        public int? MainAgeType { get; set; }

        [StringLength(50)]
        public string MainAgeReason { get; set; }

        public int? MainMobileType { get; set; }

        [StringLength(50)]
        public string MainMobileReason { get; set; }

        public int? MainLiveHouseAddressType { get; set; }

        [StringLength(50)]
        public string MainLiveHouseAddressReason { get; set; }

        public int? MainAnswerHouseAddressType { get; set; }

        public decimal? MainBuyHousePrice { get; set; }

        public decimal? MainPresentWorth { get; set; }

        public int? FamiliarCarType { get; set; }

        [StringLength(200)]
        public string CarUsed { get; set; }

        public int? Isreasonable { get; set; }

        public int? MainOfficeAddressType { get; set; }

        [StringLength(50)]
        public string MainTakeOffice { get; set; }

        public int? MainWorkingLife { get; set; }

        public decimal? MainMonthlyIncome { get; set; }

        [StringLength(200)]
        public string IncomeStream { get; set; }

        public int? JointlyNameType { get; set; }

        [StringLength(50)]
        public string JointlyNameReason { get; set; }

        public int? JointlyAgeType { get; set; }

        [StringLength(50)]
        public string JointlyAgeReason { get; set; }

        public int? JointlyMobileType { get; set; }

        [StringLength(50)]
        public string JointlyMobileReason { get; set; }

        public int? JointlyLiveHouseAddressType { get; set; }

        [StringLength(50)]
        public string JointlyLiveHouseAddressReason { get; set; }

        public int? JointlyAnswerHouseAddressType { get; set; }

        public decimal? JointlyBuyHousePrice { get; set; }

        public decimal? JointlyPresentWorth { get; set; }

        public int? JointlyOfficeAddressType { get; set; }

        [StringLength(50)]
        public string JointlyOfficeAddressReason { get; set; }

        [StringLength(50)]
        public string JointlyTakeOffice { get; set; }

        public int? JointlyWorkingLife { get; set; }

        public decimal? JointlyMonthlyIncome { get; set; }

        [StringLength(200)]
        public string OtherMessage { get; set; }

        [Column(TypeName = "text")]
        public string ContactInformation { get; set; }

        public int? BankBillType { get; set; }

        [StringLength(500)]
        public string AnswerBankBill { get; set; }

        public int? CreditType { get; set; }

        [StringLength(500)]
        public string AnswerCredit { get; set; }

        public int? IsHomeVisitsType { get; set; }

        [StringLength(500)]
        public string HomeVisitsRequire { get; set; }

        [StringLength(500)]
        public string HomeVisitsResult { get; set; }

        [StringLength(500)]
        public string ComprehensiveEvaluation { get; set; }

        public int FinanceID { get; set; }

        [StringLength(50)]
        public string Car { get; set; }

        [StringLength(50)]
        public string MainOfficeAddressReason { get; set; }

        public virtual FANC_FinanceInfo FANC_FinanceInfo { get; set; }
    }
}
