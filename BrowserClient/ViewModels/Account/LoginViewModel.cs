namespace BrowserClient.ViewModels.Account
{
    using DataAccess.Models;
    using Mapping;
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel : IMapFrom<User>
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}