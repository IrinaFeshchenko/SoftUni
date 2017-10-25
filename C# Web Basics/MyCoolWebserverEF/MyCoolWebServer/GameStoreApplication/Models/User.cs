namespace MyCoolWebServer.GameStoreApplication.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyCoolWebServer.GameStoreApplication.Common;

    public class User
    {
        public int Id { get; set; }

        [MaxLength(ValidationConstants.Account.NameMaxLength)]
        [MinLength(ValidationConstants.Account.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ValidationConstants.Account.EmailMaxLength)]
        [MinLength(ValidationConstants.Account.EmailMinLength)]
        public string Email { get; set; }

        [MaxLength(ValidationConstants.Account.PasswordMaxLength)]
        [MinLength(ValidationConstants.Account.PasswordMinLength)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public List<UserGame> Games { get; set; } = new List<UserGame>();
    }
}
