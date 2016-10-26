namespace Core.Entities.Customers.Enterprise.Organizate
{
    /// <summary>
    /// 主要关联企业段
    /// </summary>
    public class MainAssociatedEnterprisePerid
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 关联类型
        /// </summary>
        public string AssociatedType { get; set; }

        /// <summary>
        /// 关联企业名称
        /// </summary>
        public string AssociatedEnterpriseName { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        public string RegistraterNumberType { get; set; }

        /// <summary>
        /// 登记注册号码
        /// </summary>
        public string RegistraterNumber { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 信息更新日期
        /// </summary>
        public string InformationUpdateDate { get; set; }

        public string ReservedField { get; set; }
    }
}
