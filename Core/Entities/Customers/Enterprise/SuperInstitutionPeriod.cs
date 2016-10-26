using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Customer.Enterprise
{
    /// <summary>
    /// 上级机构（主管单位）段数据项
    /// </summary>
    public class SuperInstitutionPeriod
    {
        /// <summary>
        /// 信息类别
        /// </summary>
        public string InformationCategories { get; set; }

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

        /// <summary>
        /// 预留字段
        /// </summary>
        public string ReservedField { get; set; }
    }
}
