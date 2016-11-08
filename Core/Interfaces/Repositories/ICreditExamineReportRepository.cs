using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    using Entities.CreditExamineReport;

    /// <summary>
    /// 信审报告仓储
    /// </summary>
    public interface ICreditExamineReportRepository:IRepository<CreditExamineReport>
    {
        CreditExamineReport GetByFinanceId(Guid financeId);
    }
}
