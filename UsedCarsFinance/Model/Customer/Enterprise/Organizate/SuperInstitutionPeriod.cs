using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Customer.Enterprise.Organizate
{

    /// <summary>
    /// 上级机构（主管单位）段
    /// </summary>
    [SuperInstitutionPeriod_ROI(ErrorMessage = "上级机构（主管单位）段 登记注册号码、组织机构代码和机构信用代码不能同时为空")]
    public class SuperInstitutionPeriod
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
                return "I";
            }
        }

        /// <summary>
        /// 上级机构名称
        /// </summary>
        [Display(Name = "上级机构名称"), StringLength(80), Required, ANC(ErrorMessage = "上级机构名称类型错误")]
        public string SuperInstitutionsName { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        [Display(Name = "登记注册号类型"), StringLength(2), AN(ErrorMessage = "登记注册号类型类型错误")]
        public string RegistraterNumberType { get; set; }

        /// <summary>
        /// 登记注册号
        /// </summary>
        [Display(Name = "登记注册号"), StringLength(20), ANC(ErrorMessage = "登记注册号类型错误")]
        public string RegistraterNumber { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码"), StringLength(10), AN(ErrorMessage = "组织机构代码类型错误")]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [Display(Name = "机构信用代码"), StringLength(18), AN(ErrorMessage = "机构信用代码类型错误")]
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 信息更新日期
        /// </summary>
        [Display(Name = "信息更新日期"), StringLength(8), Required, N(ErrorMessage = "信息更新日期类型错误")]
        public string InformationUpdateDate { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [Display(Name = "预留字段"), StringLength(40), Required, ANC(ErrorMessage = "预留字段类型错误")]
        public string ReservedField { get; set; }
    }
}
