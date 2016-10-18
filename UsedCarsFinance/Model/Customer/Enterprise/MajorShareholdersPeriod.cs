using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Customer.Enterprise
{
    /// <summary>
    /// 重要股东段
    /// </summary>
    public class MajorShareholdersPeriod
    {
        /// <summary>
        /// 信息类别
        /// </summary>
        public string InformationCategories { get; set; }

        /// <summary>
        /// 股东类型
        /// </summary>
        public string ShareholdersType{ get; set; }

        /// <summary>
        /// 股东名称
        /// </summary>
        public string ShareholdersName { get; set; }

        /// <summary>
        /// 证件类型/登记注册号类型
        /// </summary>
        public string RegistraterType{ get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OrganizateCode { get; set; }

        /// <summary>
        /// 机构信用代码
        /// </summary>
        public string InstitutionCreditCode { get; set; }

        /// <summary>
        /// 持股比例
        /// </summary>
        public string SharesProportion{ get; set; }

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
