namespace Application.ViewModels.OrganizationViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 联络信息段
    /// </summary>
    public class ContactViewModel
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
    }
}
