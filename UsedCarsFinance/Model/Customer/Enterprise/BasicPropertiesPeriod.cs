using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Customer
{
    /// <summary>
    /// 基本属性段
    /// </summary>
    class BasicPropertiesPeriod
    {
        /// <summary>
        /// 信息类别
        /// </summary>
        public string InformationCategories { get; set; }

        /// <summary>
        /// 机构中文名称
        /// </summary>
        public string InstitutionChName { get; set; }

        /// <summary>
        /// 机构中文名称
        /// </summary>
        public string InstitutionEnName { get; set; }

        /// <summary>
        /// 注册（登记）地址
        /// </summary>
        public string RegisterAddress { get; set; }

        /// <summary>
        /// 国别
        /// </summary>
        public string Country{ get; set; }

        /// <summary>
        /// 注册（登记）地行政区划
        /// </summary>
        public string RegisterAdministrativeDivision{ get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        public string SetupDate { get; set; }

        /// <summary>
        /// 证书到期日期
        /// </summary>
        public string CertificateDueDate{ get; set; }

        /// <summary>
        /// 经营（业务）范围
        /// </summary>
        public string BusinessScope{ get; set; }

        /// <summary>
        /// 注册资本币种
        /// </summary>
        public string RegisterCapitalCurrency{ get; set; }

        /// <summary>
        /// 注册资本（万元）
        /// </summary>
        public string RegisterCapital{ get; set; }

        /// <summary>
        /// 组织机构类别
        /// </summary>
        public string OrganizationCategory{ get; set; }

        /// <summary>
        /// 组织机构类别细分
        /// </summary>
        public string  OrganizationCategorySubdivision{ get; set; }

        /// <summary>
        /// 经济行业分类
        /// </summary>
        public string EconomicSectorsClassification{ get; set; }

        /// <summary>
        /// 经济类型
        /// </summary>
        public string EconomicType { get; set; }

        /// <summary>
        /// 信息更新日期
        /// </summary>
        public string InformationUpdateDate{ get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        public string ReservedField { get; set; }
    }
}
