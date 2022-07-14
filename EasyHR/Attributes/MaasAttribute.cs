using System.ComponentModel.DataAnnotations;

namespace EasyHR.Attributes
{
    public class MaasAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if ((decimal)value < 4250m)
            {
                return new ValidationResult("Maaş asgari ücretten düşük olamaz.");
            }

            if ((decimal)value > 100000m)
            {
                return new ValidationResult("Maaş 100.000₺ ve daha fazla olamaz.");
            }

            return ValidationResult.Success;
        }
    }
}
