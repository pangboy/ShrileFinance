using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    using Entities.Finance;

    /// <summary>
    /// 信审报告仓储
    /// </summary>
    public interface ICreditExamineReportRepository:IRepository<CreditExamine>
    {
        CreditExamine GetByFinanceId(Guid financeId);
    }
}
