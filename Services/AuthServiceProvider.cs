namespace Services
{
    using System;
    using System.Linq;
    using System.Web;
    using DataAccess.Models;
    using DataAccess.Repositories;

    public class AuthServiceProvider
    {
        public static User User
        {
            get
            {
                AuthenticationService authenticationService = null;
                if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
                {
                    HttpContext.Current.Session["LoggedUser"] = new AuthenticationService();
                }

                authenticationService = (AuthenticationService)HttpContext.Current.Session["LoggedUser"];
                return authenticationService.User;
            }
        }

        public static bool IsAdmin()
        {
            if (User == null)
            {
                return false;
            }

            return User.Role == Role.Admin;
        }

        public static bool Auth(string username, string password)
        {
            AuthenticationService authenticationService = null;
            if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
            {
                HttpContext.Current.Session["LoggedUser"] = new AuthenticationService();
            }

            authenticationService = (AuthenticationService)HttpContext.Current.Session["LoggedUser"];
            authenticationService.Authenticate(username, password);

            return true;
        }

        public static void Logout()
        {
            HttpContext.Current.Session["LoggedUser"] = null;
        }
    }
}