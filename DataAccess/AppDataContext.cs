namespace DataAccess
{
    using Models;
    using System.Data.Entity;

    class AppDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
