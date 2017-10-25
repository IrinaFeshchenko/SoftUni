namespace MyCoolWebServer.GameStoreApplication.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using MyCoolWebServer.GameStoreApplication.Common;
    using MyCoolWebServer.GameStoreApplication.Utilities;

    public class LoginViewModel
    {
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
