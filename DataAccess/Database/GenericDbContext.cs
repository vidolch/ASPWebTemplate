namespace DataAccess.Database
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;

    public class GenericDbContext<T> : DbContext
        where T : class
    {
        public GenericDbContext()
            : base("WebContext")
        {
        }

        public DbSet<T> Items { get; set; }
    }
}