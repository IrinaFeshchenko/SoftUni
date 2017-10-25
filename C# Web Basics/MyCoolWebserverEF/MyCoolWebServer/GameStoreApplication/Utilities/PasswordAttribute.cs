namespace MyCoolWebServer.GameStoreApplication.Utilities
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PasswordAttribute : ValidationAttribute
    {
        public PasswordAttribute()
        {
            this.ErrorMessage = "Password must be at least 6 simbols, should contain upper, lower simbol and number";
        }

        public override bool IsValid(object value)
        {
            var password = value as string;
            if (password == null)
            {
                return true;
            }

            return password.Any(p => char.IsUpper(p)) 
                && password.Any(p => char.IsLower(p))
                && password.Any(p => char.IsDigit(p));
        }
    }
}
