using Library.API.Interfaces.Repository;
using Library.API.Interfaces.Service;
using Library.API.Models;

namespace Library.API.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public AuthorEntityModel Post(AuthorEntityModel model)
        {
            _repository.Post(model);
            return model;
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

    }
}
