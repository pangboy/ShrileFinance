namespace Application.ViewModels.CustomerViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 删除报文记录
    /// </summary>
    public class OrganizateDeleteRecordViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 客户号
        /// </summary>
        [Display(Name = "客户号"), StringLength(1), Required, AN(ErrorMessage = "客户号 类型错误")]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 需删除的信息类别
        /// </summary>
        [Display(Name = "需删除的信息类别"), StringLength(1), AN(ErrorMessage = "需删除的信息类别 类型错误"), NendDeleteInformationCategories(ErrorMessage = "需删除的信息类别 值错误")]
        public string NendDeleteInformationCategories { get; set; }

        /// <summary>
        /// 关系人类型
        /// </summary>
        [Display(Name = "关系人类型"), StringLength(1), AN(ErrorMessage = "关系人类型 类型错误"), ParticipantType(ErrorMessage = "关系人类型 值错误")]
        public string ParticipantType { get; set; }

        /// <summary>
        /// 信息更新日期
        /// </summary>
        [Display(Name = "信息更新日期"), StringLength(8), Required, N(ErrorMessage = "信息更新日期 类型错误")]
        public string InformationUpdateDate { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [Display(Name = "预留字段"), StringLength(40), Required, ANC(ErrorMessage = "预留字段 类型错误")]
        public string ReservedField { get; set; }
    }
}
