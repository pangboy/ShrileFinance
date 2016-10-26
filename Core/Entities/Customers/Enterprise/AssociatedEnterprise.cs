namespace Core.Entities.Customers.Enterprise
{
    /// <summary>
    /// 主要关联企业段
    /// </summary>
    public class AssociatedEnterprise : Entity, IEnterprise
    {
        /// <summary>
        /// 关联类型
        /// </summary>
        public string AssociatedType { get; set; }

        /// <summary>
        /// 关联企业名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 登记注册号类型
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
