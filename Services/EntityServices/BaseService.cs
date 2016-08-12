namespace Services.EntityServices
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using DataAccess.Models;
    using DataAccess.Repositories;

    public class BaseService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository;

        public BaseService(BaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual int Count(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> items;

            if (predicate == null)
            {
                items = GetAll();
            }
            else
            {
                items = this.GetAll(predicate);
            }
            return items == null ? 0 : items.Count();
        }

        public virtual void Add(T entity)
        {
            this.repository.Add(entity);
        }

        public virtual void Remove(T entity)
        {
            this.repository.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            this.repository.Update(entity);
        }

        public virtual void AddOrUpdate(T entity)
        {
            if (entity.Id == 0)
            {
                this.Add(entity);
            }
            else
            {
                this.Update(entity);
            }
        }

        public virtual void SaveChanges()
        {
            this.repository.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return this.repository.Get(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.repository.GetAll();
        }

        public virtual IQueryable<T> GetAll(int from, int count)
        {
            return this.repository.GetAll(from, count);
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return this.repository.GetAll(predicate);
        }
        
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, int from, int count)
        {
            return this.repository.GetAll(predicate, from, count);
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }
    }
}
