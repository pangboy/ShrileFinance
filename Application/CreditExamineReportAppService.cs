namespace Application
{
    using System;
    using AutoMapper;
    using Core.Entities.CreditExamineReport;
    using Core.Interfaces.Repositories;
    using ViewModels.CreditExamineReportViewModels;

    /// <summary>
    /// 信审报告
    /// </summary>
    public class CreditExamineReportAppService
    {
        private readonly ICreditExamineReportRepository repository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository">信审报告聚合根</param>
        public CreditExamineReportAppService(ICreditExamineReportRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 通过信审标识获取信审ViewModel
        /// </summary>
        /// <param name="id">信审标识</param>
        /// <returns>信审ViewModel</returns>
        public CreditExamineReportViewModel Get(Guid id)
        {
            // 获取信审报告实体
            var creditExamineReport = repository.Get(id);

            // 实体转ViewModel
            var creditExamineReportViewModel = Mapper.Map<CreditExamineReportViewModel>(creditExamineReport);

            return creditExamineReportViewModel;
        }

        /// <summary>
        /// 通过融资标识获取信审ViewModel
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>信审ViewModel</returns>
        public CreditExamineReportViewModel GetByFinanceId(Guid financeId)
        {
            // 获取信审报告实体
            var creditExamineReport = repository.GetByFinanceId(financeId);

            // 实体转ViewModel
            var creditExamineReportViewModel = Mapper.Map<CreditExamineReportViewModel>(creditExamineReport);

            return creditExamineReportViewModel;
        }

        public void Create(CreditExamineReportViewModel value)
        {
            // ViewModel转实体
            var creditExamineReport = Mapper.Map<CreditExamineReport>(value);

            repository.Create(creditExamineReport);

            // 执行修改
            repository.Commit();
        }

        public void Modify(CreditExamineReportViewModel value)
        {
            var creditExamineReport = Mapper.Map<CreditExamineReport>(value);

            repository.Modify(creditExamineReport);

            // 执行修改
            repository.Commit();
        }
    }
}
