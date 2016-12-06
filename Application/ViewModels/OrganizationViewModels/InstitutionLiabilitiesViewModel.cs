namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 事业单位资产负债
    /// </summary>
    [InstitutionLiabilitiesAttribute]
    public class InstitutionLiabilitiesViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 报表类型
        /// </summary>
        public int Type { get; set; }

        [Required, MoneyAttribute(ErrorMessage = "现金数据不正确")]
        public decimal? 现金 { get; set; }

        [MoneyAttribute(ErrorMessage = "银行存款数据不正确")]
        public decimal? 银行存款 { get; set; }

        [MoneyAttribute(ErrorMessage = "应收票据数据不正确")]
        public decimal? 应收票据 { get; set; }

        [MoneyAttribute(ErrorMessage = "应收账款数据不正确")]
        public decimal? 应收账款 { get; set; }

        [MoneyAttribute(ErrorMessage = "预付账款数据不正确")]
        public decimal? 预付账款 { get; set; }

        [MoneyAttribute(ErrorMessage = "其他应收款数据不正确")]
        public decimal? 其他应收款 { get; set; }

        [MoneyAttribute(ErrorMessage = "材料数据不正确")]
        public decimal? 材料 { get; set; }

        [MoneyAttribute(ErrorMessage = "数据不正确")]
        public decimal? 产成品 { get; set; }

        [MoneyAttribute(ErrorMessage = "对外投资数据不正确")]
        public decimal? 对外投资 { get; set; }

        [MoneyAttribute(ErrorMessage = "固定资产数据不正确")]
        public decimal? 固定资产 { get; set; }

        [MoneyAttribute(ErrorMessage = "无形资产数据不正确")]
        public decimal? 无形资产 { get; set; }

        [Required, MoneyAttribute(ErrorMessage = "资产合计数据不正确")]
        public decimal? 资产合计 { get; set; }

        [MoneyAttribute(ErrorMessage = "拨出经费数据不正确")]
        public decimal? 拨出经费 { get; set; }

        [MoneyAttribute(ErrorMessage = "拨出专款数据不正确")]
        public decimal? 拨出专款 { get; set; }

        [MoneyAttribute(ErrorMessage = "专款支出数据不正确")]
        public decimal? 专款支出 { get; set; }

        [MoneyAttribute(ErrorMessage = "事业支出数据不正确")]
        public decimal? 事业支出 { get; set; }

        [MoneyAttribute(ErrorMessage = "经营支出数据不正确")]
        public decimal? 经营支出 { get; set; }

        [MoneyAttribute(ErrorMessage = "成本费用数据不正确")]
        public decimal? 成本费用 { get; set; }

        [MoneyAttribute(ErrorMessage = "销售税金数据不正确")]
        public decimal? 销售税金 { get; set; }

        [MoneyAttribute(ErrorMessage = "上缴上级支出数据不正确")]
        public decimal? 上缴上级支出 { get; set; }

        [MoneyAttribute(ErrorMessage = "对附属单位补助数据不正确")]
        public decimal? 对附属单位补助 { get; set; }

        [MoneyAttribute(ErrorMessage = "结转自筹基建数据不正确")]
        public decimal? 结转自筹基建 { get; set; }

        [MoneyAttribute(ErrorMessage = "支出合计数据不正确")]
        [Required]
        public decimal? 支出合计 { get; set; }

        [MoneyAttribute(ErrorMessage = "资产部类总计数据不正确")]
        [Required]
        public decimal? 资产部类总计 { get; set; }

        [MoneyAttribute(ErrorMessage = "借记款项数据不正确")]
        public decimal? 借记款项 { get; set; }

        [MoneyAttribute(ErrorMessage = "应付票据数据不正确")]
        public decimal? 应付票据 { get; set; }

        [MoneyAttribute(ErrorMessage = "应付账款数据不正确")]
        public decimal? 应付账款 { get; set; }

        [MoneyAttribute(ErrorMessage = "预收账款数据不正确")]
        public decimal? 预收账款 { get; set; }

        [MoneyAttribute(ErrorMessage = "其他应付款数据不正确")]
        public decimal? 其他应付款 { get; set; }

        [MoneyAttribute(ErrorMessage = "应缴预算款数据不正确")]
        public decimal? 应缴预算款 { get; set; }

        [MoneyAttribute(ErrorMessage = "应缴财政专户款数据不正确")]
        public decimal? 应缴财政专户款 { get; set; }

        [MoneyAttribute(ErrorMessage = "应交税金数据不正确")]
        public decimal? 应交税金 { get; set; }

        [Required, MoneyAttribute(ErrorMessage = "负债合计数据不正确")]
        public decimal? 负债合计 { get; set; }

        [MoneyAttribute(ErrorMessage = "事业基金数据不正确")]
        public decimal? 事业基金 { get; set; }

        [MoneyAttribute(ErrorMessage = "一般基金数据不正确")]
        public decimal? 一般基金 { get; set; }

        [MoneyAttribute(ErrorMessage = "投资基金数据不正确")]
        public decimal? 投资基金 { get; set; }

        [MoneyAttribute(ErrorMessage = "固定基金数据不正确")]
        public decimal? 固定基金 { get; set; }

        [MoneyAttribute(ErrorMessage = "专用基金数据不正确")]
        public decimal? 专用基金 { get; set; }

        [MoneyAttribute(ErrorMessage = "事业结余数据不正确")]
        public decimal? 事业结余 { get; set; }

        [MoneyAttribute(ErrorMessage = "经营结余数据不正确")]
        public decimal? 经营结余 { get; set; }

        [Required, MoneyAttribute(ErrorMessage = "净资产合计数据不正确")]
        public decimal? 净资产合计 { get; set; }

        [MoneyAttribute(ErrorMessage = "财政补助收入数据不正确")]
        public decimal? 财政补助收入 { get; set; }

        [MoneyAttribute(ErrorMessage = "上级补助收入数据不正确")]
        public decimal? 上级补助收入 { get; set; }

        [MoneyAttribute(ErrorMessage = "拨入专款数据不正确")]
        public decimal? 拨入专款 { get; set; }

        [MoneyAttribute(ErrorMessage = "事业收入数据不正确")]
        public decimal? 事业收入 { get; set; }

        [MoneyAttribute(ErrorMessage = "经营收入数据不正确")]
        public decimal? 经营收入 { get; set; }

        [MoneyAttribute(ErrorMessage = "附属单位缴款数据不正确")]
        public decimal? 附属单位缴款 { get; set; }

        [MoneyAttribute(ErrorMessage = "其他收入数据不正确")]
        public decimal? 其他收入 { get; set; }

        [Required, MoneyAttribute(ErrorMessage = "收入合计数据不正确")]
        public decimal? 收入合计 { get; set; }

        [Required, MoneyAttribute(ErrorMessage = "负债部类总计数据不正确")]
        public decimal? 负债部类总计 { get; set; }
    }
}
