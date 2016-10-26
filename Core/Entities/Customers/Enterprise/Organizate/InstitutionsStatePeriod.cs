namespace Core.Entities.Customers.Enterprise.Organizate
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 机构状态段
    /// </summary>
    public class InstitutionsStatePeriod
    {
        /// <summary>
        /// 基本户状态
        /// </summary>
        public string BasicAccountState { get; set; }

        /// <summary>
        /// 企业规模
        /// </summary>
        public string EnterpriseScale { get; set; }

        /// <summary>
        /// 机构状态
        /// </summary>
        public string InstitutionsState { get; set; }

        /// <summary>
        /// 信息更新日期
        /// </summary>
        public string InformationUpdateDate { get; set; }

        public virtual BasePeriod Base { get; set; }
    }
}
