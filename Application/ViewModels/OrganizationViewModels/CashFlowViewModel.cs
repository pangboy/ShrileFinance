namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 现金流
    /// </summary>
    [CashFlowAttribute]
    public class CashFlowViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 报表类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 销售商品和提供劳务收到的现金
        /// </summary>
        [Display(Name = "销售商品和提供劳务收到的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "销售商品和提供劳务收到的现金数据不正确")]
        public decimal? SaleGoodsCash { get; set; }

        /// <summary>
        /// 收到的税费返还
        /// </summary>
        [Display(Name = "收到的税费返还"), StringLength(20), MoneyAttribute(ErrorMessage = "收到的税费返还数据不正确")]
        public decimal? TaxesRefunds { get; set; }

        /// <summary>
        /// 收到其他与经营活动有关的现金
        /// </summary>
        [Display(Name = "收到其他与经营活动有关的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "收到其他与经营活动有关的现金数据不正确")]
        public decimal? ReceiveOperatingActivitiesCash { get; set; }

        /// <summary>
        /// 经营活动现金流入小计
        /// </summary>
        [Display(Name = "经营活动现金流入小计"), StringLength(20), MoneyAttribute(ErrorMessage = "经营活动现金流入小计数据不正确")]
        public decimal? OperatingActivitiesCashInflows { get; set; }

        /// <summary>
        /// 购买商品、接受劳务支付的现金
        /// </summary>
        [Display(Name = "购买商品、接受劳务支付的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "购买商品、接受劳务支付的现金数据不正确")]
        public decimal? BuyGoodsCash { get; set; }

        /// <summary>
        /// 支付给职工以及为职工支付的现金
        /// </summary>
        [Display(Name = "支付给职工以及为职工支付的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "支付给职工以及为职工支付的现金数据不正确")]
        public decimal? PayEmployeeCash { get; set; }

        /// <summary>
        /// 支付的各项税费
        /// </summary>
        [Display(Name = "支付的各项税费"), StringLength(20), MoneyAttribute(ErrorMessage = "支付的各项税费数据不正确")]
        public decimal? PayAllTaxes { get; set; }

        /// <summary>
        /// 支付其他与经营活动有关的现金
        /// </summary>
        [Display(Name = "支付其他与经营活动有关的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "支付其他与经营活动有关的现金数据不正确")]
        public decimal? PayOperatingActivitiesCash { get; set; }

        /// <summary>
        /// 经营活动现金流出小计
        /// </summary>
        [Display(Name = "经营活动现金流出小计"), StringLength(20), MoneyAttribute(ErrorMessage = "经营活动现金流出小计数据不正确")]
        public decimal? OperatingActivitiesCashOutflows { get; set; }

        /// <summary>
        /// 经营活动产生的现金流量净额
        /// </summary>
        [Display(Name = "经营活动产生的现金流量净额"), Required, StringLength(20), MoneyAttribute(ErrorMessage = "经营活动产生的现金流量净额数据不正确")]
        public decimal? OperatingActivitieCashNet { get; set; }

        /// <summary>
        /// 收回投资所收到的现金
        /// </summary>
        [Display(Name = "收回投资所收到的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "收回投资所收到的现金数据不正确")]
        public decimal? RecoveryInvestmentCash { get; set; }

        /// <summary>
        /// 取得投资收益所收到的现金
        /// </summary>
        [Display(Name = "取得投资收益所收到的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "取得投资收益所收到的现金数据不正确")]
        public decimal? InvestmentIncomeCash { get; set; }

        /// <summary>
        /// 处置固定资产无形资产和其他长期资产所收回的现金净额
        /// </summary>
        [Display(Name = "处置固定资产无形资产和其他长期资产所收回的现金净额"), StringLength(20), MoneyAttribute(ErrorMessage = "处置固定资产无形资产和其他长期资产所收回的现金净额数据不正确")]
        public decimal? RecoveryAssetsCash { get; set; }

        /// <summary>
        /// 处置子公司及其他营业单位收到的现金净额
        /// </summary>
        [Display(Name = "处置子公司及其他营业单位收到的现金净额"), StringLength(20), MoneyAttribute(ErrorMessage = "处置子公司及其他营业单位收到的现金净额数据不正确")]
        public decimal? RecoveryChildrenCompanyCash { get; set; }

        /// <summary>
        /// 收到其他与投资活动有关的现金
        /// </summary>
        [Display(Name = "收到其他与投资活动有关的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "收到其他与投资活动有关的现金数据不正确")]
        public decimal? OtherInvestmentCash { get; set; }

        /// <summary>
        /// 投资活动现金流入小计
        /// </summary>
        [Display(Name = "投资活动现金流入小计"), StringLength(20), MoneyAttribute(ErrorMessage = "投资活动现金流入小计数据不正确")]
        public decimal? CashInInvestmentActivities { get; set; }

        /// <summary>
        /// 购建固定资产无形资产和其他长期资产所支付的现金
        /// </summary>
        [Display(Name = "购建固定资产无形资产和其他长期资产所支付的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "购建固定资产无形资产和其他长期资产所支付的现金数据不正确")]
        public decimal? BuyAssetsCash { get; set; }

        /// <summary>
        /// 投资所支付的现金
        /// </summary>
        [Display(Name = "投资所支付的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "投资所支付的现金数据不正确")]
        public decimal? InvestmentPaidCash { get; set; }

        /// <summary>
        /// 取得子公司及其他营业单位支付的现金净额
        /// </summary>
        [Display(Name = "取得子公司及其他营业单位支付的现金净额"), StringLength(20), MoneyAttribute(ErrorMessage = "取得子公司及其他营业单位支付的现金净额数据不正确")]
        public decimal? GetChildrenComponyCash { get; set; }

        /// <summary>
        /// 支付其他与投资活动有关的现金
        /// </summary>
        [Display(Name = "支付其他与投资活动有关的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "支付其他与投资活动有关的现金数据不正确")]
        public decimal? PayOtherInvestmentCash { get; set; }

        /// <summary>
        /// 投资活动现金流出小计
        /// </summary>
        [Display(Name = "投资活动现金流出小计"), StringLength(20), MoneyAttribute(ErrorMessage = "投资活动现金流出小计数据不正确")]
        public decimal? InvestmentCashOutflow { get; set; }

        /// <summary>
        /// 投资活动产生的现金流量净额
        /// </summary>
        [Display(Name = "投资活动产生的现金流量净额"), StringLength(20), MoneyAttribute(ErrorMessage = "投资活动产生的现金流量净额数据不正确")]
        public decimal? InvestmentCashInflow { get; set; }

        /// <summary>
        /// 吸收投资收到的现金
        /// </summary>
        [Display(Name = "吸收投资收到的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "吸收投资收到的现金数据不正确")]
        public decimal? AbsorbInvestmentCash { get; set; }

        /// <summary>
        /// 取得借款收到的现金
        /// </summary>
        [Display(Name = "取得借款收到的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "取得借款收到的现金数据不正确")]
        public decimal? GetLoanCash { get; set; }

        /// <summary>
        /// 收到其他与筹资活动有关的现金
        /// </summary>
        [Display(Name = "收到其他与筹资活动有关的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "收到其他与筹资活动有关的现金数据不正确")]
        public decimal? GetFinancingCash { get; set; }

        /// <summary>
        /// 筹资活动现金流入小计
        /// </summary>
        [Display(Name = "筹资活动现金流入小计"), StringLength(20), MoneyAttribute(ErrorMessage = "筹资活动现金流入小计数据不正确")]
        public decimal? FinancingCashInflow { get; set; }

        /// <summary>
        /// 偿还债务所支付的现金
        /// </summary>
        [Display(Name = "偿还债务所支付的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "偿还债务所支付的现金数据不正确")]
        public decimal? DebtRedemption { get; set; }

        /// <summary>
        /// 分配股利、利润或偿付利息所支付的现金
        /// </summary>
        [Display(Name = "分配股利、利润或偿付利息所支付的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "分配股利、利润或偿付利息所支付的现金数据不正确")]
        public decimal? PayCashForDividend { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        [Display(Name = "其他"), StringLength(20), MoneyAttribute(ErrorMessage = "其他数据不正确")]
        public decimal? PayFinancingCash { get; set; }

        /// <summary>
        /// 支付其他与筹资活动有关的现金
        /// </summary>
        [Display(Name = "支付其他与筹资活动有关的现金"), StringLength(20), MoneyAttribute(ErrorMessage = "支付其他与筹资活动有关的现金数据不正确")]
        public decimal? PayOtherFinancingCash { get; set; }

        /// <summary>
        /// 筹资活动现金流出小计
        /// </summary>
        [Display(Name = "筹资活动现金流出小计"), StringLength(20), MoneyAttribute(ErrorMessage = "筹资活动现金流出小计数据不正确")]
        public decimal? FinancingCashOutflow { get; set; }

        /// <summary>
        /// 筹集活动产生的现金流量净额
        /// </summary>
        [Display(Name = "筹集活动产生的现金流量净额"), Required, StringLength(20), MoneyAttribute(ErrorMessage = "筹集活动产生的现金流量净额数据不正确")]
        public decimal? FinancingNetCash { get; set; }

        /// <summary>
        /// 汇率变动对现金及现金等价物的影响
        /// </summary>
        [Display(Name = "汇率变动对现金及现金等价物的影响"), StringLength(20), MoneyAttribute(ErrorMessage = "汇率变动对现金及现金等价物的影响数据不正确")]
        public decimal? ExchangeRateChangeCash { get; set; }

        /// <summary>
        /// 现金及现金等价物净增加额(五)
        /// </summary>
        [Display(Name = "现金及现金等价物净增加额(五)"), StringLength(20), Required, MoneyAttribute(ErrorMessage = "现金及现金等价物净增加额(五)数据不正确")]
        public decimal? CashIncrease5 { get; set; }

        /// <summary>
        /// 期初现金及现金等价物余额
        /// </summary>
        [Display(Name = "期初现金及现金等价物余额"), StringLength(20), MoneyAttribute(ErrorMessage = "期初现金及现金等价物余额数据不正确")]
        public decimal? BeginCashBalance { get; set; }

        /// <summary>
        /// 期末现金及现金等价物余额(六)
        /// </summary>
        [Display(Name = "期末现金及现金等价物余额(六)"), StringLength(20), Required, MoneyAttribute(ErrorMessage = "期末现金及现金等价物余额(六)数据不正确")]
        public decimal? FinalCashBalance6 { get; set; }

        /// <summary>
        /// 净利润
        /// </summary>
        [Display(Name = "期末现金及现金等价物余额(六)"), StringLength(20), Required, MoneyAttribute(ErrorMessage = "期末现金及现金等价物余额(六)数据不正确")]
        public decimal? NetProfit { get; set; }

        /// <summary>
        /// 资产减值准备
        /// </summary>
        [Display(Name = "资产减值准备"), StringLength(20), MoneyAttribute(ErrorMessage = "资产减值准备数据不正确")]
        public decimal? AssetImpairment { get; set; }

        /// <summary>
        /// 固定资产折旧、油气资 产折耗、生产性生物资产折旧
        /// </summary>
        [Display(Name = "固定资产折旧、油气资 产折耗、生产性生物资产折旧"), StringLength(20), MoneyAttribute(ErrorMessage = "固定资产折旧、油气资 产折耗、生产性生物资产折旧数据不正确")]
        public decimal? AssetsDepreciation { get; set; }

        /// <summary>
        /// 无形资产摊销
        /// </summary>
        [Display(Name = "无形资产摊销"), StringLength(20), MoneyAttribute(ErrorMessage = "无形资产摊销数据不正确")]
        public decimal? IntangibleAssetsAmortization { get; set; }

        /// <summary>
        /// 长期待摊费用摊销
        /// </summary>
        [Display(Name = "长期待摊费用摊销"), StringLength(20), MoneyAttribute(ErrorMessage = "长期待摊费用摊销数据不正确")]
        public decimal? LongPrepaidExpenses { get; set; }

        /// <summary>
        /// 待摊费用减少
        /// </summary>
        [Display(Name = "待摊费用减少"), StringLength(20), MoneyAttribute(ErrorMessage = "待摊费用减少数据不正确")]
        public decimal? PrepaidExpensesLessen { get; set; }

        /// <summary>
        /// 预提费用增
        /// </summary>
        [Display(Name = "预提费用增"), StringLength(20), MoneyAttribute(ErrorMessage = "预提费用增数据不正确")]
        public decimal? AccruedExpenses { get; set; }

        /// <summary>
        /// 处置固定资产无形资产和其他长期资产的损失
        /// </summary>
        [Display(Name = "处置固定资产无形资产和其他长期资产的损失"), StringLength(20), MoneyAttribute(ErrorMessage = "处置固定资产无形资产和其他长期资产的损失数据不正确")]
        public decimal? Assetloss { get; set; }

        /// <summary>
        /// 固定资产报废损失
        /// </summary>
        [Display(Name = "固定资产报废损失"), StringLength(20), MoneyAttribute(ErrorMessage = "固定资产报废损失损失数据不正确")]
        public decimal? FixedAssetsScrap { get; set; }

        /// <summary>
        /// 公允价值变动损失
        /// </summary>
        [Display(Name = "公允价值变动损失"), StringLength(20), MoneyAttribute(ErrorMessage = "公允价值变动损失数据不正确")]
        public decimal? FairChanges { get; set; }

        /// <summary>
        /// 财务费用
        /// </summary>
        [Display(Name = "财务费用"), StringLength(20), MoneyAttribute(ErrorMessage = "财务费用数据不正确")]
        public decimal? FinancialExpenses { get; set; }

        /// <summary>
        /// 投资损失
        /// </summary>
        [Display(Name = "投资损失"), StringLength(20), MoneyAttribute(ErrorMessage = "投资损失数据不正确")]
        public decimal? InvestmentLosses { get; set; }

        /// <summary>
        /// 递延所得税资产减少
        /// </summary>
        [Display(Name = "递延所得税资产减少"), StringLength(20), MoneyAttribute(ErrorMessage = "递延所得税资产减少数据不正确")]
        public decimal? DeferredIncomeTaxLessen { get; set; }

        /// <summary>
        /// 递延所得税资产增加
        /// </summary>
        [Display(Name = "递延所得税资产增加"), StringLength(20), MoneyAttribute(ErrorMessage = "递延所得税资产增加数据不正确")]
        public decimal? DeferredIncomeTaAdd { get; set; }

        /// <summary>
        /// 存货的减少
        /// </summary>
        [Display(Name = "存货的减少"), StringLength(20), MoneyAttribute(ErrorMessage = "存货的减少数据不正确")]
        public decimal? Inventoryreduction { get; set; }

        /// <summary>
        /// 经营性应收项目的减少
        /// </summary>
        [Display(Name = "经营性应收项目的减少"), StringLength(20), MoneyAttribute(ErrorMessage = "经营性应收项目的减少数据不正确")]
        public decimal? ReceivableItemLosses { get; set; }

        /// <summary>
        /// 经营性应付项目的增加
        /// </summary>
        [Display(Name = "经营性应付项目的增加"), StringLength(20), MoneyAttribute(ErrorMessage = "经营性应付项目的增加数据不正确")]
        public decimal? PayablesAdd { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        [Display(Name = "其他"), StringLength(20), MoneyAttribute(ErrorMessage = "其他数据不正确")]
        public decimal? Other { get; set; }

        /// <summary>
        /// 经营活动产生的现金流量净额
        /// </summary>
        [Display(Name = "经营活动产生的现金流量净额"), StringLength(20), MoneyAttribute(ErrorMessage = "经营活动产生的现金流量净额数据不正确")]
        public decimal? OperatingCashFlowsNet { get; set; }

        /// <summary>
        /// 债务转为资本
        /// </summary>
        [Display(Name = "债务转为资本"), StringLength(20), MoneyAttribute(ErrorMessage = "债务转为资本数据不正确")]
        public decimal? CapitalDebt { get; set; }

        /// <summary>
        /// 一年内到期的可转换公司债券
        /// </summary>
        [Display(Name = "一年内到期的可转换公司债券"), StringLength(20), MoneyAttribute(ErrorMessage = "一年内到期的可转换公司债券数据不正确")]
        public decimal? CorporateBondInYear { get; set; }

        /// <summary>
        /// 融资租入固定资产
        /// </summary>
        [Display(Name = "融资租入固定资产"), StringLength(20), MoneyAttribute(ErrorMessage = "融资租入固定资产数据不正确")]
        public decimal? FinancingFixedAssets { get; set; }

        /// <summary>
        /// 现金的期末余额
        /// </summary>
        [Display(Name = "现金的期末余额"), StringLength(20), MoneyAttribute(ErrorMessage = "现金的期末余额数据不正确")]
        public decimal? EndingBalance { get; set; }

        /// <summary>
        /// 现金的期初余额
        /// </summary>
        [Display(Name = "现金的期初余额"), StringLength(20), MoneyAttribute(ErrorMessage = "现金的期初余额数据不正确")]
        public decimal? BeginBalance { get; set; }

        /// <summary>
        /// 现金等价物的期末余额
        /// </summary>
        [Display(Name = "现金等价物的期末余额"), StringLength(20), MoneyAttribute(ErrorMessage = "现金等价物的期末余额数据不正确")]
        public decimal? CashEquivalentsEndingBalance { get; set; }

        /// <summary>
        /// 现金等价物的期初余额
        /// </summary>
        [Display(Name = "现金等价物的期初余额"), StringLength(20), MoneyAttribute(ErrorMessage = "现金等价物的期初余额数据不正确")]
        public decimal? CashEquivalentsBeginBalance { get; set; }

        /// <summary>
        /// 现金及现金等价物净增加额
        /// </summary>
        [Display(Name = "现金及现金等价物净增加额"), StringLength(20), MoneyAttribute(ErrorMessage = "现金及现金等价物净增加额数据不正确")]
        public decimal? CashEquivalentsNetIncrease { get; set; }
    }
}
