namespace MyCoolWebServer.GameStoreApplication.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    using MyCoolWebServer.GameStoreApplication.Common;
    using MyCoolWebServer.GameStoreApplication.Utilities;

    public class RegisterViewModel
    {
        [Display(Name = "E-mail")]
        [Required]
        [EmailAddress]
        [Email]
        [MaxLength(ValidationConstants.Account.EmailMaxLength, ErrorMessage = ValidationConstants.InvalidMaxLengthErrorMessage)]
        [MinLength(ValidationConstants.Account.EmailMinLength, ErrorMessage = ValidationConstants.InvalidMinLengthErrorMessage)]
        public string Email { get; set; }

        [Display(Name = "Full Name")]
        [MaxLength(ValidationConstants.Account.NameMaxLength)]
        [MinLength(ValidationConstants.Account.NameMinLength)]
        public string FullName { get; set; }

        [Required]
        [Password]
        [MaxLength(ValidationConstants.Account.PasswordMaxLength)]
        [MinLength(ValidationConstants.Account.PasswordMinLength)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}