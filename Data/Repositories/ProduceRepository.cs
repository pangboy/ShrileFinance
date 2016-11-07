using Core.Entities.Produce;
namespace Data.Repositories
{
    using Core.Interfaces.Repositories;

    public class ProduceRepository : BaseRepository<Produce>, IProduceRepository
    {
        public ProduceRepository(MyContext context) : base(context)
        {
        }
    }
}
