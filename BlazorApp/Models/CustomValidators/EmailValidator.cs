using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.CustomValidators
{
    public class EmailValidator : ValidationAttribute
    {
        public string Domain { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string[] strings = value.ToString().Split('@');
            if(strings.Length != 2) 
            {
                return new ValidationResult("enter valid input, email is required", new[] {validationContext.MemberName});
            }
            if (strings[0].Length < 3)
            {
                return new ValidationResult("use more then 3 char before @", new[] { validationContext.MemberName });
            }
            strings[1] = strings[1].Replace(" ", string.Empty);
            if (strings[1].ToUpper() != Domain.ToUpper())
            {
                return new ValidationResult($"domain must include @{Domain}", new[] { validationContext.MemberName });
            }
            return null;
        }
    }
}
