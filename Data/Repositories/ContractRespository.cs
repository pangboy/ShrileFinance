namespace Data.Repositories
{
    using System;
    using System.Data.SqlClient;
    using System.Runtime.Remoting.Contexts;
    using Core.Entities.Finance;
    using Core.Interfaces.Repositories;

    public class ContractRespository:BaseRepository<Contract>, IContractRepository
    {
        public ContractRespository(MyContext context):base(context)
        {
        }
    }
}
