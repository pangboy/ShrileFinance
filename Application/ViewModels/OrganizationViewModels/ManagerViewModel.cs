namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 高管及主要关系人段
    /// </summary>
    [ExecutivesMajorParticipantPeriod_NT(ErrorMessage = "高管及主要关系人段 证件号码和证件类型成对出现")]
    public class ManagerViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 关系人类型
        /// </summary>
        [Display(Name = "关系人类型"), StringLength(1), AN(ErrorMessage = "关系人类型 类型错误"), ParticipantType(ErrorMessage = "关系人类型 值错误")]
        public string Type { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名"), StringLength(80), ANC(ErrorMessage = "姓名 类型错误")]
        public string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [Display(Name = "证件类型"), StringLength(2), Required, AN(ErrorMessage = "证件类型 类型错误"), CertificateType(ErrorMessage = "证件类型 值错误")]
        public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [Display(Name = "证件号码"), StringLength(20), Required, ANC(ErrorMessage = "证件号码 类型错误")]
        public string CertificateCode { get; set; }

        /// <summary>
        /// 家族成员
        /// </summary>
        public IEnumerable<FamilyMemberViewModel> FamilyMembers { get; set; }
    }
}
