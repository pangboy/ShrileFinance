namespace Core.Interfaces.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<TEntity> 
        where TEntity : IAggregateRoot
    {
        TEntity Get(Guid key);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity entity);

        void Modify(TEntity entity);

        void Remove(Guid key);
    }
}
