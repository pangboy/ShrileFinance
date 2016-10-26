namespace Core.Entities.Customers.Enterprise.Organizate
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 高管及主要关系人段
    /// </summary>
    public class ExecutivesMajorParticipantPeriod
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 关系人类型
        /// </summary>
        public string ParticipantType { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertificateNumber { get; set; }

        /// <summary>
        /// 信息更新日期
        /// </summary>
        public string InformationUpdateDate { get; set; }

        public string ReservedField { get; set; }
    }
}
