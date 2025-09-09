using System.ComponentModel.DataAnnotations;

namespace TrainingManager.BLL.CustomValidators
{
    public class ClearFromDegetsAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string str && str.Any(char.IsDigit))
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
