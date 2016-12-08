namespace Core.Entities.Customers.Enterprise
{
    using System;

    /// <summary>
    /// 基本属性段
    /// </summary>
    public class OrganizationProperties
    {
        /// <summary>
        /// 机构中文名称
        /// </summary>
        public string InstitutionChName { get; set; }

        /// <summary>
        /// 注册登记地址
        /// </summary>
        public string RegisterAddress { get; set; }

        /// <summary>
        /// 注册（登记）地行政区划
        /// </summary>
        public string RegisterAdministrativeDivision { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        public DateTime? SetupDate { get; set; }

        /// <summary>
        /// 证书到期日期
        /// </summary>
        public DateTime? CertificateDueDate { get; set; }

        /// <summary>
        /// 经营（业务）范围
        /// </summary>
        public string BusinessScope { get; set; }

        /// <summary>
        /// 注册资本（万元）
        /// </summary>
        public decimal? RegisterCapital { get; set; }

        /// <summary>
        /// 组织机构类别
        /// </summary>
        public string OrganizationCategory { get; set; }

        /// <summary>
        /// 组织机构类别细分
        /// </summary>
        public string OrganizationCategorySubdivision { get; set; }

        /// <summary>
        /// 经济行业分类
        /// </summary>
        public string EconomicSectorsClassification { get; set; }

        /// <summary>
        /// 经济类型
        /// </summary>
        public string EconomicType { get; set; }
    }
}
