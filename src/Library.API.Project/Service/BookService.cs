using Library.API.Interfaces.Repository;
using Library.API.Interfaces.Service;
using Library.API.Models;
using Library.API.ViewModels;

namespace Library.API.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public BookEntityModel Post(BookModel model)
        {
            var modelConvert = ConvertViewModelToModel(model);
            _repository.Post(modelConvert);
            return modelConvert;
        }

        public async Task<IEnumerable<BookEntityModel>> GetAll()
        {
            var response = await _repository.GetAll();
            return response;
        }

        public BookEntityModel GetById(int id)
        {
            var response = _repository.GetById(id);
            return response;
        }



        public BookEntityModel UpdateById(int id, BookModel entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            if (id <= 0)
                return false;

            var model = this.GetById(id);
            if (model == null)
                return false;

            _repository.Delete(model);
            return true;
        }

        public BookEntityModel ConvertViewModelToModel(BookModel model)
        {
            BookEntityModel entityModel = new()
            {
                Title = model.Title,
                BookDescription = model.BookDescription,
                AuthorId = model.AuthorId,
                LaunchDate = model.LaunchDate,
                CreatedDate = DateTime.Now
            };
            return entityModel;
        }
    }
}
