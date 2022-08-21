using Library.API.Interfaces.Repository;
using Library.API.Interfaces.Service;
using Library.API.Models;

namespace Library.API.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public BookEntityModel Post(BookEntityModel model)
        {
            _repository.Post(model);
            return model;
        }

        public async Task<IEnumerable<BookEntityModel>> GetAll()
        {
            var response = await _repository.GetAll();
            return response;
        }

        public async Task<BookEntityModel> GetById(int id)
        {
            var response = await _repository.GetById(id);
            return response;
        }

    }
}
