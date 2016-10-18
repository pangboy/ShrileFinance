using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Customer.Enterprise.Organizate
{
    /// <summary>
    /// 机构状态段
    /// </summary>
    public class InstitutionsStatePeriod
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 信息记录类型
        /// </summary>
        [Display(Name = "信息记录类型"), StringLength(1), Required, AN(ErrorMessage = "信息记录类型类型错误")]
        public string InformationCategories
        {
            get
            {
                return "D";
            }
        }

        /// <summary>
        /// 基本户状态
        /// </summary>
        [Display(Name = "基本户状态"), StringLength(1), AN(ErrorMessage = "基本户状态类型错误")]
        public string BasicAccountState { get; set; }

        /// <summary>
        /// 企业规模
        /// </summary>
        [Display(Name = "企业规模"), StringLength(1), AN(ErrorMessage = "企业规模类型错误")]
        public string EnterpriseScale { get; set; }

        /// <summary>
        /// 机构状态
        /// </summary>
        [Display(Name = "机构状态"), StringLength(1), AN(ErrorMessage = "机构状态类型错误")]
        public string InstitutionsState { get; set; }

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
