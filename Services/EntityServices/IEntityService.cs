using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EntityServices
{
    public interface IEntityService<T>
    {
        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

        void SaveChanges();

        T Get(int id);

        IQueryable<T> GetAll();
    }
}
