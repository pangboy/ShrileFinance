namespace Core.Entities.Customers.Enterprise
{
    /// <summary>
    /// 上级机构（主管单位）段
    /// </summary>
    public class OrganizationParent : Entity, IEnterprise
    {
        /// <summary>
        /// 上级机构名称
        /// </summary>
        public string SuperInstitutionsName { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        public string RegistraterType { get; set; }

        /// <summary>
        /// 登记注册号
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
