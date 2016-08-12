using Services.EntityServices;

namespace WebClient.Controllers
{
    using DataAccess.Models;
    using DataAccess.Repositories;
    using ViewModels.UserManagment;

    public class UserController : BaseController<User, UserViewModel, UserListViewModel, UserEditViewModel, UserService, UserFilter>
    {
    }
}
