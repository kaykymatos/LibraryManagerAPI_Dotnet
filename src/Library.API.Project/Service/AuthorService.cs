using Library.API.Interfaces.Repository;
using Library.API.Interfaces.Service;
using Library.API.Models;
using Library.API.ViewModels;

namespace Library.API.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public AuthorEntityModel Post(AuthorViewModel model)
        {
            var modelConvert = ViewModelToEntityModel(model);
            _repository.Post(modelConvert);
            return modelConvert;
        }

        public async Task<IEnumerable<AuthorEntityModel>> GetAll()
        {
            var response = await _repository.GetAll();
            return response;
        }

        public async Task<AuthorEntityModel> GetById(int id)
        {
            var response = await _repository.GetById(id);
            return response;
        }
        public AuthorEntityModel ViewModelToEntityModel(AuthorViewModel viewModel)
        {
            AuthorEntityModel model = new AuthorEntityModel
            {
                Name = viewModel.Name,
                BirthDate = viewModel.BirthDate,
                CreatedDate = DateTime.Now
            };
            return model;
        }

    }
}
