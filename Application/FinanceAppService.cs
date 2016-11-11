namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Finance;
    using Core.Entities.Produce;
    using Core.Interfaces.Repositories;
    using ViewModels.FinanceViewModels;

    /// <summary>
    /// 融资
    /// </summary>
    public class FinanceAppService
    {
        private readonly IFinanceRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceAppService" /> class.
        /// </summary>
        /// <param name="repository">融资仓储</param>
        public FinanceAppService(IFinanceRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 通过融资标识获取信审ViewModel
        /// </summary>
        /// <param name="financeId">信审标识</param>
        /// <returns>信审ViewModel</returns>
        public CreditExamineViewModel GetCreditExamineByFinanceId(Guid financeId)
        {
            if (financeId == null)
            {
                return null;
            }

            // 获取信审报告实体
            var finance = repository.Get(financeId);

            // 实体转ViewModel
            var creditExamineReportViewModel = Mapper.Map<CreditExamineViewModel>(finance.CreditExamine);

            return creditExamineReportViewModel;
        }

        /// <summary>
        /// 编辑信审报告
        /// </summary>
        /// <param name="value">信审ViewModel</param>
        public void EditCreditExamine(CreditExamineViewModel value)
        {
            if (value == null || value.FinanceId == null)
            {
                return;
            }

            // 获取该信审对应的融资实体
            var finance = repository.Get(value.FinanceId);

            // 信审ViewModel转信审实体
            var creditExamine = Mapper.Map<CreditExamine>(value);

            // 更新信审
            finance.CreditExamine = creditExamine;

            repository.Modify(finance);

            // 执行修改
            repository.Commit();
        }

        /// <summary>
        /// 通过融资标识获取融资审核ViewModel
        /// </summary>
        /// <param name="financeId">信审标识</param>
        /// <returns>融资审核ViewModel</returns>
        public FinanceAuidtViewModel GetFinanceAuidtByFinanceId(Guid financeId)
        {
            if (financeId == null)
            {
                return null;
            }

            // 获取信审报告实体
            var finance = repository.Get(financeId);

            // 实体转ViewModel
            var financeAuditViewModel = Mapper.Map<FinanceAuidtViewModel>(finance.FinanceAudit);

            financeAuditViewModel.FinanceId = financeId;

            // 获取融资项
            financeAuditViewModel.FinancingItems = GetFinancingItems(finance);

            return financeAuditViewModel;
        }

        /// <summary>
        /// 编辑融资审核
        /// </summary>
        /// <param name="value">融资审核ViewModel</param>
        /// <param name="isReview">是否为复审</param>
        public void EditFinanceAuidt(FinanceAuidtViewModel value, bool isReview = false)
        {
            if (value == null || value.FinanceId == null)
            {
                return;
            }

            // 获取该融资审核对应的融资实体
            var finance = repository.Get(value.FinanceId);

            // 融资审核ViewModel转实体
            var financeAudit = Mapper.Map<FinanceAudit>(value);

            finance.FinanceAudit = financeAudit;

            // 初审 修改融资项各金额
            if (!isReview)
            {
                // 修改融资项各金额
                finance.Produce.FinancingItems = EditFinanceAuidts(financingItems: finance.Produce.FinancingItems, financingItemCollection: value.FinancingItems);
            }

            repository.Modify(finance);

            // 执行修改
            repository.Commit();
        }

        /// <summary>
        ///  获取融资项
        /// </summary>
        /// <param name="finance">融资实体</param>
        /// <returns>融资项</returns>
        private ICollection<KeyValuePair<Guid, KeyValuePair<string, decimal>>> GetFinancingItems(Finance finance)
        {
            var financingItems = new List<KeyValuePair<Guid, KeyValuePair<string, decimal>>>();

            // 提取融资项
            finance.Produce.FinancingItems.ToList().ForEach(delegate(FinancingItem item)
            {
                financingItems.Add(new KeyValuePair<Guid, KeyValuePair<string, decimal>>(item.FinancingProject.Id, new KeyValuePair<string, decimal>(item.FinancingProject.Name, item.Money)));
            });

            return financingItems;
        }

        /// <summary>
        /// 修改融资项各金额
        /// </summary>
        /// <param name="financingItems">产品对应的融资项</param>
        /// <param name="financingItemCollection">前端传回融资项</param>
        /// <returns></returns>
        private ICollection<FinancingItem> EditFinanceAuidts(ICollection<FinancingItem> financingItems, ICollection<KeyValuePair<Guid, KeyValuePair<string, decimal>>> financingItemCollection)
        {
            var financingItemList = financingItems.ToList();

            // 更新融资项各金额
            financingItemList.ForEach(delegate(FinancingItem financingItem)
            {
                // 获取融资项标识
                var key = financingItem.FinancingProject.Id;

                // 更新指定融资项对应的金额
                financingItem.Money = financingItemCollection.Single(m => m.Key.Equals(key)).Value.Value;
            });

            return financingItemList;
        }
    }
}
