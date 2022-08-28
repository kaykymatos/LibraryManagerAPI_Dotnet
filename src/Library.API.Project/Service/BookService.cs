using FluentValidation.Results;
using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models.DTO;
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
            var validation = new BookModelPostValidation(_authorRepository).Validate(model);
            if (!validation.IsValid)
                return validation;

            var convertModelToEntity = ConvertViewModelToEntity(model);
            await _bookRepository.PostAsync(convertModelToEntity);
            return validation;
        }
        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            var response = await _bookRepository.GetAllAsync();
            List<BookDTO> listDTO = new();
            foreach (var item in response)
            {
                var convertModelToDTO = ConvertEntityToDTOModel(item);
                listDTO.Add(convertModelToDTO);
            }
            return listDTO;
        }
        public async Task<BookDTO> GetDtoByAsync(int id)
        {
            var response = await _bookRepository.GetByIdAsync(id);
            if (response == null)
                return null!;
            var convertEntityToDTO = ConvertEntityToDTOModel(response);
            return convertEntityToDTO;
        }
        public async Task<BookEntity> UpdateByIdAsync(int id, BookModel model)
        {
            if (id <= 0)
                return null!;
            var findBookEntity = await _bookRepository.GetByIdAsync(id);
            if (findBookEntity == null)
                return null!;

            var convertModelToEntity = ConvertViewModelToEntity(model);
            convertModelToEntity.Id = id;
            convertModelToEntity.CreatedDate = findBookEntity.CreatedDate;
            var updateModel = await _bookRepository.UpdateAsync(id, convertModelToEntity);

            if (updateModel != null)
                return updateModel;

            return null!;
        }
        public async Task<object> DeleteByIdAsync(int id)
        {
            var errosOnDelete = await VerificationOnDeleteAuthorEntity(id);
            if (errosOnDelete.Count > 0)
                return errosOnDelete;

            var findBookEntity = await this.GetEntityById(id);

            var response = await _bookRepository.DeleteAsync(findBookEntity);
            return response;
        }
        public async Task<BookEntity> GetEntityById(int id)
        {
            var entity = await _bookRepository.GetByIdAsync(id);
            return entity;
        }
        public BookEntity ConvertViewModelToEntity(BookModel model)
        {

            BookEntity entity = new()
            {
                Title = model.Title.ToUpper().Trim(),
                Description = model.Description.ToUpper().Trim(),
                AuthorId = model.AuthorId,
                LaunchDate = DateTime.Parse(model.LaunchDate.ToString("yyyy-MM-dd HH:mm:ss")),
                CreatedDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            return entity;
        }
        public BookDTO ConvertEntityToDTOModel(BookEntity entity)
        {
            var dtoModel = new BookDTO()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                AuthorId = entity.AuthorId,
                LaunchDate = entity.LaunchDate,
                CreatedDate = entity.CreatedDate
            };
            return dtoModel;
        }
        public async Task<List<string>> VerificationOnDeleteAuthorEntity(int id)
        {
            List<string> errorsVerificationOnDelete = new();
            if (id <= 0)
                errorsVerificationOnDelete.Add("O ID deve ser maior que 0");
            var entityModel = await _authorRepository.GetByIdAsync(id);
            if (entityModel == null)
                errorsVerificationOnDelete.Add($"O Livro não foi encontrado no banco de dados com o id: {id}");
            return errorsVerificationOnDelete;
        }
    }
}
