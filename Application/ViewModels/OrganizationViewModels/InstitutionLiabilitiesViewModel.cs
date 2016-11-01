namespace Application.ViewModels.OrganizationViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 事业单位资产负债
    /// </summary>
    public class InstitutionLiabilitiesViewModel 
    {
        [Required]
        public decimal 现金 { get; set; }

        public decimal 银行存款 { get; set; }

        public decimal 应收票据 { get; set; }

        public decimal 应收账款 { get; set; }

        public decimal 预付账款 { get; set; }

        public decimal 其他应收款 { get; set; }

        public decimal 材料 { get; set; }

        public decimal 产成品 { get; set; }

        public decimal 对外投资 { get; set; }

        public decimal 固定资产 { get; set; }

        public decimal 无形资产 { get; set; }

        [Required]
        public decimal 资产合计 { get; set; }

        public decimal 拨出经费 { get; set; }

        public decimal 拨出专款 { get; set; }

        public decimal 专款支出 { get; set; }

        public decimal 事业支出 { get; set; }

        public decimal 经营支出 { get; set; }

        public decimal 成本费用 { get; set; }

        public decimal 销售税金 { get; set; }

        public decimal 上缴上级支出 { get; set; }

        public decimal 对附属单位补助 { get; set; }

        public decimal 结转自筹基建 { get; set; }

        [Required]
        public decimal 支出合计 { get; set; }

        [Required]
        public decimal 资产部类总计 { get; set; }

        public decimal 借记款项 { get; set; }

        public decimal 应付票据 { get; set; }

        public decimal 应付账款 { get; set; }

        public decimal 预收账款 { get; set; }

        public decimal 其他应付款 { get; set; }

        public decimal 应缴预算款 { get; set; }

        public decimal 应缴财政专户款 { get; set; }

        public decimal 应交税金 { get; set; }

        [Required]
        public decimal 负债合计 { get; set; }

        public decimal 事业基金 { get; set; }

        public decimal 一般基金 { get; set; }

        public decimal 投资基金 { get; set; }

        public decimal 固定基金 { get; set; }

        public decimal 专用基金 { get; set; }

        public decimal 事业结余 { get; set; }

        public decimal 经营结余 { get; set; }

        [Required]
        public decimal 净资产合计 { get; set; }

        public decimal 财政补助收入 { get; set; }

        public decimal 上级补助收入 { get; set; }

        public decimal 拨入专款 { get; set; }

        public decimal 事业收入 { get; set; }

        public decimal 经营收入 { get; set; }

        public decimal 附属单位缴款 { get; set; }

        public decimal 其他收入 { get; set; }

        [Required]
        public decimal 收入合计 { get; set; }

        [Required]
        public decimal 负债部类总计 { get; set; }
    }
}
