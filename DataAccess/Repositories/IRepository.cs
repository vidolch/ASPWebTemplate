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

        IQueryable<T> All();

        IQueryable<T> All(int from, int count);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
