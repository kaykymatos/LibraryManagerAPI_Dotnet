using FluentValidation;
using Library.API.Project.Models.ViewModels;
using Library.API.Project.Validation.ErrorMessages;

namespace Library.API.Project.Validation.ValidationModels.PostValidation
{
    public class AuthorModelPostValidation : AbstractValidator<AuthorModel>
    {
        public AuthorModelPostValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(AuthorErrorMessages.EmptyName)
                .MaximumLength(100).WithMessage(AuthorErrorMessages.MaxLengthName)
                .MinimumLength(3).WithMessage(AuthorErrorMessages.MinLengthName);

            RuleFor(x => x.BirthDate).NotEmpty().WithMessage(AuthorErrorMessages.EmptyBirthDate)
                .Must(IsDateTimeValue).WithMessage(AuthorErrorMessages.BirthDateLessThan18);

        }
        private bool IsDateTimeValue(DateTime date) => date <= DateTime.Today.AddYears(-18);

    }
}
