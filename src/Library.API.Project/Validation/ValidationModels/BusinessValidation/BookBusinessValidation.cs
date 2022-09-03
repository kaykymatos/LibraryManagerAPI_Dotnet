using FluentValidation;
using Library.Project.API.Interfaces.Repository;
using Library.Project.API.Models.Entities;
using Library.Project.API.Validation.ErrorMessages;

namespace Library.Project.API.Validation.ValidationModels.BusinessValidation
{
    public class BookBusinessValidation : AbstractValidator<BookEntity>
    {
        private readonly IAuthorRepository _authorRepository;
        public BookBusinessValidation(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            RuleFor(x => x.AuthorId).Must(AuthorExists).WithMessage(BookErrorMessages.AuthorIdNotExists);
        }
        private bool AuthorExists(int id) => _authorRepository.GetEntityByIdAsync(id).Result != null;
    }
}
