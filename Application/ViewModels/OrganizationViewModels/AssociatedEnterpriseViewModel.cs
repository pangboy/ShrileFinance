namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 主要关联企业段
    /// </summary>
    [MainAssociatedEnterprisePerid_ROI(ErrorMessage = "主要关联企业段 登记注册号码、组织机构代码和机构信用代码不能同时为空")]
    public class AssociatedEnterpriseViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 关联类型
        /// </summary>
        [Display(Name = "关联类型"), StringLength(2), Required, AN(ErrorMessage = "关联类型 类型错误"), AssociatedType(ErrorMessage = "关联类型 值错误")]
        public string AssociatedType { get; set; }

        /// <summary>
        /// 关联企业名称
        /// </summary>
        [Display(Name = "关联企业名称"), StringLength(80), Required, ANC(ErrorMessage = "关联企业名称 类型错误")]
        public string Name { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        [Display(Name = "登记注册号类型"), StringLength(2), AN(ErrorMessage = "登记注册号类型 类型错误"), RegistrationNumberType(ErrorMessage = "登记注册号类型 值错误")]
        public string RegistraterType { get; set; }

        /// <summary>
        /// 登记注册号码
        /// </summary>
        [Display(Name = "登记注册号码"), StringLength(20), ANC(ErrorMessage = "登记注册号码 类型错误")]
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码"), StringLength(10), MinLength(10), AN(ErrorMessage = "组织机构代码 类型错误")]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [Display(Name = "机构信用代码"), StringLength(18), MinLength(18), AN(ErrorMessage = "机构信用代码 类型错误")]
        public string InstitutionCreditCode { get; set; }
    }
}
