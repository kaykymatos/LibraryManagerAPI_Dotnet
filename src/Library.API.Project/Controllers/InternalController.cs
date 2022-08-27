using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Project.Controllers
{
    public class InternalController : ControllerBase
    {
        internal static List<string> ShowErrors(ValidationResult errors)
        {
            List<string> result = new();
            if (errors.Errors.Any())
            {
                foreach (var error in errors.Errors.ToList())
                    result.Add($"{error.PropertyName}:{error.ErrorMessage}");
            }

            return result;
        }
        internal static bool IsValidationValid(ValidationResult validation)
        {
            if (validation.IsValid)
                return true;
            return false;
        }
        internal static bool IsResponseNull(object model)
        {
            if (model == null)
                return false;

            return true;
        }
    }
}
