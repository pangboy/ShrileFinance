namespace Core.Entities.Customers.Enterprise
{
    using System.Collections.Generic;

    /// <summary>
    /// 自然人股东
    /// </summary>
    public class PersonStockholder : Stockholder, INaturalPerson
    {
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertificateCode { get; set; }

        /// <summary>
        /// 对应的家族成员信息
        /// </summary>
        public List<FamilyMember> FamilyMembers { get; set; }
    }
}
