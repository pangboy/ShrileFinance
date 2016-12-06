namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 重要股东段
    /// </summary>
    [MajorShareholdersPeriod_NT(ErrorMessage = "重要股东段 证件号码/登记注册号码和证件类型/登记注册号类型成对出现")]
    [MajorShareholdersPeriod_ROI(ErrorMessage = "重要股东段 当股东类型为机构时，登记注册号码、组织机构代码、机构信用代码必填其一")]
    [MajorShareholdersPeriod_TR(ErrorMessage = "证件类型/登记注册号类型 值错误")]
    public class StockholderViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 股东类型
        /// </summary>
        [Display(Name = "股东类型"), StringLength(1), Required, AN(ErrorMessage = "股东类型 类型错误"), ShareholdersType(ErrorMessage = "股东类型 值错误")]
        public string ShareholdersType { get; set; }

        /// <summary>
        /// 股东名称
        /// </summary>
        [Display(Name = "股东名称"), StringLength(80), Required, ANC(ErrorMessage = "股东名称 类型错误")]
        public string ShareholdersName { get; set; }

        /// <summary>
        /// 证件类型/登记注册号类型
        /// </summary>
        [Display(Name = "证件类型/登记注册号类型"), StringLength(2), AN(ErrorMessage = "证件类型/登记注册号类型 类型错误")]
        public string RegistraterType { get; set; }

        /// <summary>
        /// 证件号码/登记注册号码
        /// </summary>
        [Display(Name = "证件号码/登记注册号码"), StringLength(20), ANC(ErrorMessage = "证件号码/登记注册号码 类型错误")]
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码"), StringLength(10), MinLength(10), AN(ErrorMessage = "组织机构代码 类型错误")]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [Display(Name = "机构信用代码"), StringLength(18), MinLength(10), AN(ErrorMessage = "机构信用代码 类型错误")]
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 持股比例
        /// </summary>
        [Display(Name = "持股比例"), DataType(DataType.Currency)]
        public decimal? SharesProportion { get; set; }

        /// <summary>
        /// 家族成员
        /// </summary>
        public IEnumerable<FamilyMemberViewModel> FamilyMembers { get; set; }
    }
}
