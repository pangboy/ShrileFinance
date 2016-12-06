namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 利润以及利润分配
    /// </summary>
    public class ProfitViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 报表类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 营业收入
        /// </summary>
        [Required]
        [Display(Name = "销售商品和提供劳务收到的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "销售商品和提供劳务收到的现金数据不正确")]
        public decimal? BusinessIncome { get; set; }

        /// <summary>
        /// 营业成本
        /// </summary>
        [Display(Name = "营业成本"), StringLength(20), MoneyAttribute(ErrorMessage = "营业成本数据不正确")]
        public decimal? OperatingCost { get; set; }

        /// <summary>
        /// 营业税金及附加
        /// </summary>
        [Display(Name = "营业税金及附加"), StringLength(20), MoneyAttribute(ErrorMessage = "营业税金及附加数据不正确")]
        public decimal? SalesTax { get; set; }

        /// <summary>
        /// 销售费用
        /// </summary>
        [Display(Name = "销售费用"), StringLength(20), MoneyAttribute(ErrorMessage = "销售费用数据不正确")]
        public decimal? SellingExpenses { get; set; }

        /// <summary>
        /// 管理费用
        /// </summary>
        [Display(Name = "管理费用"), StringLength(20), MoneyAttribute(ErrorMessage = "管理费用数据不正确")]
        public decimal? ManagementExpenses { get; set; }

        /// <summary>
        /// 财务费用
        /// </summary>
        [Display(Name = "财务费用"), Required, StringLength(20), MoneyAttribute(ErrorMessage = "财务费用数据不正确")]
        public decimal? FinancialExpenses { get; set; }

        /// <summary>
        /// 资产减值损失
        /// </summary>
        [Display(Name = "资产减值损失"), StringLength(20), MoneyAttribute(ErrorMessage = "资产减值损失数据不正确")]
        public decimal? AssetsimpairmentLoss { get; set; }

        /// <summary>
        /// 公允价值变动净收益
        /// </summary>
        [Display(Name = "公允价值变动净收益"), StringLength(20), MoneyAttribute(ErrorMessage = "公允价值变动净收益数据不正确")]
        public decimal? FairIncome { get; set; }

        /// <summary>
        /// 投资净收益
        /// </summary>
        [Display(Name = "投资净收益"), StringLength(20), MoneyAttribute(ErrorMessage = "投资净收益数据不正确")]
        public decimal? NetInvestmentIncome { get; set; }

        /// <summary>
        /// 对联营企业和合营企业的投资收益
        /// </summary>
        [Display(Name = "对联营企业和合营企业的投资收益"), StringLength(20), MoneyAttribute(ErrorMessage = "对联营企业和合营企业的投资收益数据不正确")]
        public decimal? EnterpriseInvestmentIncome { get; set; }

        /// <summary>
        /// 营业利润
        /// </summary>
        [Display(Name = "营业利润"), Required, StringLength(20), MoneyAttribute(ErrorMessage = "营业利润数据不正确")]
        public decimal? OperatingProfit { get; set; }

        /// <summary>
        /// 营业外收入
        /// </summary>
        [Display(Name = "营业外收入"), StringLength(20), MoneyAttribute(ErrorMessage = "营业外收入数据不正确")]
        public decimal? OperatingIncome { get; set; }

        /// <summary>
        /// 营业外支出
        /// </summary>
        [Display(Name = "营业外支出"), StringLength(20), MoneyAttribute(ErrorMessage = "营业外支出数据不正确")]
        public decimal? OperatingExpenditure { get; set; }

        /// <summary>
        /// 非流动资产损失
        /// </summary>
        [Display(Name = "非流动资产损失"), StringLength(20), MoneyAttribute(ErrorMessage = "非流动资产损失数据不正确")]
        public decimal? NonCurrentAssetsLoss { get; set; }

        /// <summary>
        /// 利润总额
        /// </summary>
        [Display(Name = "利润总额"), Required, StringLength(20), MoneyAttribute(ErrorMessage = "利润总额数据不正确")]
        public decimal? GrossProfit { get; set; }

        /// <summary>
        /// 所得税费用
        /// </summary>
        [Display(Name = "所得税费用"), StringLength(20), MoneyAttribute(ErrorMessage = "所得税费用数据不正确")]
        public decimal? IncomeTaxExpense { get; set; }

        /// <summary>
        /// 净利润
        /// </summary>
        [Display(Name = "净利润"), Required, StringLength(20), MoneyAttribute(ErrorMessage = "净利润数据不正确")]
        public decimal? NetProfit { get; set; }

        /// <summary>
        /// 基本每股收益
        /// </summary>
        [Display(Name = "基本每股收益"), StringLength(20), MoneyAttribute(ErrorMessage = "基本每股收益数据不正确")]
        public decimal? BasicEarningsShare { get; set; }

        /// <summary>
        /// 稀释每股收益
        /// </summary>
        [Display(Name = "稀释每股收益"), StringLength(20), MoneyAttribute(ErrorMessage = "稀释每股收益数据不正确")]
        public decimal? DilutedEarningsShare { get; set; }
    }
}
