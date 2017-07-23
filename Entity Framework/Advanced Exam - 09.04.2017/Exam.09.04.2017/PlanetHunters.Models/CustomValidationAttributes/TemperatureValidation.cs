
namespace PlanetHunters.Models.CustomValidationAttributes
{
    using System.ComponentModel.DataAnnotations;
    public class TemperatureValidation
    {
        public static ValidationResult ValidateTemperature(int value, ValidationContext context)
        {
            bool isValid = true;

            if (value < 2400)
            {
                isValid = false;
            }

            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(
                    string.Format("The field {0} must be greater than or equal to 2400.", context.MemberName));
            }
        }
    }
}
