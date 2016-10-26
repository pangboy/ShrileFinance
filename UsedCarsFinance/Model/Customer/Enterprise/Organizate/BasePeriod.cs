using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Customer.Enterprise.Organizate
{
    /// <summary>
    /// 基础段
    /// </summary>
    [BasePeriod_OR(ErrorMessage = "基础段 组织机构代码和登记注册号码不能同时为空")]
    [BasePeriod_TN(ErrorMessage = "基础段 登记注册号类型和登记注册号码需成对出现")]
    public class BasePeriod
    {
        public int Id { get; set; }

        /// <summary>
        /// 信息类别
        /// </summary>
        [Display(Name = "信息类别"), StringLength(1), Required, AN(ErrorMessage = "信息类别 类型错误")]
        public string InformationCategories
        {
            get
            {
                return "B";
            }
        }

        /// <summary>
        /// 客户号
        /// </summary>
        [Display(Name = "客户号"), StringLength(40), Required, AN(ErrorMessage = "客户号 类型错误")]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 管理行代码
        /// </summary>
        [Display(Name = "管理行代码"), StringLength(20), Required, AN(ErrorMessage = "管理行代码 类型错误")]
        public string ManagementerCode { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        [Display(Name = "客户类型"), StringLength(1), Required, AN(ErrorMessage = "客户类型 类型错误"), CustomerType(ErrorMessage = "客户类型 值错误")]
        public string CustomerType { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [Display(Name = "机构信用代码"), StringLength(18), AN(ErrorMessage = "机构信用代码 类型错误")]
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码"), StringLength(10), AN(ErrorMessage = "组织机构代码 类型错误"), OrganizateCode(ErrorMessage = "组织机构代码 验证未通过")]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        [Display(Name = "登记注册号类型"), StringLength(2), AN(ErrorMessage = "登记注册号类型 类型错误"), RegistrationNumberType(ErrorMessage = "登记注册号类型 值错误")]
        public string RegistrationNumberType { get; set; }

        /// <summary>
        /// 登记注册号码
        /// </summary>
        [Display(Name = "登记注册号码"), StringLength(20), ANC(ErrorMessage = "登记注册号码 类型错误")]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// 纳税人识别号（国税）
        /// </summary>
        [Display(Name = "纳税人识别号（国税）"), StringLength(20), ANC(ErrorMessage = "纳税人识别号（国税） 类型错误")]
        public string TaxpayerIdentifyIrsNumber { get; set; }

        /// <summary>
        /// 纳税人识别号（地税）
        /// </summary>
        [Display(Name = "纳税人识别号（地税）"), StringLength(20), ANC(ErrorMessage = "纳税人识别号（地税） 类型错误")]
        public string TaxpayerIdentifyLandNumber { get; set; }

        /// <summary>
        /// 开户许可证核准号
        /// </summary>
        [Display(Name = "开户许可证核准号"), StringLength(20), AN(ErrorMessage = "开户许可证核准号 类型错误")]
        public string NewaccountlicenseNumber { get; set; }

        /// <summary>
        /// 贷款卡编码
        /// </summary>
        [Display(Name = "贷款卡编码"), StringLength(16), AN(ErrorMessage = "贷款卡编码 类型错误")]
        public string LoanCardCode { get; set; }

        /// <summary>
        /// 数据提取日期
        /// </summary>
        [Display(Name = "数据提取日期"), StringLength(8), Required, N(ErrorMessage = "数据提取日期 类型错误")]
        public string DataExtractionDate { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [Display(Name = "预留字段"), StringLength(40), ANC(ErrorMessage = "预留字段 类型错误")]
        public string ReservedField { get; set; }

        public BasePeriod()
        {

        }
    }
}
