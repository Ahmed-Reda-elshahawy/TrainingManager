using System.ComponentModel.DataAnnotations;
using TrainingManager.Data;

namespace TrainingManager.CustomValidators
{
    public class UniqueCourseNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var courseName = value as string;
            if (string.IsNullOrWhiteSpace(courseName))
                return ValidationResult.Success;
            var exists = context.Courses.Any(c => c.Name.ToLower() == courseName.ToLower());
            return exists ? new ValidationResult("course name is unique") : ValidationResult.Success;
        }
    }
}
