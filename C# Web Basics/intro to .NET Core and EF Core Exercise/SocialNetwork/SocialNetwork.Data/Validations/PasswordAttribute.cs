namespace SocialNetwork.Data.Validations
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PasswordAttribute : ValidationAttribute
    {
        private readonly char[] RequiredSymbols = new[] { '!','@', '#', '$', '%', '^', '&', '*', '(',')', '_', '+', '<', '>', '?'};
        public PasswordAttribute()
        {
            this.ErrorMessage = "Password is invalid";
        }

        public override bool IsValid(object value)
        {

            var password = value as string;

            if (password == null)
            {
                return true;
            }

            return password.All(s => char.IsLower(s) || char.IsUpper(s) || char.IsDigit(s) || RequiredSymbols.Contains(s));
        }
    }
}
