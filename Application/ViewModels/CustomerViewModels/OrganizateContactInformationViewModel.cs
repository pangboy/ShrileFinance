namespace Application.ViewModels.CustomerViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 联络信息段
    /// </summary>
    public class OrganizateContactInformationViewModel
    {
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

        public virtual OrganizateBaseViewModel OrganizateBaseViewModel { get; set; }
    }
}
