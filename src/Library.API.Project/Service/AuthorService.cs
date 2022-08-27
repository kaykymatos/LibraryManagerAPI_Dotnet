using FluentValidation.Results;
using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models.Entities;
using Library.API.Project.Models.ViewModels;
using Library.API.Project.Validation.ValidationModels.PostValidation;

namespace Library.API.Project.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ValidationResult> PostAsync(AuthorModel model)
        {
            var validation = new AuthorModelValidation().Validate(model);
            if (!validation.IsValid)
                return validation;

            var modelConvert = ConvertViewModelToModel(model);
            await _repository.PostAsync(modelConvert);
            return validation;
        }

        public async Task<IEnumerable<AuthorEntity>> GetAllAsync()
        {
            var response = await _repository.GetAllAsync();
            return response;
        }

        public async Task<AuthorEntity> GetByIdAsync(int id)
        {
            var response = await _repository.GetByIdAsync(id);
            return response;
        }


        public async Task<AuthorEntity> UpdateByIdAsync(int id, AuthorModel entity)
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


        public AuthorEntity ConvertViewModelToModel(AuthorModel model)
        {
            AuthorEntity entityModel = new()
            {
                Name = model.Name.ToUpper().Trim(),
                BirthDate = DateTime.Parse(model.BirthDate.ToString("yyyy-MM-dd HH:mm:ss")),
                CreatedDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            return entityModel;
        }
    }
}
