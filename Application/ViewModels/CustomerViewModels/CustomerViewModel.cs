namespace Application.ViewModels.CustomerViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CustomerViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid Id { get; set; }

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
        [Display(Name = "客户类型"), StringLength(1), Required, AN(ErrorMessage = "客户类型 类型错误")]
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
        [Display(Name = "登记注册号类型"), StringLength(2), AN(ErrorMessage = "登记注册号类型 类型错误")]
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
        /// 基本属性信息
        /// </summary>
        public virtual OrganizateBasicPropertiesViewModel BasicProperties { get; set; }

        /// <summary>
        /// 联络信息
        /// </summary>
        public virtual OrganizateContactInformationViewModel ContactInformation { get; set; }

        /// <summary>
        /// 机构状态
        /// </summary>
        public virtual OrganizateInstitutionsStateViewModel InstitutionsState { get; set; }

        /// <summary>
        /// 高级主管
        /// </summary>
        public virtual ICollection<OrganizateExecutivesMajorParticipantViewModel> ExecutivesMajorParticipant { get; set; }

        /// <summary>
        /// 重要股东
        /// </summary>
        public virtual ICollection<OrganizateMajorShareholdersViewModel> Shareholders { get; set; }

        /// <summary>
        /// 主要关联企业
        /// </summary>
        public virtual ICollection<OrganizateMainAssociatedEnterpriseViewModel> MainAssociatedEnterprise { get; set; }

        /// <summary>
        /// 上级机构
        /// </summary>
        public virtual ICollection<OrganizateSuperInstitutionViewModel> SuperInstitution { get; set; }
    }
}
