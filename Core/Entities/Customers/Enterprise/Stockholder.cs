namespace Core.Entities.Customers.Enterprise
{
    using System.Collections.Generic;

    /// <summary>
    /// 股东
    /// </summary>
    public  class Stockholder : Entity, INaturalPerson, IEnterprise
    {
        /// <summary>
        /// 股东类型
        /// </summary>
        public string ShareholdersType { get; set; }

        /// <summary>
        /// 股东名称
        /// </summary>
        public string ShareholdersName { get; set; }

        /// <summary>
        /// 持股比例
        /// </summary>
        public decimal SharesProportion { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
       public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertificateCode { get; set; }

        /// <summary>
        /// 登记注册类型
        /// </summary>
        public string RegistraterType { get; set; }

        /// <summary>
        /// 登记注册号码
        /// </summary>
        public string RegistraterCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 家族成员
        /// </summary>
        public List<FamilyMember> FamilyMembers { get; set; }
    }
}
