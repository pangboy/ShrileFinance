namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 资产负债
    /// </summary>
    [LiabilitiesAttribute]
    public class LiabilitiesViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 报表类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 货币资金
        /// </summary>
        [Display(Name = "货币资金"),MoneyAttribute(ErrorMessage = "货币资金数据不正确")]
        public decimal? MonetaryFund { get; set; }

        /// <summary>
        /// 交易资产
        /// </summary>
        [Display(Name = "交易资产"),MoneyAttribute(ErrorMessage = "交易资产数据不正确")]
        public decimal? TransactionAssets { get; set; }

        /// <summary>
        /// 应收票据
        /// </summary>
        [Display(Name = "应收票据"),MoneyAttribute(ErrorMessage = "应收票据数据不正确")]
        public decimal? NoteReceivable { get; set; }

        /// <summary>
        /// 应收账款
        /// </summary>
        [Display(Name = "应收账款"),MoneyAttribute(ErrorMessage = "应收账款数据不正确")]
        public decimal? AccountsReceivable { get; set; }

        /// <summary>
        /// 预付账款
        /// </summary>
        [Display(Name = "预付账款"),MoneyAttribute(ErrorMessage = "预付账款数据不正确")]
        public decimal? AdvancePayment { get; set; }

        /// <summary>
        /// 应收利息
        /// </summary>
        [Display(Name = "应收利息"),MoneyAttribute(ErrorMessage = "应收利息数据不正确")]
        public decimal? InterestReceivable { get; set; }

        /// <summary>
        /// 应收股利
        /// </summary>
        [Display(Name = "应收股利"),MoneyAttribute(ErrorMessage = "应收股利数据不正确")]
        public decimal? DividendsReceivable { get; set; }

        /// <summary>
        /// 其他应收款
        /// </summary>
        [Display(Name = "其他应收款"),MoneyAttribute(ErrorMessage = "其他应收款数据不正确")]
        public decimal? OtherReceivables { get; set; }

        /// <summary>
        /// 存货
        /// </summary>
        [Display(Name = "存货"),MoneyAttribute(ErrorMessage = "存货数据不正确")]
        public decimal? Inventory { get; set; }

        /// <summary>
        /// 一年内到期的非流动资产
        /// </summary>
        [Display(Name = "一年内到期的非流动资产"),MoneyAttribute(ErrorMessage = "一年内到期的非流动资产数据不正确")]
        public decimal? NonCurrentAssetsInYear { get; set; }

        /// <summary>
        /// 其他流动资产
        /// </summary>
        [Display(Name = "其他流动资产"),MoneyAttribute(ErrorMessage = "其他流动资产数据不正确")]
        public decimal? OtherCurrentAssets { get; set; }

        /// <summary>
        /// 流动资产合计
        /// </summary>
        [Required]
        [Display(Name = "流动资产合计"),MoneyAttribute(ErrorMessage = "流动资产合计数据不正确")]
        public decimal? TotalCurrentAssets { get; set; }

        /// <summary>
        /// 可供出售的资产
        /// </summary>
        [Display(Name = "可供出售的资产"),MoneyAttribute(ErrorMessage = "可供出售的资产数据不正确")]
        public decimal? CanSaleAsset { get; set; }

        /// <summary>
        /// 持有至到期的投资
        /// </summary>
        [Display(Name = "持有至到期的投资"),MoneyAttribute(ErrorMessage = "持有至到期的投资数据不正确")]
        public decimal? MaturityInvestment { get; set; }

        /// <summary>
        /// 长期股权投资
        /// </summary>
        [Display(Name = "长期股权投资"),MoneyAttribute(ErrorMessage = "长期股权投资数据不正确")]
        public decimal? LongEquity { get; set; }

        /// <summary>
        /// 长期应收款
        /// </summary>
        [Display(Name = "长期应收款"),MoneyAttribute(ErrorMessage = "长期应收款数据不正确")]
        public decimal? LongReceivables { get; set; }

        /// <summary>
        /// 投资性房地产
        /// </summary>
        [Display(Name = "投资性房地产"),MoneyAttribute(ErrorMessage = "投资性房地产数据不正确")]
        public decimal? InvestmentRealEstate { get; set; }

        /// <summary>
        /// 固定资产
        /// </summary>
        [Display(Name = "固定资产"),MoneyAttribute(ErrorMessage = "固定资产数据不正确")]
        public decimal? FixedAssets { get; set; }

        /// <summary>
        /// 在建工程
        /// </summary>
        [Display(Name = "在建工程"),MoneyAttribute(ErrorMessage = "在建工程数据不正确")]
        public decimal? ConstructionProject { get; set; }

        /// <summary>
        /// 工程物资
        /// </summary>
        [Display(Name = "工程物资"),MoneyAttribute(ErrorMessage = "工程物资数据不正确")]
        public decimal? EngineeringMaterials { get; set; }

        /// <summary>
        /// 固定资产清理
        /// </summary>
        [Display(Name = "固定资产清理"),MoneyAttribute(ErrorMessage = "固定资产清理数据不正确")]
        public decimal? FixedAssetsLiquidation { get; set; }

        /// <summary>
        /// 生产性生物资产
        /// </summary>
        [Display(Name = "生产性生物资产"),MoneyAttribute(ErrorMessage = "生产性生物资产数据不正确")]
        public decimal? ProductiveBiologicalAssets { get; set; }

        /// <summary>
        /// 油气资产
        /// </summary>
        [Display(Name = "油气资产"),MoneyAttribute(ErrorMessage = "油气资产数据不正确")]
        public decimal? OilGasAssets { get; set; }

        /// <summary>
        /// 无形资产
        /// </summary>
        [Display(Name = "无形资产"),MoneyAttribute(ErrorMessage = "无形资产数据不正确")]
        public decimal? IntangibleAssets { get; set; }

        /// <summary>
        /// 开发支出
        /// </summary>
        [Display(Name = "开发支出"),MoneyAttribute(ErrorMessage = "开发支出数据不正确")]
        public decimal? DevelopmentExpenditure { get; set; }

        /// <summary>
        /// 商誉
        /// </summary>
        [Display(Name = "商誉"),MoneyAttribute(ErrorMessage = "商誉数据不正确")]
        public decimal? Goodwill { get; set; }

        /// <summary>
        /// 长期待摊费用
        /// </summary>
        [Display(Name = "长期待摊费用"),MoneyAttribute(ErrorMessage = "长期待摊费用数据不正确")]
        public decimal? LongArepaidExpenses { get; set; }

        /// <summary>
        /// 递延所得税资产
        /// </summary>
        [Display(Name = "递延所得税资产"),MoneyAttribute(ErrorMessage = "递延所得税资产数据不正确")]
        public decimal? DeferredTaxAssets { get; set; }

        /// <summary>
        /// 其他非流动资产
        /// </summary>
        [Display(Name = "其他非流动资产"),MoneyAttribute(ErrorMessage = "其他非流动资产数据不正确")]
        public decimal? OtherNonCurrentAssets { get; set; }

        /// <summary>
        /// 非流动资产合计
        /// </summary>
        [Required]
        [Display(Name = "非流动资产合计"),MoneyAttribute(ErrorMessage = "非流动资产合计数据不正确")]
        public decimal? TotalNonCurrentAssets { get; set; }

        /// <summary>
        /// 资产总计
        /// </summary>
        [Required]
        [Display(Name = "资产总计"),MoneyAttribute(ErrorMessage = "资产总计数据不正确")]
        public decimal? TotalAssets { get; set; }

        ////public decimal TotalAssets { get; set; }

        /// <summary>
        /// 短期借款
        /// </summary>
        [Display(Name = "短期借款"),MoneyAttribute(ErrorMessage = "短期借款数据不正确")]
        public decimal? ShortLoan { get; set; }

        /// <summary>
        /// 交易性金融负债
        /// </summary>
        [Display(Name = "交易性金融负债"),MoneyAttribute(ErrorMessage = "交易性金融负债数据不正确")]
        public decimal? TransactionalFinancialLiabilities { get; set; }

        /// <summary>
        /// 应付票据
        /// </summary>
        [Display(Name = "应付票据"),MoneyAttribute(ErrorMessage = "应付票据数据不正确")]
        public decimal? NotesPayable { get; set; }

        /// <summary>
        /// 应付账款
        /// </summary>
        [Display(Name = "应付账款"),MoneyAttribute(ErrorMessage = "应付账款数据不正确")]
        public decimal? AccountsPayable { get; set; }

        /// <summary>
        /// 预收账款
        /// </summary>
        [Display(Name = "预收账款"),MoneyAttribute(ErrorMessage = "预收账款数据不正确")]
        public decimal? AccountsAdvance { get; set; }

        /// <summary>
        /// 应付利息
        /// </summary>
        [Display(Name = "应付利息"),MoneyAttribute(ErrorMessage = "应付利息数据不正确")]
        public decimal? InterestPayable { get; set; }

        /// <summary>
        /// 应付职工薪酬
        /// </summary>
        [Display(Name = "应付职工薪酬"),MoneyAttribute(ErrorMessage = "应付职工薪酬数据不正确")]
        public decimal? EmployeesSalary { get; set; }

        /// <summary>
        /// 应交税费
        /// </summary>
        [Display(Name = "应交税费"),MoneyAttribute(ErrorMessage = "应交税费数据不正确")]
        public decimal? PayTax { get; set; }

        /// <summary>
        /// 应付股利
        /// </summary>
        [Display(Name = "应付股利"),MoneyAttribute(ErrorMessage = "应付股利数据不正确")]
        public decimal? PayDividend { get; set; }

        /// <summary>
        /// 其他应付款
        /// </summary>
        [Display(Name = "其他应付款"),MoneyAttribute(ErrorMessage = "其他应付款数据不正确")]
        public decimal? OtherPayable { get; set; }

        /// <summary>
        /// 一年内到期的非流动负债
        /// </summary>
        [Display(Name = "一年内到期的非流动负债"),MoneyAttribute(ErrorMessage = "一年内到期的非流动负债数据不正确")]
        public decimal? NonCurrentLiabilitiesInYear { get; set; }

        /// <summary>
        /// 其他流动负债
        /// </summary>
        [Display(Name = "其他流动负债"),MoneyAttribute(ErrorMessage = "其他流动负债数据不正确")]
        public decimal? OtherCurrentLiabilities { get; set; }

        /// <summary>
        /// 流动负债合计
        /// </summary>
        [Required]
        [Display(Name = "流动负债合计"),MoneyAttribute(ErrorMessage = "流动负债合计数据不正确")]
        public decimal? TotalCurrentLiabilities { get; set; }

        /// <summary>
        /// 长期借款
        /// </summary>
        [Display(Name = "长期借款"),MoneyAttribute(ErrorMessage = "长期借款数据不正确")]
        public decimal? LongLoan { get; set; }

        /// <summary>
        /// 应付债券
        /// </summary>
        [Display(Name = "应付债券"),MoneyAttribute(ErrorMessage = "应付债券数据不正确")]
        public decimal? BondPayable { get; set; }

        /// <summary>
        /// 长期应付款
        /// </summary>
        [Display(Name = "长期应付款"),MoneyAttribute(ErrorMessage = "长期应付款数据不正确")]
        public decimal? LongAcountsPayable { get; set; }

        /// <summary>
        /// 专项应付款
        /// </summary>
        [Display(Name = "专项应付款"),MoneyAttribute(ErrorMessage = "专项应付款数据不正确")]
        public decimal? SpecialPayment { get; set; }

        /// <summary>
        /// 预计负债
        /// </summary>
        [Display(Name = "预计负债"),MoneyAttribute(ErrorMessage = "预计负债数据不正确")]
        public decimal? EstimatedLiabilities { get; set; }

        /// <summary>
        /// 递延所得税负债
        /// </summary>
        [Display(Name = "递延所得税负债"),MoneyAttribute(ErrorMessage = "递延所得税负债数据不正确")]
        public decimal? DeferredTaxLiability { get; set; }

        /// <summary>
        /// 其他非流动负债
        /// </summary>
        [Display(Name = "其他非流动负债"),MoneyAttribute(ErrorMessage = "其他非流动负债数据不正确")]
        public decimal? OtherNonCurrentLiabilities { get; set; }

        /// <summary>
        /// 非流动负债合计
        /// </summary>
        [Display(Name = "非流动负债合计"), Required,MoneyAttribute(ErrorMessage = "非流动负债合计数据不正确")]
        public decimal? TotalNonNurrentLiabilities { get; set; }

        /// <summary>
        /// 负债合计
        /// </summary>
        [Display(Name = "负债合计"), Required,MoneyAttribute(ErrorMessage = "负债合计数据不正确")]
        public decimal? TotalLiabilities { get; set; }

        /// <summary>
        /// 实收资本
        /// </summary>
        [Display(Name = "实收资本"),MoneyAttribute(ErrorMessage = "实收资本数据不正确")]
        public decimal? PaidCapital { get; set; }

        /// <summary>
        /// 资本公积
        /// </summary>
        [Display(Name = "资本公积"),MoneyAttribute(ErrorMessage = "资本公积数据不正确")]
        public decimal? CapitalReserve { get; set; }

        /// <summary>
        /// 库存股
        /// </summary>
        [Display(Name = "库存股"),MoneyAttribute(ErrorMessage = "库存股数据不正确")]
        public decimal? Stock { get; set; }

        /// <summary>
        /// 盈余公积
        /// </summary>
        [Display(Name = "盈余公积"),MoneyAttribute(ErrorMessage = "盈余公积数据不正确")]
        public decimal? SurplusReserve { get; set; }

        /// <summary>
        /// 未分配利润
        /// </summary>
        [Display(Name = "未分配利润"),MoneyAttribute(ErrorMessage = "未分配利润数据不正确")]
        public decimal? NoProfit { get; set; }

        /// <summary>
        /// 所有者权益合计
        /// </summary>
        [Display(Name = "所有者权益合计"), Required,MoneyAttribute(ErrorMessage = "所有者权益合计数据不正确")]
        public decimal? TotalOwnersEquity { get; set; }

        /// <summary>
        /// 负债和所有者权益合计
        /// </summary>
        [Display(Name = "负债和所有者权益合计"), Required,MoneyAttribute(ErrorMessage = "负债和所有者权益合计数据不正确")]
        public decimal? TotalLiabilitiesCapital { get; set; }
    }
}
