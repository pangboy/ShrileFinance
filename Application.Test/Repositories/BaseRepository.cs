namespace Application.Test.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Entities;
    using Core.Interfaces;
    using Core.Interfaces.Repositories;

    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        protected BaseRepository()
        {
            Entities = new List<TEntity>();
        }

        protected List<TEntity> Entities { get; set; }

        public TEntity Get(Guid key)
        {
            return Entities.Find(m => m.Id == key);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public void Create(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Modify(TEntity entity)
        {
            var i = Entities.FindIndex(m => m.Id == entity.Id);

            Entities[i] = entity;
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public int Commit()
        {
            return 0;
        }
    }
}
