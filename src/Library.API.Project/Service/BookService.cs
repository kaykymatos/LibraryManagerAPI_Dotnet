using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models;
using Library.API.Project.Project.ViewModels;

namespace Library.API.Project.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookEntityModel> PostAsync(BookModel model)
        {
            var modelConvert = ConvertViewModelToModel(model);
            await _repository.PostAsync(modelConvert);
            return modelConvert;
        }

        public async Task<IEnumerable<BookEntityModel>> GetAllAsync()
        {
            var response = await _repository.GetAllAsync();
            return response;
        }

        public async Task<BookEntityModel> GetByIdAsync(int id)
        {
            var response = await _repository.GetByIdAsync(id);
            return response;
        }



        public async Task<BookEntityModel> UpdateByIdAsync(int id, BookModel entity)
        {
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

        public BookEntityModel ConvertViewModelToModel(BookModel model)
        {
            BookEntityModel entityModel = new()
            {
                Title = model.Title,
                BookDescription = model.BookDescription,
                AuthorId = model.AuthorId,
                LaunchDate = model.LaunchDate,
                CreatedDate = DateTime.Now
            };
            return entityModel;
        }
    }
}
