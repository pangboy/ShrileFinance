namespace Data.Repositories
{
    using Core.Entities.Finance;
    using Core.Interfaces.Repositories;

    public class FinanceRepository:BaseRepository<Finance>, IFinanceRepository
    {
        private readonly MyContext context;

        public FinanceRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
