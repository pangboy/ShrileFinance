namespace Data.Repositories
{
    using System.Collections.Generic;
    using Core.Entities.Produce;
    using Core.Interfaces.Repositories;

    public class ProduceRepository : BaseRepository<Produce>, IProduceRepository
    {
        public ProduceRepository(MyContext context) : base(context)
        {
        }
    }
}
