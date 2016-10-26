using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Customer.Enterprise
{
    /// <summary>
    /// 机构状态段
    /// </summary>
    public class InstitutionsStatePeriod
    {
        /// <summary>
        /// 信息类别
        /// </summary>
        public string InformationCategories { get; set; }

        /// <summary>
        /// 基本户状态
        /// </summary>
        public string BasicAccountState { get; set; }

        /// <summary>
        /// 企业规模
        /// </summary>
        public string EnterpriseScale{ get; set; }

        /// <summary>
        /// 机构状态
        /// </summary>
        public string InstitutionsState{ get; set; }

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
