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

        public bool Authenticate(string username, string password)
        {
            UserRepository userRepo = new UserRepository();

            User user = userRepo.Find(u => u.Username == username && u.Password == password).FirstOrDefault();

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