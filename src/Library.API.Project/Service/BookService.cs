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
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<BookDTOGet> GetDTOModelById(int id)
        {
            var dtoModel = await GetEntityById(id);
            if (dtoModel == null)
                return null!;
            return _mapper.Map<BookDTOGet>(dtoModel);
        }
        public async Task<BookEntity> GetEntityById(int id)
        {
            var entity = await _bookRepository.GetEntityByIdAsync(id);
            return entity;
        }
        public async Task<IEnumerable<BookDTOGet>> GetAllAsync()
        {
            var response = await _bookRepository.GetAllAsync();
            List<BookDTOGet> listDTO = new();
            foreach (var item in response)
            {
                var convertModelToDTO = _mapper.Map<BookDTOGet>(item);
                listDTO.Add(convertModelToDTO);
            }
            return listDTO;
        }
        public async Task<object> PostAsync(BookDTOPost model)
        {
            var convertModelToEntity = _mapper.Map<BookEntity>(model);
            var validation = new BookValidation(false).Validate(convertModelToEntity);
            var businessValidation = new BookBusinessValidation(_authorRepository).Validate(convertModelToEntity);
            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage).ToList();

            if (!businessValidation.IsValid)
                return businessValidation.Errors.Select(x => x.ErrorMessage).ToList();

            convertModelToEntity.CreatedDate = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
            var postEntityModel = await _bookRepository.PostAsync(convertModelToEntity);

            return postEntityModel;
        }
        public async Task<object> UpdateByIdAsync(int id, BookDTOPut model)
        {
            var convertModelToEntity = _mapper.Map<BookEntity>(model);

            var validationModel = await ValidationOnUpdateModel(id, convertModelToEntity);
            if (validationModel.Any())
                return validationModel;

            var response = await _bookRepository.UpdateAsync(id, convertModelToEntity);

            return response;
        }
        public async Task<object> DeleteByIdAsync(int id)
        {
            var findBookEntity = await GetEntityById(id);
            if (findBookEntity == null)
                return $"Livro não encontrado com o id: {id}"!;

            var response = await _bookRepository.DeleteAsync(findBookEntity);
            return response;
        }

        public async Task<List<string>> ValidationOnUpdateModel(int id, BookEntity model)
        {
            List<string> errors = new();
            var findBookEntity = await _bookRepository.GetEntityByIdAsync(id);
            if (findBookEntity == null)
            {
                errors.Add("Livro nao encontrado");
                return errors;
            }
            model.Id = id;
            model.CreatedDate = findBookEntity.CreatedDate;
            model.AuthorId = findBookEntity.AuthorId;

            var validation = new BookValidation(true).Validate(model);
            var businesValidation = new BookBusinessValidation(_authorRepository).Validate(model);

            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage).ToList();

            if (!businesValidation.IsValid)
                return businesValidation.Errors.Select(x => x.ErrorMessage).ToList();

            return new List<string>();
        }

    }
}
