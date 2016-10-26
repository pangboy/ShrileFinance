namespace Core.Entities.Customers
{
    public interface IEnterprise
    {
        /// <summary>
        /// 登记注册号类型
        /// </summary>
        string RegistraterType { get; set; }

        /// <summary>
        /// 登记注册号码
        /// </summary>
        string RegistraterCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        string OrganizateCode { get; set; }
    }
}
