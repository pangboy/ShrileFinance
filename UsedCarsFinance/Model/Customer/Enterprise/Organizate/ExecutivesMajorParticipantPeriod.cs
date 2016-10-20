using System.ComponentModel.DataAnnotations;

namespace Model.Customer.Enterprise.Organizate
{
    /// <summary>
    /// 高管及主要关系人段
    /// </summary>
    [ExecutivesMajorParticipantPeriod_NT(ErrorMessage = "高管及主要关系人段 证件号码和证件类型成对出现")]
    public class ExecutivesMajorParticipantPeriod
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
                return "F";
            }
        }

        /// <summary>
        /// 关系人类型
        /// </summary>
        [Display(Name = "关系人类型"), StringLength(1), AN(ErrorMessage = "关系人类型类型错误")]
        public string ParticipantType { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名"), StringLength(80), ANC(ErrorMessage = "姓名类型错误")]
        public string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [Display(Name = "证件类型"), StringLength(2), Required, AN(ErrorMessage = "证件类型类型错误")]
        public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [Display(Name = "证件号码"), StringLength(20), Required, ANC(ErrorMessage = "证件号码类型错误")]
        public string CertificateNumber { get; set; }

        /// <summary>
        /// 信息更新日期
        /// </summary>
        [Display(Name = "信息更新日期"), StringLength(8), Required, N(ErrorMessage = "信息更新日期类型错误")]
        public string InformationUpdateDate { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [Display(Name = "预留字段"), StringLength(40), Required, ANC(ErrorMessage = "预留字段类型错误")]
        public string ReservedField { get; set; }
    }
}
