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

        public BookEntityModel Post(BookViewModel model)
        {
            var modelConvert = ViewModelToEntityModel(model);
            _repository.Post(modelConvert);
            return modelConvert;
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
        public BookEntityModel ViewModelToEntityModel(BookViewModel viewModel)
        {
            BookEntityModel model = new BookEntityModel
            {
                Title = viewModel.Title,    
                BookDescription = viewModel.BookDescription,    
                AuthorId = viewModel.AuthorId,  
                LaunchDate = viewModel.LaunchDate,  
                CreatedDate = DateTime.Now
            };
            return model;
        }
    }
}
