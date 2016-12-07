namespace DataAccess
{
    using Models;
    using System.Data.Entity;

    public class AppDataContext : DbContext
    {
        public AppDataContext() : base("DataAccess.AppDataContext")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
