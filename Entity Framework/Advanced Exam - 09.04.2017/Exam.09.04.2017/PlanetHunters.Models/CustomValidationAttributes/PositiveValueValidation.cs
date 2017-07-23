using System.ComponentModel.DataAnnotations;

namespace PlanetHunters.Models.CustomValidationAttributes
{
    public class PositiveValueValidation
    {
        public static ValidationResult ValidateGreaterThanZero(decimal? value, ValidationContext context)
        {
            bool isValid = true;

            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value <= 0m)
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
                    string.Format("The field {0} must be greater than or equal to 0.", context.MemberName));
            }
        }
    }
}
