using System.ComponentModel.DataAnnotations;

namespace Model.Customer.Enterprise.Family
{
    /// <summary>
    /// 基础段
    /// </summary>
    public class BasePeriod : DeleteRecord
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
