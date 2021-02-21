using System;
using System.ComponentModel.DataAnnotations;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExpirationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime targetDateTime = (DateTime)value;

            if (currentDateTime > targetDateTime)
            {
                return new ValidationResult("Card is expired!");
            }

            return ValidationResult.Success;
        }
    }
}
