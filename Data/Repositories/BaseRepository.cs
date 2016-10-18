namespace Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Entities;
    using Core.Interfaces;
    using Core.Interfaces.Repositories;

    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        private readonly DbContext context;

        protected BaseRepository(DbContext context)
        {
            this.context = context;
        }

        protected DbContext Context
        {
            get { return context; }
        }

        private DbSet<TEntity> Entities
        {
            get { return context.Set<TEntity>(); }
        }

        public TEntity Get(Guid key)
        {
            return Entities.Find(key);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = Entities.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }

        public void Create(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Modify(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }
    }
}
