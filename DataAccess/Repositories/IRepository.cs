namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T>
        where T : class
    {
        int Count { get; }

        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

        T Get(int id);

        IQueryable<T> GetAll();

        IQueryable<T> GetAll(int from, int count);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, int from, int count);
    }
}
