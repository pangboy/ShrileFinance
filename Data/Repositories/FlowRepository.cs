namespace Data.Repositories
{
    using Core.Entities.Flow;
    using Core.Interfaces.Repositories;

    public class FlowRepository : BaseRepository<Flow>, IFlowRepository
    {
        public FlowRepository(MyContext context) : base(context)
        {
        }
    }
}
