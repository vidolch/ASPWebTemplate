namespace WebClient.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ConfirmField : ValidationAttribute
    {
        public string FieldToConfirm { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var field = validationContext.ObjectType.GetProperty(this.FieldToConfirm);
            var values = field.GetValue(validationContext.ObjectInstance);

            if (values.ToString() != value.ToString())
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}