namespace Data.Repositories
{
    using Core.Entities.Finance;
    using Core.Interfaces.Repositories;

    public class ContractRespository:BaseRepository<Contract>, IContractRepository
    {
        public ContractRespository(MyContext context):base(context)
        {
        }
    }
}
