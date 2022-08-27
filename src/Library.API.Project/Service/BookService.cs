using FluentValidation.Results;
using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models.Entities;
using Library.API.Project.Models.ViewModels;
using Library.API.Project.Validation.ValidationModels.PostValidation;

namespace Library.API.Project.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<ValidationResult> PostAsync(BookModel model)
        {
            var validation = new BookModelValidation(_authorRepository).Validate(model);
            if (!validation.IsValid)
                return validation;

            var modelConvert = ConvertViewModelToModel(model);
            await _bookRepository.PostAsync(modelConvert);
            return validation;
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync()
        {
            var response = await _bookRepository.GetAllAsync();
            return response;
        }

        public async Task<BookEntity> GetByIdAsync(int id)
        {
            var response = await _bookRepository.GetByIdAsync(id);
            return response;
        }



        public async Task<BookEntity> UpdateByIdAsync(int id, BookModel entity)
        {
            if (id <= 0)
                return null!;
            var findModel = await _bookRepository.GetByIdAsync(id);
            if (findModel == null)
                return null!;

            var convertedModel = this.ConvertViewModelToModel(entity);
            convertedModel.Id = id;
            var updateModel = await _bookRepository.UpdateAsync(id,convertedModel);

            if (updateModel != null)
                return updateModel;

            return null!;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            if (id <= 0)
                return false;

            var model = await this.GetByIdAsync(id);
            if (model == null)
                return false;

            var response = await _bookRepository.DeleteAsync(model);
            return response;
        }

        public BookEntity ConvertViewModelToModel(BookModel model)
        {

            BookEntity entityModel = new()
            {
                Title = model.Title.ToUpper().Trim(),
                BookDescription = model.BookDescription.ToUpper().Trim(),
                AuthorId = model.AuthorId,
                LaunchDate = DateTime.Parse(model.LaunchDate.ToString("yyyy-MM-dd HH:mm:ss")),
                CreatedDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            return entityModel;
        }
    }
}
