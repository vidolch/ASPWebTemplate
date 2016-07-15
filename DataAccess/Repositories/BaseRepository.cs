namespace DataAccess.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;
    using Database;

    public class BaseRepository<T> : IRepository<T>, IDisposable
        where T : BaseEntity
    {
        private GenericDbContext<T> context = new GenericDbContext<T>();

        public BaseRepository()
        {
        }

        public GenericDbContext<T> Context
        {
            get
            {
                return this.context;
            }
            set
            {
                this.context = value;
            }
        }

        public int Count
        {
            get
            {
                return this.Context.Items.Count();
            }
        }

        public virtual void Add(T entity)
        {
            this.Context.Items.Add(entity);
        }

        public virtual IQueryable<T> All()
        {
            return this.Context.Items;
        }

        public virtual IQueryable<T> All(int from, int count)
        {
            return this.All().OrderBy(t => t.Id).Skip(from).Take(count);
        }

        public virtual T Get(int id)
        {
            return this.Context.Items.Find(id);
        }

        public virtual void Update(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
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

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            var all = this.Context.Items.Where(predicate);

            if (all == null)
            {
                return default(IQueryable<T>);
            }

            return all;
        }

        public virtual void Remove(T entity)
        {
            this.Context.Items.Remove(entity);
        }

        public virtual void Attach(T entity)
        {
            this.Context.Items.Attach(entity);
        }

        public void SaveChanges()
        {
            this.ApplyAuditInfoRules();
            try
            {
                this.Context.SaveChanges();
            }
            catch
            {
                var ctx = ((IObjectContextAdapter)this.Context).ObjectContext;
                ctx.Refresh(RefreshMode.ClientWins, this.Context.Items);

                this.Context.SaveChanges();
            }
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.Context.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }

                entity.UpdatedOn = DateTime.Now;
            }
        }
    }
}