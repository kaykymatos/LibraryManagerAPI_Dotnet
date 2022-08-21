using Library.API.Models;

namespace Library.API.Interfaces.Repository
{
    public interface IBookRepository
    {
        void Post(BookEntityModel model);
        Task<IEnumerable<BookEntityModel>> GetAll();
        Task<BookEntityModel> GetById(int id);
    }
}
