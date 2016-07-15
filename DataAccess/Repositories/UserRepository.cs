namespace DataAccess.Repositories
{
    using DataAccess.Models;
    using Database;

    public class UserRepository : BaseRepository<User>
    {
        public UserRepository()
            : base()
        {
            this.Context = new GenericDbContext<User>();
        }
    }
}
