namespace Data.Repositories
{
    using Core.Interfaces.Repositories;
    using Core.Entities.CreditExamineReport;
    using System;

    public class CreditExamineReportRepository:BaseRepository<CreditExamineReport>,ICreditExamineReportRepository
    {
        private readonly MyContext context;

        public CreditExamineReportRepository(MyContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// 通过融资标识获取信审实体
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>信审实体</returns>
        public CreditExamineReport GetByFinanceId(Guid financeId)
        {
            return null;
        }
    }
}
