namespace Core.Entities.Customers.Enterprise
{
    using System.Collections.Generic;

    /// <summary>
    /// 高管及主要关系人段
    /// </summary>
    public class Manager : Entity, INaturalPerson
    {
        /// <summary>
        /// 关系人类型
        /// </summary>
        public string Type { get; set; }

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

        /// <summary>
        /// 家族成员
        /// </summary>
        public virtual List<FamilyMember> FamilyMembers { get; set; }
    }
}
