using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Produce;
using Core.Interfaces.Repositories;

namespace Data.Repositories
{
    public class FinancingProjectRepository : BaseRepository<FinancingProject>, IFinancingProjectRepository
    {
        public FinancingProjectRepository(MyContext context) : base(context)
        {
        }
    }
}
