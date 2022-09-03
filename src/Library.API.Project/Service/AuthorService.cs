using AutoMapper;
using Library.Project.API.Interfaces.Repository;
using Library.Project.API.Interfaces.Service;
using Library.Project.API.Models.DTO.Get;
using Library.Project.API.Models.DTO.Post;
using Library.Project.API.Models.DTO.Put;
using Library.Project.API.Models.Entities;
using Library.Project.API.Validation.ValidationModels.BusinessValidation;
using Library.Project.API.Validation.ValidationModels.EntityValidation;

namespace Library.Project.API.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        public readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<AuthorDTOGet> GetDTOModelById(int id)
        {
            var dtoModel = await GetEntityById(id);
            if (dtoModel == null)
                return null!;
            return _mapper.Map<AuthorDTOGet>(dtoModel);
        }
        public async Task<AuthorEntity> GetEntityById(int id)
        {
            var entity = await _authorRepository.GetEntityByIdAsync(id);
            if (entity == null)
                return null!;
            return entity;
        }
        public async Task<IEnumerable<AuthorDTOGet>> GetAllAsync()
        {
            var response = await _authorRepository.GetAllAsync();
            List<AuthorDTOGet> listDTO = new();
            foreach (var item in response)
            {
                var convertModelToDTO = _mapper.Map<AuthorDTOGet>(item);
                listDTO.Add(convertModelToDTO);
            }
            return listDTO;
        }
        public async Task<object> PostAsync(AuthorDTOPost model)
        {
            List<string> validationErrors = new();
            var convertModelToEntity = _mapper.Map<AuthorEntity>(model);
            var validation = new AuthorValidation(false).Validate(convertModelToEntity);
            var businessValidation = new AuthorBusinessValidation(_authorRepository, false).Validate(convertModelToEntity);

            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage).ToList();

            if (!businessValidation.IsValid)
                return businessValidation.Errors.Select(x => x.ErrorMessage).ToList();

            convertModelToEntity.CreatedDate = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
            var postEntityModel = await _authorRepository.PostAsync(convertModelToEntity);
            return postEntityModel;
        }
        public async Task<object> UpdateByIdAsync(int id, AuthorDTOPut model)
        {
            var findAuthorEntity = await _authorRepository.GetEntityByIdAsync(id);
            var converteModelToEntity = _mapper.Map<AuthorEntity>(model);

            var verification = await ValidationOnUpdateModel(id, converteModelToEntity);

            if (verification.Any())
                return verification;

            var response = await _authorRepository.UpdateAsync(id, converteModelToEntity);
            return response;
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

        public async Task<List<string>> VerificationOnDeleteAuthorEntity(int id)
        {
            List<string> errorsVerificationOnDelete = new();
            var findBookEntity = await _authorRepository.GetEntityByIdAsync(id);
            if (findBookEntity == null)
                errorsVerificationOnDelete.Add("Autor não encontrado");

            var authorBooks = await _bookRepository.GetAllAuthorBooksByAuthorId(id);
            if (authorBooks.Any())
                errorsVerificationOnDelete.Add($"O Author com o id {id} tem livros vinculados!");
            return errorsVerificationOnDelete;
        }
        public async Task<List<string>> ValidationOnUpdateModel(int id, AuthorEntity model)
        {
            List<string> errors = new();
            var findAuthorEntity = await _authorRepository.GetEntityByIdAsync(id);
            if (findAuthorEntity == null)
            {
                errors.Add("Autor nao encontrado");
                return errors;
            }
            model.Id = id;
            model.Name = findAuthorEntity.Name;
            model.CreatedDate = findAuthorEntity.CreatedDate;

            var validation = new AuthorValidation(true).Validate(model);
            var businessValidation = new AuthorBusinessValidation(_authorRepository, true).Validate(model);
            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage).ToList();

            if (!businessValidation.IsValid)
                return businessValidation.Errors.Select(x => x.ErrorMessage).ToList();

            return new List<string>();
        }


    }
}
