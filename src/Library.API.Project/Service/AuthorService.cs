using FluentValidation.Results;
using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models.DTO;
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
            var validation = new AuthorModelPostValidation().Validate(model);
            if (!validation.IsValid)
                return validation;

            var convertModelToEntity = ConvertViewModelToEntity(model);
            await _authorRepository.PostAsync(convertModelToEntity);
            return validation;
        }
        public async Task<IEnumerable<AuthorDTO>> GetAllAsync()
        {
            var response = await _authorRepository.GetAllAsync();
            List<AuthorDTO> listDTO = new();
            foreach (var item in response)
            {
                var convertModelToDTO = ConvertEntityToDTOModel(item);
                listDTO.Add(convertModelToDTO);
            }
            return listDTO;
        }
        public async Task<AuthorDTO> GetDtoByAsync(int id)
        {
            var response = await _authorRepository.GetByIdAsync(id);
            if (response == null)
                return null!;
            var convertEntityToDTO = ConvertEntityToDTOModel(response);

            return convertEntityToDTO;
        }
        public async Task<object> UpdateByIdAsync(int id, AuthorModel model)
        {
            var verification = await ValidationOnUpdateModel(id, model);
            if (verification.Any())
                return verification;

            var findAuthorEntity = await _authorRepository.GetByIdAsync(id);
            var converteModelToEntity = ConvertViewModelToEntity(model);
            converteModelToEntity.Id = id;
            converteModelToEntity.CreatedDate = findAuthorEntity.CreatedDate;

            var updateModel = await _authorRepository.UpdateAsync(id, converteModelToEntity);
            if (updateModel != null)
                return updateModel;

            return null!;
        }
        public async Task<object> DeleteByIdAsync(int id)
        {
            var errosOnDelete = await VerificationOnDeleteAuthorEntity(id);
            if (errosOnDelete.Count > 0)
                return errosOnDelete;

            var findAuthorEntity = await this.GetEntityById(id);
            var response = await _authorRepository.DeleteAsync(findAuthorEntity);
            return response;
        }
        public async Task<AuthorEntity> GetEntityById(int id)
        {
            var entity = await _authorRepository.GetByIdAsync(id);
            return entity;
        }
        public AuthorEntity ConvertViewModelToEntity(AuthorModel model)
        {
            if (model == null)
                return null!;
            AuthorEntity entity = new()
            {
                Name = model.Name.ToUpper().Trim(),
                BirthDate = DateTime.Parse(model.BirthDate.ToString("yyyy-MM-dd HH:mm:ss")),
                CreatedDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            return entity;
        }
        public AuthorDTO ConvertEntityToDTOModel(AuthorEntity entity)
        {
            var dtoModel = new AuthorDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                BirthDate = entity.BirthDate,
                CreatedDate = entity.CreatedDate
            };
            return dtoModel;
        }
        public async Task<List<string>> VerificationOnDeleteAuthorEntity(int id)
        {
            var modelExists = await VerificationIfModelExists(id);
            if (modelExists.Any())
                return modelExists;

            List<string> errorsVerificationOnDelete = new();

            var authorBooks = await _authorRepository.GetAllAuthorBooksByAuthorId(id);
            if (authorBooks.Any())
                errorsVerificationOnDelete.Add($"O Author com o id {id} tem livros vinculados!");
            return errorsVerificationOnDelete;
        }
        public async Task<List<string>> VerificationIfModelExists(int id)
        {
            List<string> errorsVerificationOnDelete = new();
            if (id <= 0)
                errorsVerificationOnDelete.Add("O ID deve ser maior que 0!");
            var entityModel = await _authorRepository.GetByIdAsync(id);
            if (entityModel == null)
                errorsVerificationOnDelete.Add($"O Autor não foi encontrado no banco de dados com o id: {id}!");
            return errorsVerificationOnDelete;
        }
        public async Task<List<string>> ValidationOnUpdateModel(int id, AuthorModel model)
        {
            var verificationIfExists = await VerificationIfModelExists(id);
            if (verificationIfExists.Any())
                return verificationIfExists;

            var validation = new AuthorModelPostValidation().Validate(model);
            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage).ToList();

            return new List<string>();
        }
    }
}
