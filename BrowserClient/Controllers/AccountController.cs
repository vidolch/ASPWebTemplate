namespace BrowserClient.Controllers
{
    using AutoMapper;
    using DataAccess.Models;
    using Mapping;
    using Services;
    using System.Web.Mvc;

    public class AccountController : Controller
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
        // GET: User/Login
        [HttpGet]
        public ActionResult Login()
        {
            if (AuthServiceProvider.User != null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        // POST: User/Login
        [HttpPost]
        public ActionResult Login([Bind(Include = "Email,Password")] User user)
        {
            if (AuthServiceProvider.User != null)
            {
                return this.RedirectToAction("Index", "Task");
            }

            if (!AuthServiceProvider.Auth(user.Email, user.Password))
            {
                this.ModelState.AddModelError("authenticationFailed", "Wrong username or password!");
                this.ViewData["username"] = user.Username;

                return this.View();
            }

            return this.RedirectToAction("Index", "Home");
        }

        // GET: User/Logout
        [Authorize]
        [HttpGet]
        public ActionResult Logout()
        {
            AuthServiceProvider.Logout();

            return this.RedirectToAction("Login");
        }
    }
}