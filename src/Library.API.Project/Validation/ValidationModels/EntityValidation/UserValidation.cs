using FluentValidation;
using Library.Project.API.Models.Entities;
using Library.Project.API.Validation.ErrorMessages;

namespace Library.Project.API.Validation.ValidationModels.EntityValidation
{
    public class UserValidation : AbstractValidator<UserEntity>
    {
        public UserValidation(bool update)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(UserErrorMessages.EmptyName)
                .MaximumLength(100).WithMessage(UserErrorMessages.NameMaxLength)
                .MinimumLength(5).WithMessage(UserErrorMessages.NameMinLength);

            RuleFor(x => x.Password).NotEmpty().WithMessage(UserErrorMessages.EmptyPassword)
                .MaximumLength(100).WithMessage(UserErrorMessages.PasswordMaxLength)
                .MinimumLength(8).WithMessage(UserErrorMessages.PasswordMinLength);

            if (!update)
                RuleFor(x => x.Email).NotEmpty().WithMessage(UserErrorMessages.EmptyEmail)
                .MaximumLength(100).WithMessage(UserErrorMessages.EmailMaxLength)
                .EmailAddress().WithMessage(UserErrorMessages.EmailMinLength);

            RuleFor(x => x.BirthDate).NotEmpty().WithMessage(UserErrorMessages.EmptyBirthDate)
                .Must(IsDateTimeValid).WithMessage(UserErrorMessages.BirthDateLessThan18);
        }
        private bool IsDateTimeValid(DateTime date) => date <= DateTime.Today.AddYears(-18);

    }
}
