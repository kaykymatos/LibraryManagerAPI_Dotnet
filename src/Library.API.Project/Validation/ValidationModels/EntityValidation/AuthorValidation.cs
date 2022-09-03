using FluentValidation;
using Library.Project.API.Models.Entities;
using Library.Project.API.Validation.ErrorMessages;

namespace Library.Project.API.Validation.ValidationModels.EntityValidation
{
    public class AuthorValidation : AbstractValidator<AuthorEntity>
    {
        public AuthorValidation(bool update)
        {
            if (!update)
                RuleFor(x => x.Name).NotEmpty().WithMessage(AuthorErrorMessages.EmptyName)
                    .MaximumLength(100).WithMessage(AuthorErrorMessages.MaxLengthName)
                    .MinimumLength(3).WithMessage(AuthorErrorMessages.MinLengthName);

            RuleFor(x => x.BirthDate).NotEmpty().WithMessage(AuthorErrorMessages.EmptyBirthDate)
                .Must(IsDateTimeValid).WithMessage(AuthorErrorMessages.BirthDateLessThan18);

        }
        private bool IsDateTimeValid(DateTime date) => date <= DateTime.Today.AddYears(-18);

    }
}
