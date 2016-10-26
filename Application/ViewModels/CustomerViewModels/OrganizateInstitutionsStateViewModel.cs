namespace Application.ViewModels.CustomerViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 机构状态段
    /// </summary>
    public class OrganizateInstitutionsStateViewModel
    {
        /// <summary>
        /// 基本户状态
        /// </summary>
        [Display(Name = "基本户状态"), StringLength(1), AN(ErrorMessage = "基本户状态 类型错误"), BasicAccountState(ErrorMessage = "基本户状态 值错误")]
        public string BasicAccountState { get; set; }

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

        public virtual OrganizateBaseViewModel OrganizateBaseViewModel { get; set; }
    }
}
