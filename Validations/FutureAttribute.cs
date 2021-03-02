using System.ComponentModel.DataAnnotations;
using System;

namespace ExamOne.Validations
{
    public class FutureAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if((DateTime)value < DateTime.Now)
            {
                return new ValidationResult("Gathering must be in the future");
            }
            return ValidationResult.Success;
        }
    }
}