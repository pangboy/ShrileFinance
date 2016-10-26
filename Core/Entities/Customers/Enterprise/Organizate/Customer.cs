namespace Core.Entities.Customers.Enterprise.Organizate
{
    using System.Collections.Generic;
    using Interfaces;

    public class Customer : Entity, IAggregateRoot
    {
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
        /// 基本属性信息
        /// </summary>
        public virtual BasicPropertiesPeriod BasicProperties { get; set; }

        /// <summary>
        /// 联络信息
        /// </summary>
        public virtual ContactInformationPeriod ContactInformation { get; set; }

        /// <summary>
        /// 机构状态
        /// </summary>
        public virtual InstitutionsStatePeriod InstitutionsState { get; set; }

        /// <summary>
        /// 高级主管
        /// </summary>
        public virtual ICollection<ExecutivesMajorParticipantPeriod> ExecutivesMajorParticipant { get; set; }

        /// <summary>
        /// 重要股东
        /// </summary>
        public virtual ICollection<MajorShareholdersPeriod> Shareholders { get; set; }

        /// <summary>
        /// 主要关联企业
        /// </summary>
        public virtual ICollection<MainAssociatedEnterprisePerid> MainAssociatedEnterprise { get; set; }

        /// <summary>
        /// 上级机构
        /// </summary>
        public virtual ICollection<SuperInstitutionPeriod> SuperInstitution { get; set; }
    }
}
