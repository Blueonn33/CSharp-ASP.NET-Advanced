using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Services.Common.Utilities
{
    public class BasicModelValidator
    {
        private readonly IList<ValidationResult> validationResults;

        public BasicModelValidator()
        {
            validationResults = new List<ValidationResult>();
        }

        public IReadOnlyCollection<ValidationResult> ValidationResults
            => validationResults.AsReadOnly();

        public bool IsValid(object model)
        {
            var validationContext = new ValidationContext(model);

            return Validator.TryValidateObject(model, validationContext, validationResults, true);
        }

        public static bool IsValid(object model, List<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(model);

            return Validator.TryValidateObject(model, validationContext, validationResults, true);
        }
    }
}
