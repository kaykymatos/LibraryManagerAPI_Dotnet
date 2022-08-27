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
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<ValidationResult> PostAsync(AuthorModel model)
        {
            var validation = new AuthorModelValidation().Validate(model);
            if (!validation.IsValid)
                return validation;

            var modelConvert = ConvertViewModelToModel(model);
            await _authorRepository.PostAsync(modelConvert);
            return validation;
        }

        public async Task<IEnumerable<AuthorEntity>> GetAllAsync()
        {
            var response = await _authorRepository.GetAllAsync();
            return response;
        }

        public async Task<AuthorEntity> GetByIdAsync(int id)
        {
            var response = await _authorRepository.GetByIdAsync(id);
            return response;
        }


        public async Task<AuthorEntity> UpdateByIdAsync(int id, AuthorModel entity)
        {
            var findAuthor = await _authorRepository.GetByIdAsync(id);
            if (findAuthor == null)
                return null!;

            var convertedModel = this.ConvertViewModelToModel(entity);
            convertedModel.Id = id;
            var updateModel = await _authorRepository.UpdateAsync(id,convertedModel);

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

           bool response = await _authorRepository.DeleteAsync(model);
            return response;
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
