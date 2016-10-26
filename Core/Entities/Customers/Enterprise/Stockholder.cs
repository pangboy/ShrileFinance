namespace Core.Entities.Customers.Enterprise
{
    using System.Collections.Generic;

    /// <summary>
    /// 股东
    /// </summary>
    public abstract class Stockholder : Entity
    {
        /// <summary>
        /// 股东类型
        /// </summary>
        public abstract string ShareholdersType { get; }

        /// <summary>
        /// 股东名称
        /// </summary>
        public string ShareholdersName { get; set; }

        /// <summary>
        /// 持股比例
        /// </summary>
        public decimal SharesProportion { get; set; }
    }

    /// <summary>
    /// 自然人股东
    /// </summary>
    public class PersonStockholder : Stockholder, INaturalPerson
    {
        public override string ShareholdersType
        {
            get { return "自然人"; }
        }

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

    /// <summary>
    /// 企业股东
    /// </summary>
    public class EnterpriseStockholder : Stockholder, IEnterprise
    {
        public override string ShareholdersType
        {
            get { return "企业"; }
        }

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
    }
}
