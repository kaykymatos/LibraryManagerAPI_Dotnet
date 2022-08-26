using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models;
using Library.API.Project.Project.ViewModels;

namespace Library.API.Project.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthorEntityModel> PostAsync(AuthorModel model)
        {
            var modelConvert = ConvertViewModelToModel(model);
            await _repository.PostAsync(modelConvert);
            return modelConvert;
        }

        public async Task<IEnumerable<AuthorEntityModel>> GetAllAsync()
        {
            var response = await _repository.GetAllAsync();
            return response;
        }

        public async Task<AuthorEntityModel> GetByIdAsync(int id)
        {
            var response = await _repository.GetByIdAsync(id);
            return response;
        }


        public async Task<AuthorEntityModel> UpdateByIdAsync(int id, AuthorModel entity)
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

            await _repository.DeleteAsync(model);
            return true;
        }


        public AuthorEntityModel ConvertViewModelToModel(AuthorModel model)
        {
            AuthorEntityModel entityModel = new()
            {
                Name = model.Name,
                BirthDate = model.BirthDate,
                CreatedDate = DateTime.Now
            };
            return entityModel;
        }
    }
}
