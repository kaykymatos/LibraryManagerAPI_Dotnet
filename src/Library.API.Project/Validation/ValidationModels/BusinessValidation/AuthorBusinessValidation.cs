using FluentValidation;
using Library.Project.API.Interfaces.Repository;
using Library.Project.API.Models.Entities;
using Library.Project.API.Validation.ErrorMessages;

namespace Library.Project.API.Validation.ValidationModels.BusinessValidation
{
    public class AuthorBusinessValidation : AbstractValidator<AuthorEntity>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorBusinessValidation(IAuthorRepository authorRepository, bool update)
        {
            _authorRepository = authorRepository;
            if (!update)
                RuleFor(x => x.Name).Must(AuthorNameExists).WithMessage(AuthorErrorMessages.AuthorNameHasBeRegistred);
        }
        private bool AuthorNameExists(string name) => _authorRepository.GetAuthorByName(name).Result == null;
    }
}
