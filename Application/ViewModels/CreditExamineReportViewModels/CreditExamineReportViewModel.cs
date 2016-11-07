namespace Application.ViewModels.CreditExamineReportViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 信审报告
    /// </summary>
    public class CreditExamineReportViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 递交资料渠道
        /// </summary>
        public string SubmitDataChannel { get; set; }

        /// <summary>
        /// 牌照登记至
        /// </summary>
        [Required(ErrorMessage = "牌照登记至 不可为空")]
        public LicenseRegistrationEnum LicenseRegistration { get; set; }

        /// <summary>
        /// 产品种类
        /// </summary>
        [Required(ErrorMessage = "产品种类 不可为空")]
        public ProductCategorieEnum ProductCategorie { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        [Required(ErrorMessage = "产品编号 不可为空")]
        public string ProductNumber { get; set; }

        /// <summary>
        /// 产品详解
        /// </summary>
        [Required(ErrorMessage = "产品详解 不可为空")]
        public string ProductExplain { get; set; }

        /// <summary>
        /// 承租人姓名
        /// </summary>
        [Required(ErrorMessage = "承租人姓名 不可为空")]
        public string LesseeName { get; set; }

        /// <summary>
        /// 承租人身份证
        /// </summary>
        [Required(ErrorMessage = "承租人身份证 不可为空"),IdCard(ErrorMessage = "承租人身份证不合法")]
        public string LesseeIdCard { get; set; }

        /// <summary>
        /// 承租人手机号
        /// </summary>
        [Required(ErrorMessage = "承租人手机号 不可为空")]
        public string LesseeMobile { get; set; }

        /// <summary>
        /// 共借人① 姓名
        /// </summary>
        [Required(ErrorMessage = "共借人① 姓名 不可为空")]
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
        /// 保证人① 姓名
        /// </summary>
        [Required(ErrorMessage = "保证人① 姓名 不可为空")]
        public string Guarantor1 { get; set; }

        /// <summary>
        /// 保证人②姓名
        /// </summary>
        public string Guarantor2 { get; set; }

        /// <summary>
        /// 保证人③姓名
        /// </summary>
        public string Guarantor3 { get; set; }

        /// <summary>
        /// 客户类别
        /// </summary>
        [Required(ErrorMessage = "客户类别 不可为空")]
        public CustomerCategoryEnum CustomerCategory { get; set; }

        /// <summary>
        /// 客户具体行业
        /// </summary>
        [Required(ErrorMessage = "客户具体行业 不可为空")]
        public string DetailedIndustry { get; set; }

        /// <summary>
        /// 户籍所在地
        /// </summary>
        [Required(ErrorMessage = "户籍所在地 不可为空")]
        public CensusRegisterSeatEnum CensusRegisterSeat { get; set; }

        /// <summary>
        /// 居住情况
        /// </summary>
        [Required(ErrorMessage = "居住情况 不可为空")]
        public string LivingSituation { get; set; }

        /// <summary>
        /// 工作情况
        /// </summary>
        [Required(ErrorMessage = "工作情况 不可为空")]
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
        [Required(ErrorMessage = "月收入 不可为空")]
        public string MonthlyIncome { get; set; }

        /// <summary>
        /// 核算依据
        /// </summary>
        [Required(ErrorMessage = "核算依据 不可为空")]
        public string AccountingBasis { get; set; }

        /// <summary>
        /// 网核价格
        /// </summary>
        [Required(ErrorMessage = "网核价格 不可为空")]
        public string NetnuclearPrice { get; set; }

        /// <summary>
        /// 核批价格
        /// </summary>
        [Required(ErrorMessage = "核批价格 不可为空")]
        public string NuclearGroupPrice { get; set; }

        /// <summary>
        /// 终审额度
        /// </summary>
        [Required(ErrorMessage = "终审额度 不可为空")]
        public string FinalLine { get; set; }

        /// <summary>
        /// 信用状况
        /// </summary>
        [Required(ErrorMessage = "信用状况 不可为空")]
        public CreditConditionEnum CreditCondition { get; set; }

        /// <summary>
        /// 特别说明
        /// </summary>
        [Required(ErrorMessage = "特别说明 不可为空")]
        public string SpecialInstructions { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        [Required(ErrorMessage = "保证金 不可为空")]
        public MarginEnum Margin { get; set; }

        /// <summary>
        /// 增加保证金原因
        /// </summary>
        [Required(ErrorMessage = "保证金 不可为空")]
        public string IncreaseMarginReson { get; set; }

        /// <summary>
        /// 年龄区间
        /// </summary>
        public AgeRangeEnum AgeRange { get; set; }

        /// <summary>
        /// 年龄（其他）
        /// </summary>
        public string AgeRangeOther { get; set; }

        /// <summary>
        /// 婚姻
        /// </summary>
        public MarriageStateEnum MarriageState { get; set; }

        /// <summary>
        /// 居住
        /// </summary>
        public LiveEnum Live { get; set; }

        /// <summary>
        /// 房产
        /// </summary>
        public RealEstateEnum RealEstate { get; set; }

        /// <summary>
        /// 工作
        /// </summary>
        public string Work { get; set; }

        /// <summary>
        /// 家访
        /// </summary>
        public FamilyVisitEnum FamilyVisit { get; set; }

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
        public SurveyOpinionEnum SurveyOpinion { get; set; }

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

        /// <summary>
        /// 融资标识
        /// </summary>
        public Guid FinanceId { get; set; }
    }

    /// <summary>
    /// 牌照登记至 枚举
    /// </summary>
    public enum LicenseRegistrationEnum
    {
        承租人名下,
        渠道个人名下,
        渠道企业名下,
        晟融名下
    }

    /// <summary>
    /// 产品种类 枚举
    /// </summary>
    public enum ProductCategorieEnum
    {
        新车交易贷,
        二手车交易贷,
        车抵贷,
        押车贷,
        快速贷,
        以租代购
    }

    /// <summary>
    /// 客户类别 枚举
    /// </summary>
    public enum CustomerCategoryEnum
    {
        优良职业,
        标准受薪,
        自雇人士,
        自由职业
    }

    /// <summary>
    /// 户籍所在地 枚举
    /// </summary>
    public enum CensusRegisterSeatEnum
    {
        本地户籍,
        异地户籍
    }

    /// <summary>
    /// 信用状况 枚举
    /// </summary>
    public enum CreditConditionEnum
    {
        良好,
        _90以上,
        _60以上,
        累6,
        呆账
    }

    /// <summary>
    /// 保证金 枚举
    /// </summary>
    public enum MarginEnum
    {
        _5保证金,
        _10保证金
    }

    /// <summary>
    /// 年龄区间 枚举
    /// </summary>
    public enum AgeRangeEnum
    {
        _20to28岁,
        _28to55岁,
        _55to65岁,
        其他
    }

    /// <summary>
    /// 婚姻 枚举
    /// </summary>
    public enum MarriageStateEnum
    {
        已婚,
        离异,
        单身
    }

    /// <summary>
    /// 居住 枚举
    /// </summary>
    public enum LiveEnum
    {
        自有房产,
        亲属房产,
        租房,
        其它
    }

    /// <summary>
    /// 工作 枚举
    /// </summary>
    public enum RealEstateEnum
    {
        同一单位5年以上,
        营业执照满3年,
        其它
    }

    /// <summary>
    /// 家访 枚举
    /// </summary>
    public enum FamilyVisitEnum
    {
        无需家访,
        需要家访,
        信息符合,
        信息不符合
    }

    /// <summary>
    /// 家访 枚举
    /// </summary>
    public enum SurveyOpinionEnum
    {
        通过,
        建议通过,
        例外通过,
        拒单
    }

}
