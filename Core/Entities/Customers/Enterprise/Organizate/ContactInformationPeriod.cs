namespace Core.Entities.Customers.Enterprise.Organizate
{
    /// <summary>
    /// 联络信息段
    /// </summary>
    public class ContactInformationPeriod
    {
        /// <summary>
        /// 办公（生产、经营）地址
        /// </summary>
        public string OfficeAddress { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 财务部联系电话
        /// </summary>
        public string FinancialContactPhone { get; set; }

        /// <summary>
        /// 信息更新日期
        /// </summary>
        public string InformationUpdateDate { get; set; }

        public virtual BasePeriod Base { get; set; }
    }
}
