using WebClient.Validation;

namespace WebClient.ViewModels.UserManagment
{
    using DataAccess.Models;
    using Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserEditViewModel : IMapFrom<User>, IMapTo<User>
    {
        public int Id { get; set; }

        [Display(Name = "User Username")]
        [Required(ErrorMessage = "Username is required")]
        [UniqueField(Service = "UserService", Field = "Username", ErrorMessage = "There is user with such username!")]
        public string Username { get; set; }

        [Display(Name = "User Password")]
        [Required(ErrorMessage = "Username is required")]
        public string Password { get; set; }

        [Display(Name = "User Password repeat")]
        [Required(ErrorMessage = "User Password Repeat is required!")]
        [ConfirmField(FieldToConfirm = "Password", ErrorMessage = "Please confirm password!")]
        public string PasswordRepeat { get; set; }

        [Display(Name = "User First name")]
        [Required(ErrorMessage = "Username is required")]
        public string FirstName { get; set; }

        [Display(Name = "User Last name")]
        [Required(ErrorMessage = "Username is required")]
        public string LastName { get; set; }

        [Display(Name = "User Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter valid Email address")]
        [UniqueField(Service = "UserService", Field = "Email", ErrorMessage = "There is user with such email!")]
        public string Email { get; set; }

        [Display(Name = "User Role")]
        [Required(ErrorMessage = "Role is required")]
        public Role Role { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}