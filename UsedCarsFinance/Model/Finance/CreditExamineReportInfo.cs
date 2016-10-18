using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Finance
{
    /// <summary>
    /// 信审报告实体   
    /// </summary>
    /// yand    16.04.26
    /// zouql   16.08.31    对各属性添加描述
    public class CreditExamineReportInfo
    {
        /// <summary>
        /// 信审标识
        /// </summary>
        public int? CreditExamineReportID { get; set; }

        /// <summary>
        /// 申请人姓名
        /// </summary>
        public int MainNameType { get; set; }

        /// <summary>
        /// 申请人姓名不一致的原因
        /// </summary>
        public string MainNameReason { get; set; }

        /// <summary>
        /// 申请人年龄
        /// </summary>
        public int MainAgeType { get; set; }

        /// <summary>
        /// 申请人年龄不一致的原因
        /// </summary>
        public string MainAgeReason { get; set; }

        /// <summary>
        /// 申请人手机号
        /// </summary>
        public int MainMobileType { get; set; }

        /// <summary>
        /// 申请人手机号不一致的原因
        /// </summary>
        public string MainMobileReason { get; set; }

        /// <summary>
        /// 申请人住宅地址
        /// </summary>
        public int MainLiveHouseAddressType { get; set; }

        /// <summary>
        /// 申请人住宅地址不一致的原因
        /// </summary>
        public string MainLiveHouseAddressReason { get; set; }

        /// <summary>
        /// 申请人对住址回答是否迅速流畅
        /// </summary>
        public int MainAnswerHouseAddressType { get; set; }

        /// <summary>
        /// 申请人购房价格
        /// </summary>
        public decimal? MainBuyHousePrice { get; set; }

        /// <summary>
        /// 申请人 -- 现市值
        /// </summary>
        public decimal? MainPresentWorth { get; set; }

        /// <summary>
        /// 申请人对所购车辆是否熟悉
        /// </summary>
        public int FamiliarCarType { get; set; }

        /// <summary>
        /// 申请人所购车用途
        /// </summary>
        public string CarUsed { get; set; }

        /// <summary>
        /// 申请人车辆用途是否合理
        /// </summary>
        public int Isreasonable { get; set; }

        /// <summary>
        /// 申请人单位
        /// </summary>
        public int? MainOfficeAddressType { get; set; }

        /// <summary>
        /// 申请人单位不一致的原因
        /// </summary>
        public string MainOfficeAddressReason { get; set; }

        /// <summary>
        /// 申请人任职
        /// </summary>
        public string MainTakeOffice { get; set; }

        /// <summary>
        /// 申请人工作年限
        /// </summary>
        public int? MainWorkingLife { get; set; }

        /// <summary>
        /// 申请人月平均收入
        /// </summary>
        public decimal? MainMonthlyIncome { get; set; }

        /// <summary>
        /// 申请人个人收入来源介绍
        /// </summary>
        public string IncomeStream { get; set; }

        /// <summary>
        /// 共同申请人姓名
        /// </summary>
        public int JointlyNameType { get; set; }

        /// <summary>
        /// 共同申请人姓名不一致的原因
        /// </summary>
        public string JointlyNameReason { get; set; }

        /// <summary>
        /// 共同申请人年龄
        /// </summary>
        public int JointlyAgeType { get; set; }

        /// <summary>
        /// 共同申请人年龄不一致的原因
        /// </summary>
        public string JointlyAgeReason { get; set; }

        /// <summary>
        /// 共同申请人手机号
        /// </summary>
        public int JointlyMobileType { get; set; }

        /// <summary>
        /// 共同申请人手机号不一致的原因
        /// </summary>
        public string JointlyMobileReason { get; set; }

        /// <summary>
        /// 共同申请人住宅地址
        /// </summary>
        public int JointlyLiveHouseAddressType { get; set; }

        /// <summary>
        /// 共同申请人住宅地址不一致的原因
        /// </summary>
        public string JointlyLiveHouseAddressReason { get; set; }

        /// <summary>
        /// 共同申请人对住址回答是否迅速流畅
        /// </summary>
        public int JointlyAnswerHouseAddressType { get; set; }

        /// <summary>
        /// 共同申请人住宅购买时价格
        /// </summary>
        public decimal? JointlyBuyHousePrice { get; set; }

        /// <summary>
        /// 共同申请人住宅现市值
        /// </summary>
        public decimal? JointlyPresentWorth { get; set; }

        /// <summary>
        /// 共同申请人单位
        /// </summary>
        public int? JointlyOfficeAddressType { get; set; }

        /// <summary>
        /// 共同申请人单位不一致的原因
        /// </summary>
        public string JointlyOfficeAddressReason { get; set; }

        /// <summary>
        /// 共同申请人任职
        /// </summary>
        public string JointlyTakeOffice { get; set; }

        /// <summary>
        /// 共同申请人工作年限
        /// </summary>
        public int? JointlyWorkingLife { get; set; }

        /// <summary>
        /// 共同申请人月平均收入
        /// </summary>
        public decimal? JointlyMonthlyIncome { get; set; }

        /// <summary>
        /// 其他信息
        /// </summary>
        public string OtherMessage { get; set; }

        /// <summary>
        /// 联系人信息
        /// </summary>
        public string ContactInformation { get; set; }

        /// <summary>
        /// 银行流水是否正常
        /// </summary>
        public int BankBillType { get; set; }

        /// <summary>
        /// 银行流水 -- 疑点客户解释
        /// </summary>
        public string AnswerBankBill { get; set; }

        /// <summary>
        /// 个人征信是否正常
        /// </summary>
        public int CreditType { get; set; }

        /// <summary>
        /// 个人征信 -- 疑点客户解释
        /// </summary>
        public string AnswerCredit { get; set; }

        /// <summary>
        /// 是否家访
        /// </summary>
        public int IsHomeVisitsType { get; set; }

        /// <summary>
        /// 家访要求
        /// </summary>
        public string HomeVisitsRequire { get; set; }

        /// <summary>
        /// 家访结果
        /// </summary>
        public string HomeVisitsResult { get; set; }

        /// <summary>
        /// 综述
        /// </summary>
        public string ComprehensiveEvaluation { get; set; }

        /// <summary>
        /// 现有车辆
        /// </summary>
        public string Car { get; set; }

        /// <summary>
        /// 融资标识
        /// </summary>
        public int FinanceId { get; set; }
    }
}
