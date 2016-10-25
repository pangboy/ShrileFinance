using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Customer.Enterprise.Organizate
{
    /// <summary>
    /// 主要关联企业段
    /// </summary>
    [MainAssociatedEnterprisePerid_ROI(ErrorMessage = "主要关联企业段 登记注册号码、组织机构代码和机构信用代码不能同时为空")]
    public class MainAssociatedEnterprisePerid
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 信息类别
        /// </summary>
        [Display(Name = "信息类别"), StringLength(1), Required, AN(ErrorMessage = "信息类别类型错误")]
        public string InformationCategories
        {
            get
            {
                return "H";
            }
        }

        /// <summary>
        /// 关联类型
        /// </summary>
        [Display(Name = "关联类型"), StringLength(2), Required, AN(ErrorMessage = "关联类型类型错误")]
        public string AssociatedType { get; set; }

        /// <summary>
        /// 关联企业名称
        /// </summary>
        [Display(Name = "关联企业名称"), StringLength(80), Required, ANC(ErrorMessage = "关联企业名称类型错误")]
        public string AssociatedEnterpriseName { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        [Display(Name = "登记注册号类型"), StringLength(2), AN(ErrorMessage = "登记注册号类型类型错误")]
        public string RegistraterNumberType { get; set; }

        /// <summary>
        /// 登记注册号码
        /// </summary>
        [Display(Name = "登记注册号码"), StringLength(20), ANC(ErrorMessage = "登记注册号码类型错误")]
        public string RegistraterNumber { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码"), StringLength(10), MinLength(10), AN(ErrorMessage = "组织机构代码类型错误")]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [Display(Name = "机构信用代码"), StringLength(18), MinLength(18), AN(ErrorMessage = "机构信用代码类型错误")]
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 信息更新日期
        /// </summary>
        [Display(Name = "信息更新日期"), StringLength(8), Required, N(ErrorMessage = "信息更新日期类型错误")]
        public string InformationUpdateDate { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [Display(Name = "预留字段"), StringLength(40), ANC(ErrorMessage = "预留字段类型错误")]
        public string ReservedField { get; set; }
    }
}
