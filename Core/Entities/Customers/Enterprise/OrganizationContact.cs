namespace Core.Entities.Customers.Enterprise
{
    /// <summary>
    /// 联络信息段
    /// </summary>
    public class OrganizationContact
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
    }
}
