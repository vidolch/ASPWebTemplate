namespace WebClient
{
    using DataAccess.Models;
    using System.Data.Entity;

    class AppDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDataContext()
        {
            Database.SetInitializer<AppDataContext>(null);
        }
    }
}
