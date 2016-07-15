namespace WebTamplate.ViewModels.UserManagment
{
    using DataAccess.Models;
    using Mapping;
    using System;
    public class UserEditViewModel : IMapFrom<User>, IMapTo<User>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}