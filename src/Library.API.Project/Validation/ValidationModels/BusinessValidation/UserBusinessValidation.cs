using FluentValidation;
using Library.Project.API.Interfaces.Repository;
using Library.Project.API.Models.Entities;
using Library.Project.API.Validation.ErrorMessages;

namespace Library.Project.API.Validation.ValidationModels.BusinessValidation
{
    public class UserBusinessValidation : AbstractValidator<UserEntity>
    {
        private readonly IUserRepository _userRepository;
        public UserBusinessValidation(IUserRepository userRepository, bool update)
        {
            _userRepository = userRepository;
            if (!update)
                RuleFor(x => x.Email).Must(EqualEmailExistsVerification).WithMessage(UserErrorMessages.EmailExists);


        }
        private bool EqualEmailExistsVerification(string email) =>
          _userRepository.GetUserByEmail(email).Result == null;
    }
}
