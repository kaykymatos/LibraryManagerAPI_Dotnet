using FluentValidation;
using Library.Project.API.Models.Entities;
using Library.Project.API.Validation.ErrorMessages;

namespace Library.Project.API.Validation.ValidationModels.EntityValidation
{
    public class BookValidation : AbstractValidator<BookEntity>
    {

        public BookValidation(bool update)
        {


            RuleFor(x => x.Title).NotEmpty().WithMessage(BookErrorMessages.EmptyTitle)
                .MinimumLength(5).WithMessage(BookErrorMessages.MinLengthTitle)
                .MaximumLength(20).WithMessage(BookErrorMessages.MaxLengthTitle);

            RuleFor(x => x.Description).NotEmpty().WithMessage(BookErrorMessages.EmptyDescription)
                .MaximumLength(150).WithMessage(BookErrorMessages.MaxLengthDescription)
                .MinimumLength(10).WithMessage(BookErrorMessages.MinLengthDescription);

            RuleFor(x => x.LaunchDate).NotEmpty().WithMessage(BookErrorMessages.EmptyLauchDate)
                .Must(IsLauchDateValid).WithMessage(BookErrorMessages.FutureLaunchDate);

            if (!update)
                RuleFor(x => x.AuthorId).NotEmpty().WithMessage(BookErrorMessages.EmptyAuthorId)
                    .GreaterThan(0).WithMessage(BookErrorMessages.AuthorIdLength);


        }
        private bool IsLauchDateValid(DateTime date) => date < DateTime.Now;
    }
}
