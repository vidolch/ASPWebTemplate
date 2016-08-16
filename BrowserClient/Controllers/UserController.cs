using Services.EntityServices;

namespace BrowserClient.Controllers
{
    using DataAccess.Models;
    using DataAccess.Repositories;
    using ViewModels.UserManagment;

    public class UserController : BaseController<User, UserViewModel, UserListViewModel, UserEditViewModel, UserFilter>
    {
        public UserController() : base(new UserService())
        {
            
        }
    }
}
