namespace Core.Interfaces.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Entities;

    public interface IRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        TEntity Get(Guid key);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);

        void Create(TEntity entity);

        void Modify(TEntity entity);

        void Remove(TEntity entity);
    }
}
