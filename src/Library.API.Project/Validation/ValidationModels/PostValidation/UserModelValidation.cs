using FluentValidation;
using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Models.ViewModels;
using Library.API.Project.Validation.ErrorMessages;

namespace Library.API.Project.Validation.ValidationModels.PostValidation
{
    public class UserModelValidation : AbstractValidator<UserModel>
    {
        private readonly IUserRepository _userRepository;
        public UserModelValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.Name).NotEmpty().WithMessage(UserErrorMessages.EmptyName)
                .MaximumLength(100).WithMessage(UserErrorMessages.NameMaxLength)
                .MinimumLength(5).WithMessage(UserErrorMessages.NameMinLength);

            RuleFor(x => x.Password).NotEmpty().WithMessage(UserErrorMessages.EmptyPassword)
                .MaximumLength(100).WithMessage(UserErrorMessages.PasswordMaxLength)
                .MinimumLength(8).WithMessage(UserErrorMessages.PasswordMinLength);

            RuleFor(x => x.Email).NotEmpty().WithMessage(UserErrorMessages.EmptyEmail)
                .MaximumLength(100).WithMessage(UserErrorMessages.EmailMaxLength)
                .EmailAddress().WithMessage(UserErrorMessages.EmailMinLength)
                .Must(EqualEmailExistsVerification).WithMessage(UserErrorMessages.EmailExists);

        }
        private bool EqualEmailExistsVerification(string email) =>
            _userRepository.GetUserByEmail(email).Result == null;

    }
}
