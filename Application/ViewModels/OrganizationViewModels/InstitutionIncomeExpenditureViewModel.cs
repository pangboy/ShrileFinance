namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 事业单位收入支出
    /// </summary>
    [InstitutionIncomeExpenditureAttribute]
    public class InstitutionIncomeExpenditureViewModel : IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 报表类型
        /// </summary>
        public int Type { get; set; }

        [Display(Name = "财政补助收入"), StringLength(20), MoneyAttribute(ErrorMessage = "财政补助收入数据不正确")]
        public decimal? 财政补助收入 { get; set; }

        [Display(Name = "上级补助收入"), StringLength(20), MoneyAttribute(ErrorMessage = "上级补助收入数据不正确")]
        public decimal? 上级补助收入 { get; set; }

        [Display(Name = "附属单位缴款"), StringLength(20), MoneyAttribute(ErrorMessage = "附属单位缴款数据不正确")]
        public decimal? 附属单位缴款 { get; set; }

        [Display(Name = "事业收入"), StringLength(20), MoneyAttribute(ErrorMessage = "事业收入数据不正确")]
        public decimal? 事业收入 { get; set; }

        [Display(Name = "预算外资金收入"), StringLength(20), MoneyAttribute(ErrorMessage = "预算外资金收入数据不正确")]
        public decimal? 预算外资金收入 { get; set; }

        [Display(Name = "其他收入"), StringLength(20), MoneyAttribute(ErrorMessage = "其他收入数据不正确")]
        public decimal? 其他收入 { get; set; }

        [Display(Name = "事业收入小计"), StringLength(20), MoneyAttribute(ErrorMessage = "事业收入小计数据不正确")]
        public decimal? 事业收入小计 { get; set; }

        [Display(Name = "经营收入"), StringLength(20), MoneyAttribute(ErrorMessage = "经营收入数据不正确")]
        public decimal? 经营收入 { get; set; }

        [Display(Name = "经营收入小计"), StringLength(20), MoneyAttribute(ErrorMessage = "经营收入小计数据不正确")]
        public decimal? 经营收入小计 { get; set; }

        [Display(Name = "拨入专款"), StringLength(20), MoneyAttribute(ErrorMessage = "拨入专款数据不正确")]
        public decimal? 拨入专款 { get; set; }

        [Display(Name = "拨入专款小计"), StringLength(20), MoneyAttribute(ErrorMessage = "拨入专款小计数据不正确")]
        public decimal? 拨入专款小计 { get; set; }

        [Display(Name = "收入总计"), StringLength(20), MoneyAttribute(ErrorMessage = "收入总计数据不正确")]
        public decimal? 收入总计 { get; set; }

        [Display(Name = "拨出经费"), StringLength(20), MoneyAttribute(ErrorMessage = "拨出经费据不正确")]
        public decimal? 拨出经费 { get; set; }

        [Display(Name = "上缴上级支出"), StringLength(20), MoneyAttribute(ErrorMessage = "上缴上级支出数据不正确")]
        public decimal? 上缴上级支出 { get; set; }

        [Display(Name = "对附属单位补助"), StringLength(20), MoneyAttribute(ErrorMessage = "对附属单位补助数据不正确")]
        public decimal? 对附属单位补助 { get; set; }

        [Display(Name = "事业支出"), StringLength(20), MoneyAttribute(ErrorMessage = "事业支出数据不正确")]
        public decimal? 事业支出 { get; set; }

        [Display(Name = "财政补助支出"), StringLength(20), MoneyAttribute(ErrorMessage = "财政补助支出数据不正确")]
        public decimal? 财政补助支出 { get; set; }

        [Display(Name = "预算外资金支出"), StringLength(20), MoneyAttribute(ErrorMessage = "预算外资金支出数据不正确")]
        public decimal? 预算外资金支出 { get; set; }

        [Display(Name = "销售税金"), StringLength(20), MoneyAttribute(ErrorMessage = "销售税金数据不正确")]
        public decimal? 销售税金 { get; set; }

        [Display(Name = "结转自筹基建"), StringLength(20), MoneyAttribute(ErrorMessage = "结转自筹基建数据不正确")]
        public decimal? 结转自筹基建 { get; set; }

        [Display(Name = "事业支出小计"), StringLength(20), MoneyAttribute(ErrorMessage = "事业支出小计数据不正确")]
        public decimal? 事业支出小计 { get; set; }

        [Display(Name = "经营支出"), StringLength(20), MoneyAttribute(ErrorMessage = "经营支出数据不正确")]
        public decimal? 经营支出 { get; set; }

        [Display(Name = "销售税金1"), StringLength(20), MoneyAttribute(ErrorMessage = "销售税金1数据不正确")]
        public decimal? 销售税金1 { get; set; }

        [Display(Name = "经营支出小计"), StringLength(20), MoneyAttribute(ErrorMessage = "经营支出小计数据不正确")]
        public decimal? 经营支出小计 { get; set; }

        [Display(Name = "拨出专款"), StringLength(20), MoneyAttribute(ErrorMessage = "拨出专款数据不正确")]
        public decimal? 拨出专款 { get; set; }

        [Display(Name = "专款支出"), StringLength(20), MoneyAttribute(ErrorMessage = "专款支出数据不正确")]
        public decimal? 专款支出 { get; set; }

        [Display(Name = "专款小计"), StringLength(20), MoneyAttribute(ErrorMessage = "专款小计数据不正确")]
        public decimal? 专款小计 { get; set; }

        [Display(Name = "支出总计"), StringLength(20), MoneyAttribute(ErrorMessage = "支出总计数据不正确")]
        public decimal? 支出总计 { get; set; }

        [Display(Name = "事业结余"), StringLength(20), Required, MoneyAttribute(ErrorMessage = "事业结余数据不正确")]
        public decimal? 事业结余 { get; set; }

        [Display(Name = "正常收入结余"), StringLength(20), MoneyAttribute(ErrorMessage = "正常收入结余数据不正确")]
        public decimal? 正常收入结余 { get; set; }

        [Display(Name = "收回以前年度事业支出"), StringLength(20), MoneyAttribute(ErrorMessage = "收回以前年度事业支出数据不正确")]
        public decimal? 收回以前年度事业支出 { get; set; }

        [Display(Name = "经营结余"), StringLength(20), Required, MoneyAttribute(ErrorMessage = "经营结余数据不正确")]
        public decimal? 经营结余 { get; set; }

        [Display(Name = "以前年度经营亏损"), StringLength(20), MoneyAttribute(ErrorMessage = "以前年度经营亏损数据不正确")]
        public decimal? 以前年度经营亏损 { get; set; }

        [Display(Name = "结余分配"), StringLength(20), MoneyAttribute(ErrorMessage = "结余分配数据不正确")]
        public decimal? 结余分配 { get; set; }

        [Display(Name = "应交所得税"), StringLength(20), MoneyAttribute(ErrorMessage = "应交所得税数据不正确")]
        public decimal? 应交所得税 { get; set; }

        [Display(Name = "提取专用基金"), StringLength(20), MoneyAttribute(ErrorMessage = "提取专用基金数据不正确")]
        public decimal? 提取专用基金 { get; set; }

        [Display(Name = "转入事业基金"), StringLength(20), MoneyAttribute(ErrorMessage = "转入事业基金数据不正确")]
        public decimal? 转入事业基金 { get; set; }

        [Display(Name = "其他结余分配"), StringLength(20), MoneyAttribute(ErrorMessage = "其他结余分配数据不正确")]
        public decimal? 其他结余分配 { get; set; }
    }
}
