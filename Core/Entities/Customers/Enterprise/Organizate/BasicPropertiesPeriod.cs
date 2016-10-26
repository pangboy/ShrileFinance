namespace Core.Entities.Customers.Enterprise.Organizate
{
    /// <summary>
    /// 基本属性段
    /// </summary>
    public class BasicPropertiesPeriod
    {
        /// <summary>
        /// 机构中文名称
        /// </summary>
        [Display(Name = "机构中文名称"), StringLength(80), ANC(ErrorMessage = "机构中文名称 类型错误")]
        public string InstitutionChName { get; set; }

        /// <summary>
        /// 机构英文名称
        /// </summary>
        [Display(Name = "机构英文名称"), StringLength(80), ANC(ErrorMessage = "机构英文名称 类型错误")]
        public string InstitutionEnName { get; set; }

        /// <summary>
        /// 注册登记地址
        /// </summary>
        [Display(Name = "注册登记地址"), StringLength(80), ANC(ErrorMessage = "注册登记地址 类型错误")]
        public string RegisterAddress { get; set; }

        /// <summary>
        /// 国别
        /// </summary>
        [Display(Name = "国别"), StringLength(3), AN(ErrorMessage = "国别 类型错误"),Country(ErrorMessage = "国别 值错误")]
        public string Country { get; set; }

        /// <summary>
        /// 注册（登记）地行政区划
        /// </summary>
        [Display(Name = "注册（登记）地行政区划"), StringLength(6), N(ErrorMessage = "注册（登记）地行政区划 类型错误")]
        public string RegisterAdministrativeDivision { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        [Display(Name = "成立日期"), StringLength(8), N(ErrorMessage = "成立日期 类型错误")]
        public string SetupDate { get; set; }

        /// <summary>
        /// 证书到期日期
        /// </summary>
        [Display(Name = "证书到期日期"), StringLength(8), N(ErrorMessage = "证书到期日期 类型错误")]
        public string CertificateDueDate { get; set; }

        /// <summary>
        /// 经营（业务）范围
        /// </summary>
        [Display(Name = "经营（业务）范围"), StringLength(400), ANC(ErrorMessage = "经营（业务）范围 类型错误")]
        public string BusinessScope { get; set; }

        /// <summary>
        /// 注册资本币种
        /// </summary>
        [Display(Name = "注册资本币种"), StringLength(3), AN(ErrorMessage = "注册资本币种 类型错误"), CapitalCurrency(ErrorMessage = "注册资本币种 值错误")]
        public string RegisterCapitalCurrency { get; set; }

        /// <summary>
        /// 注册资本（万元）
        /// </summary>
        [Display(Name = "注册资本（万元）"), MaxLength(10), AN(ErrorMessage = "注册资本（万元） 类型错误")]
        [RegisterCapital(ErrorMessage = "注册资本 保留两位小数")]
        public string RegisterCapital { get; set; }

        /// <summary>
        /// 组织机构类别
        /// </summary>
        [Display(Name = "组织机构类别"), StringLength(1), AN(ErrorMessage = "组织机构类别 类型错误"), OrganizationCategory(ErrorMessage = "组织机构类别 值错误")]
        public string OrganizationCategory { get; set; }

        /// <summary>
        /// 组织机构类别细分
        /// </summary>
        [Display(Name = "组织机构类别细分"), StringLength(2), AN(ErrorMessage = "组织机构类别细分 类型错误"), OrganizationCategorySubdivision(ErrorMessage = "组织机构类别细分 值错误")]
        public string OrganizationCategorySubdivision { get; set; }

        /// <summary>
        /// 经济行业分类
        /// </summary>
        [Display(Name = "经济行业分类"), StringLength(5), AN(ErrorMessage = "经济行业分类 类型错误")]
        public string EconomicSectorsClassification { get; set; }

        /// <summary>
        /// 经济类型
        /// </summary>
        [Display(Name = "经济类型"), StringLength(2), AN(ErrorMessage = "经济类型 类型错误"),EconomicType(ErrorMessage = "经济类型 值错误")]
        public string EconomicType { get; set; }

        /// <summary>
        /// 信息更新日期
        /// </summary>
        [Display(Name = "信息更新日期"), StringLength(8), Required, N(ErrorMessage = "信息更新日期 类型错误")]
        public string InformationUpdateDate { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [Display(Name = "预留字段"), MaxLength(40), ANC(ErrorMessage = "预留字段 类型错误")]
        public string ReservedField { get; set; }
    }
}
