using Library.API.Project.Models.Entities;

namespace Library.API.Project.Interfaces.Repository
{
    public interface IBookRepository : IBaseRepository<BookEntity>
    {
        Task<IEnumerable<BookEntity>> GetAllAuthorBooksByAuthorId(int id);
    }
}
