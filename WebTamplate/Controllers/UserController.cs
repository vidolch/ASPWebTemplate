namespace WebTamplate.Controllers
{
    using DataAccess.Models;
    using DataAccess.Repositories;
    using ViewModels.UserManagment;

    public class UserController : BaseController<User, UserViewModel, UserListViewModel, UserEditViewModel>
    {
        private UserRepository db = new UserRepository();
    }
}
