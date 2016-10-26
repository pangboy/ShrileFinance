namespace Models.Customer.Enterprise.Family
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 删除报文记录（家族）
    /// </summary>
    public class DeleteRecord
    {
        /// <summary>
        /// 信息类别
        /// </summary>
        public string InformationCategories
        {
            get
            {
                return "B";
            }
        }

        /// <summary>
        /// 主要关系人证件类型
        /// </summary>
        public string MainParticipantCertificateType { get; set; }

        /// <summary>
        /// 主要关系人证件号码
        /// </summary>
        public string MainParticipantCertificateNumber { get; set; }

        /// <summary>
        /// 家族关系
        /// </summary>
        public string FamilyRelationship { get; set; }

        /// <summary>
        /// 家族成员证件类型
        /// </summary>
        public string FamilyMembersCertificateType { get; set; }

        /// <summary>
        /// 家族成员证件号码
        /// </summary>
        public string FamilyMembersCertificateNumber { get; set; }

        /// <summary>
        /// 数据提取日期
        /// </summary>
        public string DataUpdateDate { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        public string ReservedField { get; set; }
    }
}
