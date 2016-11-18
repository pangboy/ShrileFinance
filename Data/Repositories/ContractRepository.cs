namespace Data.Repositories
{
    using System;
    using System.Data.SqlClient;
    using System.Runtime.Remoting.Contexts;
    using Core.Entities.Finance;
    using Core.Interfaces.Repositories;

    public class ContractRepository:BaseRepository<Contract>, IContractRepository
    {
        public ContractRepository(MyContext context):base(context)
        {
        }
    }
}
