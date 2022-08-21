using Library.API.Models;

namespace Library.API.Interfaces.Service
{
    public interface IBookService
    {
        BookEntityModel Post(BookEntityModel model);
        Task<IEnumerable<BookEntityModel>> GetAll();
        Task<BookEntityModel> GetById(int id);
    }
}
