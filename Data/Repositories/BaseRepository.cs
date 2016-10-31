namespace Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Entities;
    using Core.Interfaces;
    using Core.Interfaces.Repositories;
    using X.PagedList;
    using System.Data.Entity.Infrastructure;
    using System.Reflection;

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

        protected DbSet<TEntity> Entities
        {
            get { return context.Set<TEntity>(); }
        }

        public TEntity Get(Guid key)
        {
            return Entities.Find(key);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public IPagedList<TEntity> PagedList(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize)
        {
            return GetAll(predicate).OrderByDescending(m => m.Id).ToPagedList(pageNumber, pageSize);
        }

        public void Create(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Modify(TEntity entity)
        {
            var temp = Entities.Find(entity.Id);
            PropertyInfo[] ps1 = entity.GetType().GetProperties();
            PropertyInfo[] ps2 = temp.GetType().GetProperties();

            foreach (PropertyInfo pi in ps1)
            {
                object value1 = pi.GetValue(entity, null);//用pi.GetValue获得值
                string name1 = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                foreach (PropertyInfo ps in ps2)
                {
                    object value2 = pi.GetValue(entity, null);//用pi.GetValue获得值
                    string name2 = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                    if (name1 == name2)
                    {
                        value2 = value1;
                    }
                }
            }
            // 修改值
            Context.Entry(temp).State = EntityState.Modified;

            // Context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }
    }
}
