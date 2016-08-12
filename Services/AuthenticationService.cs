using Services.EntityServices;

namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using DataAccess.Repositories;
    using DataAccess.Models;

    public class AuthenticationService
    {
        public User User { get; private set; }

        public bool Authenticate(string email, string password)
        {
            UserService userService = new UserService();

            User user = userService.GetAll(u => u.Email == email && u.Password == password).FirstOrDefault();

            if (user != null)
            {
                this.User = user;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}