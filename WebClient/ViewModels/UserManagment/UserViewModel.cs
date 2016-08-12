using System.ComponentModel;

namespace WebClient.ViewModels.UserManagment
{
    using DataAccess.Models;
    using Mapping;
    public class UserViewModel : BaseEntityViewModel, IMapFrom<User>
    {
        public int Id { get; set; }
        [DisplayName("Username")]
        public string Username { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }
        
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Role")]
        public Role Role { get; set; }
    }
}