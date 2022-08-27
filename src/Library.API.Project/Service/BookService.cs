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
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> PostAsync(BookModel model)
        {
            var validation = new BookModelValidation().Validate(model);
            if (!validation.IsValid)
                return validation;

            var modelConvert = ConvertViewModelToModel(model);
            await _repository.PostAsync(modelConvert);
            return validation;
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync()
        {
            var response = await _repository.GetAllAsync();
            return response;
        }

        public async Task<BookEntity> GetByIdAsync(int id)
        {
            var response = await _repository.GetByIdAsync(id);
            return response;
        }



        public async Task<BookEntity> UpdateByIdAsync(int id, BookModel entity)
        {
            if (id <= 0)
                return null!;
            var findModel = await _repository.GetByIdAsync(id);
            if (findModel == null)
                return null!;

            var convertedModel = this.ConvertViewModelToModel(entity);
            convertedModel.Id = id;
            var updateModel = await _repository.UpdateAsync(convertedModel);

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

            var deletedEntity = await _repository.DeleteAsync(model);
            return deletedEntity;
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
