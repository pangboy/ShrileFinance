namespace Application.ViewModels.CustomerViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 基础段（家族）
    /// </summary>
    [FBasePeriod_MOR(ErrorMessage = "主要关系人证件号码和证件类型成对出现")]
    [FBasePeriod_FOR(ErrorMessage = "家族成员证件号码和证件类型成对出现")]
    public class FamilyBaseViewModel : FamilyDeleteRecord
    {
        /// <summary>
        /// 主要关系人姓名
        /// </summary>
        [Display(Name = "主要关系人姓名"), StringLength(80), Required, ANC(ErrorMessage = "主要关系人姓名类型错误")]
        public string MainParticipantName { get; set; }

        /// <summary>
        /// 家族成员姓名
        /// </summary>
        [Display(Name = "家族成员姓名"), StringLength(80), Required, ANC(ErrorMessage = "家族成员姓名类型错误")]
        public string FamilyMembersName { get; set; }
    }
}
