namespace DataAccess.Database
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;

    public class GenericDbContext<T> : DbContext
        where T : class
    {
        public GenericDbContext()
            : base("DataAccess.AppDataContext")
        {
        }

        public DbSet<T> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<GenericDbContext<T>>(null);
        }
    }
}