using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Customer.Enterprise.Organizate
{
    /// <summary>
    /// 重要股东段
    /// </summary>
    public class MajorShareholdersPeriod
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
                return "G";
            }
        }

        /// <summary>
        /// 股东类型
        /// </summary>
        [Display(Name = "股东类型"), StringLength(1), Required, AN(ErrorMessage = "股东类型类型错误")]
        public string ShareholdersType { get; set; }

        /// <summary>
        /// 股东名称
        /// </summary>
        [Display(Name = "股东名称"), StringLength(80), Required, ANC(ErrorMessage = "股东名称类型错误")]
        public string ShareholdersName { get; set; }

        /// <summary>
        /// 证件类型/登记注册号类型
        /// </summary>
        [Display(Name = "证件类型/登记注册号类型"), StringLength(2), AN(ErrorMessage = "证件类型/登记注册号类型类型错误")]
        public string RegistraterType { get; set; }

        /// <summary>
        /// 证件号码/登记注册号码
        /// </summary>
        [Display(Name = "证件号码/登记注册号码"), StringLength(20), ANC(ErrorMessage = "证件号码/登记注册号码类型错误")]
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Display(Name = "组织机构代码"), StringLength(10), MinLength(10), AN(ErrorMessage = "组织机构代码类型错误")]
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        [Display(Name = "机构信用代码"), StringLength(18), MinLength(10), AN(ErrorMessage = "机构信用代码类型错误")]
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 持股比例
        /// </summary>
        [Display(Name = "持股比例"), StringLength(10), AN(ErrorMessage = "持股比例类型错误")]
        public string SharesProportion { get; set; }

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
