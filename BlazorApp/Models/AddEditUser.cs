using BlazorApp.Models.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class AddEditUser
    {
        [Required]
        [EmailValidator(Domain = "gmail.com")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [CompareProperty("ConfirmPassword")]
        public string Password { get; set; } = string.Empty;
        [CompareProperty("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
