namespace Core.Entities.Customers.Enterprise.Organizate
{
    /// <summary>
    /// 基础段
    /// </summary>
    public class BasePeriod
    {
        public int Id { get; set; }

        /// <summary>
        /// 客户号
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 管理行代码
        /// </summary>
        public string ManagementerCode { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        public string CustomerType { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 登记注册号类型
        /// </summary>
        public string RegistrationNumberType { get; set; }

        /// <summary>
        /// 登记注册号码
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// 纳税人识别号（国税）
        /// </summary>
        public string TaxpayerIdentifyIrsNumber { get; set; }

        /// <summary>
        /// 纳税人识别号（地税）
        /// </summary>
        public string TaxpayerIdentifyLandNumber { get; set; }

        /// <summary>
        /// 开户许可证核准号
        /// </summary>
        public string NewaccountlicenseNumber { get; set; }

        /// <summary>
        /// 贷款卡编码
        /// </summary>
        public string LoanCardCode { get; set; }

        /// <summary>
        /// 数据提取日期
        /// </summary>
        public string DataExtractionDate { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        public string ReservedField { get; set; }
    }
}
