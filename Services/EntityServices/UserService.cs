namespace Services.EntityServices
{
    using DataAccess.Models;
    using DataAccess.Repositories;

    public class UserService : BaseService<User>
    {
        public UserService() : base(new UserRepository())
        {
            
        }
    }
}
