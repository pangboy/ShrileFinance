namespace Application.ViewModels.OrganizationViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 机构状态段
    /// </summary>
    public class StateViewModel
    {
        /// <summary>
        /// 企业规模
        /// </summary>
        [Display(Name = "企业规模"), StringLength(1), AN(ErrorMessage = "企业规模 类型错误"), EnterpriseScale(ErrorMessage = "企业规模 值错误")]
        public string EnterpriseScale { get; set; }

        /// <summary>
        /// 机构状态
        /// </summary>
        [Display(Name = "机构状态"), StringLength(1), AN(ErrorMessage = "机构状态 类型错误"), InstitutionsState(ErrorMessage = "机构状态 值错误")]
        public string InstitutionsState { get; set; }
    }
}
