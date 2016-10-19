namespace Core.Interfaces.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Entities;

    public interface IRepository<TEntity> : IUnitOfWork
        where TEntity : Entity, IAggregateRoot
    {
        TEntity Get(Guid key);

        IQueryable<Entity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity entity);

        void Modify(TEntity entity);

        void Remove(TEntity entity);
    }
}
