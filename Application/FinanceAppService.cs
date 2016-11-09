namespace Application
{
    using System;
    using AutoMapper;
    using Core.Entities.Finance;
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
        /// 通过信审标识获取信审ViewModel
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

            finance.CreditExamine = creditExamine;

            repository.Modify(finance);

            // 执行修改
            repository.Commit();
        }
    }
}
