using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Customer.Enterprise.Organizate
{
    /// <summary>
    /// 联络信息段
    /// </summary>
    public class ContactInformationPeriod
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
                return "E";
            }
        }

        /// <summary>
        /// 办公（生产、经营）地址
        /// </summary>
        [Display(Name = "办公（生产、经营）地址"), StringLength(80), ANC(ErrorMessage = "办公（生产、经营）地址类型错误")]
        public string OfficeAddress { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Display(Name = "联系电话"), StringLength(35), AN(ErrorMessage = "联系电话类型错误")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// 财务部联系电话
        /// </summary>
        [Display(Name = "财务部联系电话"), StringLength(35), AN(ErrorMessage = "财务部联系电话类型错误")]
        public string FinancialContactPhone { get; set; }

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
