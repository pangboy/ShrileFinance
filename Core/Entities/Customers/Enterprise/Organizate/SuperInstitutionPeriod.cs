namespace Core.Entities.Customers.Enterprise.Organizate
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 上级机构（主管单位）段
    /// </summary>
    public class SuperInstitutionPeriod
    {
        /// <summary>
        /// 上级机构名称
        /// </summary>
        public string SuperInstitutionsName { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        public string RegistraterNumberType { get; set; }

        /// <summary>
        /// 登记注册号
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

        public virtual BasePeriod Base { get; set; }
    }
}
