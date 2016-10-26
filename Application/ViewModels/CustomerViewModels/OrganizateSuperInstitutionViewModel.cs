namespace Application.ViewModels.CustomerViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 上级机构（主管单位）段
    /// </summary>
    [SuperInstitutionPeriod_ROI(ErrorMessage = "上级机构（主管单位）段 登记注册号码、组织机构代码和机构信用代码不能同时为空")]
    public class OrganizateSuperInstitutionViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 上级机构名称
        /// </summary>
        [Display(Name = "上级机构名称"), StringLength(80), Required, ANC(ErrorMessage = "上级机构名称 类型错误")]
        public string SuperInstitutionsName { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        [Display(Name = "登记注册号类型"), StringLength(2), AN(ErrorMessage = "登记注册号类型 类型错误"), RegistrationNumberType(ErrorMessage = "登记注册号类型 值错误")]
        public string RegistraterNumberType { get; set; }

        /// <summary>
        /// 登记注册号
        /// </summary>
        [Display(Name = "登记注册号"), StringLength(20), ANC(ErrorMessage = "登记注册号 类型错误")]
        public string RegistraterNumber { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码"), StringLength(10), AN(ErrorMessage = "组织机构代码 类型错误")]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [Display(Name = "机构信用代码"), StringLength(18), AN(ErrorMessage = "机构信用代码 类型错误")]
        public string InstitutionCreditCode { get; set; }

        public virtual OrganizateBaseViewModel OrganizateBaseViewModel { get; set; }
    }
}
