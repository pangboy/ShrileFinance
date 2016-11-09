namespace Core.Interfaces.Repositories
{
    using System.Collections.Generic;
    using Entities.Produce;

    /// <summary>
    /// 仓储
    /// </summary>
    public interface IProduceRepository : IRepository<Produce>
    {
        IEnumerable<Produce> GetByCode(string code);
    }
}
