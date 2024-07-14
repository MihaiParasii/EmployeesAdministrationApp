using System.ComponentModel.DataAnnotations;

namespace TestProjectRazorModels;

public class DateValidatorAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        value = (DateOnly)value;

        if (new DateOnly(1900, 1, 1).CompareTo(value) <= 0 && DateOnly.FromDateTime(DateTime.Now).CompareTo(value) >= 0)
        {
            return ValidationResult.Success!;
        }

        return new ValidationResult("Date must be between 1900 and current date!");
    }
}
