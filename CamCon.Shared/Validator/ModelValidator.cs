using System.ComponentModel.DataAnnotations;

namespace CamCon.Shared.Validator
{
    public class ModelValidator
    {
        public static List<ValidationResult> Validate<T>(T model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            System.ComponentModel.DataAnnotations.Validator.TryValidateObject(model, context, results, validateAllProperties: true);
            return results;
        }

        public static bool IsValid<T>(T model)
        {
            return !Validate(model).Any();
        }
    }
}
