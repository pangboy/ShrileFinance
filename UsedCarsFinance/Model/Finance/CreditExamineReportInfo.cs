using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Finance
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



    /// <summary>
    /// 新信审标识
    /// </summary>
    public class CreditExamineReportInfos {
        /// <summary>
        /// 融资标识
        /// </summary>
        public int FinanceId { get; set; }

        /// <summary>
        /// 信审标识
        /// </summary>
        public int CreditExamineReportID { get; set; }

        /// <summary>
        /// 递交资料渠道
        /// </summary>
        public string SubmitDataChannel { get; set; }

        /// <summary>
        /// 牌照登记至
        /// </summary>
        public string LicenseRegistration { get; set; }

        /// <summary>
        /// 产品种类
        /// </summary>
        public string ProductCategorie { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNumber { get; set; }

        /// <summary>
        /// 产品详解
        /// </summary>
        public string ProductExplain { get; set; }

        /// <summary>
        /// 承租人姓名
        /// </summary>
        public string LesseeName { get; set; }

        /// <summary>
        /// 承租人身份证
        /// </summary>
        public string LesseeIdCard { get; set; }

        /// <summary>
        /// 承租人手机号
        /// </summary>
        public string LesseeMobile { get; set; }

        /// <summary>
        /// 共借人① 姓名
        /// </summary>
        public string CommonBorrwerName1 { get; set; }

        /// <summary>
        /// 共借人②姓名
        /// </summary>
        public string CommonBorrwerName2 { get; set; }

        /// <summary>
        /// 共借人③姓名
        /// </summary>
        public string CommonBorrwerName3 { get; set; }

        /// <summary>
        /// 保证人③姓名
        /// </summary>
        public string Guarantor1 { get; set; }

        /// <summary>
        /// 保证人③姓名
        /// </summary>
        public string Guarantor2 { get; set; }

        /// <summary>
        /// 保证人③姓名
        /// </summary>
        public string Guarantor3 { get; set; }

        /// <summary>
        /// 客户类别
        /// </summary>
        public string CustomerCategory { get; set; }

        /// <summary>
        /// 客户具体行业
        /// </summary>
        public string DetailedIndustry { get; set; }

        /// <summary>
        /// 户籍所在地
        /// </summary>
        public string CensusRegisterSeat { get; set; }

        /// <summary>
        /// 居住情况
        /// </summary>
        public string LivingSituation { get; set; }

        /// <summary>
        /// 工作情况
        /// </summary>
        public string WorkingCondition { get; set; }

        /// <summary>
        /// 收入来源类型（经营）
        /// </summary>
        public string IncomeSourceBusiness { get; set; }

        /// <summary>
        /// 收入来源类型（工资）
        /// </summary>
        public string IncomeSourceWage { get; set; }

        /// <summary>
        /// 月收入
        /// </summary>
        public string MonthlyIncome { get; set; }

        /// <summary>
        /// 核算依据
        /// </summary>
        public string AccountingBasis { get; set; }

        /// <summary>
        /// 网核价格
        /// </summary>
        public string NetnuclearPrice { get; set; }

        /// <summary>
        /// 核批价格
        /// </summary>
        public string NuclearGroupPrice { get; set; }

        /// <summary>
        /// 终审额度
        /// </summary>
        public string FinalLine { get; set; }

        /// <summary>
        /// 信用状况
        /// </summary>
        public string CreditCondition { get; set; }

        /// <summary>
        /// 特别说明
        /// </summary>
        public string SpecialInstructions { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public string Margin { get; set; }

        /// <summary>
        /// 增加保证金原因
        /// </summary>
        public string IncreaseMarginReson { get; set; }

        /// <summary>
        /// 年龄区间
        /// </summary>
        public string AgeRange { get; set; }

        /// <summary>
        /// 年龄（其他）
        /// </summary>
        public string AgeRangeOther { get; set; }

        /// <summary>
        /// 婚姻
        /// </summary>
        public string MarriageState { get; set; }

        /// <summary>
        /// 居住
        /// </summary>
        public string Live { get; set; }

        /// <summary>
        /// 房产
        /// </summary>
        public string RealEstate { get; set; }

        /// <summary>
        /// 工作
        /// </summary>
        public string Work { get; set; }

        /// <summary>
        /// 家访
        /// </summary>
        public string FamilyVisit { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public string CapitalUse { get; set; }

        /// <summary>
        /// 电询
        /// </summary>
        public string CableInquiry { get; set; }

        /// <summary>
        /// 结论
        /// </summary>
        public string Conclusion { get; set; }

        /// <summary>
        /// 调查意见
        /// </summary>
        public string SurveyOpinion { get; set; }

        /// <summary>
        /// 拒单 原因
        /// </summary>
        public string SurveyOpinionReson { get; set; }

        /// <summary>
        /// 初审人
        /// </summary>
        public string TrialPerson { get; set; }

        /// <summary>
        /// 复审人
        /// </summary>
        public string ReviewPerson { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public string ApprovePerson { get; set; }

        /// <summary>
        /// 终审人
        /// </summary>
        public string FinalPerson { get; set; }
    }
}
