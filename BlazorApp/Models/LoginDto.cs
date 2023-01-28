using BlazorApp.Models.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class LoginDto
    {
        [EmailValidator(Domain = "gmail.com")]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
