﻿using System.ComponentModel.DataAnnotations;

namespace Model.Customer.Enterprise.Organizate
{
    /// <summary>
    /// 基本属性段
    /// </summary>
    public class BasicPropertiesPeriod
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 信息类别
        /// </summary>
        [Display(Name = "信息类别"), StringLength(1), Required, AN(ErrorMessage = "信息类别类型错误")]
        public string InformationCategories
        {
            get
            {
                return "C";
            }
        }

        /// <summary>
        /// 机构中文名称
        /// </summary>
        [Display(Name = "机构中文名称"), StringLength(80), ANC(ErrorMessage = "机构中文名称类型错误")]
        public string InstitutionChName { get; set; }

        /// <summary>
        /// 机构英文名称
        /// </summary>
        [Display(Name = "机构英文名称"), StringLength(80), ANC(ErrorMessage = "机构英文名称类型错误")]
        public string InstitutionEnName { get; set; }

        /// <summary>
        /// 注册登记地址
        /// </summary>
        [Display(Name = "注册登记地址"), StringLength(80), ANC(ErrorMessage = "注册登记地址类型错误")]
        public string RegisterAddress { get; set; }

        /// <summary>
        /// 国别
        /// </summary>
        [Display(Name = "国别"), StringLength(3), AN(ErrorMessage = "国别类型错误")]
        public string Country { get; set; }

        /// <summary>
        /// 注册（登记）地行政区划
        /// </summary>
        [Display(Name = "注册（登记）地行政区划"), StringLength(6), N(ErrorMessage = "注册（登记）地行政区划类型错误")]
        public string RegisterAdministrativeDivision { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        [Display(Name = "成立日期"), StringLength(8), N(ErrorMessage = "成立日期类型错误")]
        public string SetupDate { get; set; }

        /// <summary>
        /// 证书到期日期
        /// </summary>
        [Display(Name = "证书到期日期"), StringLength(8), N(ErrorMessage = "证书到期日期类型错误")]
        public string CertificateDueDate { get; set; }

        /// <summary>
        /// 经营（业务）范围
        /// </summary>
        [Display(Name = "经营（业务）范围"), StringLength(400), ANC(ErrorMessage = "经营（业务）范围类型错误")]
        public string BusinessScope { get; set; }

        /// <summary>
        /// 注册资本币种
        /// </summary>
        [Display(Name = "注册资本币种"), StringLength(3), AN(ErrorMessage = "注册资本币种类型错误")]
        public string RegisterCapitalCurrency { get; set; }

        /// <summary>
        /// 注册资本（万元）
        /// </summary>
        [Display(Name = "注册资本（万元）"), MaxLength(10), AN(ErrorMessage = "注册资本（万元）类型错误")]
        [RegisterCapital(ErrorMessage = "注册资本 保留两位小数")]
        public string RegisterCapital { get; set; }

        /// <summary>
        /// 组织机构类别
        /// </summary>
        [Display(Name = "组织机构类别"), StringLength(1), AN(ErrorMessage = "组织机构类别类型错误")]
        public string OrganizationCategory { get; set; }

        /// <summary>
        /// 组织机构类别细分
        /// </summary>
        [Display(Name = "组织机构类别细分"), StringLength(2), AN(ErrorMessage = "组织机构类别细分类型错误")]
        public string OrganizationCategorySubdivision { get; set; }

        /// <summary>
        /// 经济行业分类
        /// </summary>
        [Display(Name = "经济行业分类"), StringLength(5), AN(ErrorMessage = "经济行业分类类型错误")]
        public string EconomicSectorsClassification { get; set; }

        /// <summary>
        /// 经济类型
        /// </summary>
        [Display(Name = "经济类型"), StringLength(2), AN(ErrorMessage = "经济类型类型错误")]
        public string EconomicType { get; set; }

        /// <summary>
        /// 信息更新日期
        /// </summary>
        [Display(Name = "信息更新日期"), StringLength(8), Required, N(ErrorMessage = "信息更新日期类型错误")]
        public string InformationUpdateDate { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        [Display(Name = "预留字段"), MaxLength(40), ANC(ErrorMessage = "预留字段类型错误")]
        public string ReservedField { get; set; }
    }
}
