namespace Core.Entities.Customers.Enterprise
{
    /// <summary>
    /// 家族成员
    /// </summary>
    public class FamilyMember : Entity, INaturalPerson
    {
        /// <summary>
        /// 关系
        /// </summary>
        public string Relationship { get; set; }

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
        public string CertificateCode { get; set; }
    }
}
