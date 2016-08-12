using System.Reflection.Emit;

namespace WebClient.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using Services.EntityServices;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueField : ValidationAttribute
    {
        private const string REPOSITORYNAMESPACE = "Services.EntityServices";
        public string Service { get; set; }
        public string Field { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string access = REPOSITORYNAMESPACE + "." + this.Service;
            Assembly assembly = Assembly.Load("Services");
            Type repoType = assembly.GetType(access);
            var repo = Activator.CreateInstance(repoType);

            var results = (IEnumerable<object>)repo.GetType().GetMethods().Where(m => m.Name == "GetAll").FirstOrDefault().Invoke(repo, null);

            var field = validationContext.ObjectType.GetProperty("Id");
            var id = field.GetValue(validationContext.ObjectInstance);

            try
            {
                var res = results
                    .Where(v => v.GetType().GetProperty(this.Field).GetValue(v).ToString() == value.ToString() && v.GetType().GetProperty("Id").GetValue(v).ToString() != id.ToString())
                    .FirstOrDefault();
                if (res == null)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }
            catch (NullReferenceException)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }
        }
    }
}