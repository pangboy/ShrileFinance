namespace Core.Entities.Customers.Enterprise
{
    /// <summary>
    /// 企业股东
    /// </summary>
    public class EnterpriseStockholder : Stockholder, IEnterprise
    {
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
