using FluentValidation;
using Library.API.Project.Data;
using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models.Entities;
using Library.API.Project.Models.ViewModels;
using Library.API.Project.Validation.ErrorMessages;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Project.Validation.ValidationModels.PostValidation
{
    public class BookModelValidation : AbstractValidator<BookModel>
    {
        private readonly IAuthorRepository _authorRepository;
        public BookModelValidation(IAuthorRepository  bookRepository)
        {
            _authorRepository = bookRepository;

            RuleFor(x => x.Title).NotEmpty().WithMessage(BookErrorMessages.EmptyTitle)
                .MinimumLength(5).WithMessage(BookErrorMessages.MinLengthTitle)
                .MaximumLength(20).WithMessage(BookErrorMessages.MaxLengthTitle);

            RuleFor(x => x.BookDescription).NotEmpty().WithMessage(BookErrorMessages.EmptyDescription)
                .MaximumLength(200).WithMessage(BookErrorMessages.MaxLengthDescription)
                .MinimumLength(10).WithMessage(BookErrorMessages.MinLengthDescription);

            RuleFor(x => x.LaunchDate).NotEmpty().WithMessage(BookErrorMessages.EmptyLauchDate)
                .Must(IsLauchDateValid).WithMessage(BookErrorMessages.FutureLaunchDate);

            RuleFor(x => x.AuthorId).NotEmpty().WithMessage(BookErrorMessages.EmptyAuthorId)
                .GreaterThan(0).WithMessage(BookErrorMessages.AuthorIdLength)
                .Must(AuthorExists).WithMessage(BookErrorMessages.AuthorIdNotExists);

        }
        private bool IsLauchDateValid(DateTime date) => date < DateTime.Now;
        private bool AuthorExists(int id) => _authorRepository.GetByIdAsync(id).Result != null;
    }
}
