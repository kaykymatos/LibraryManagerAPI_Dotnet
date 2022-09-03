using Library.Project.API.Models.Entities;

namespace Library.Project.API.Interfaces.Repository
{
    public interface IBookRepository : IBaseRepository<BookEntity>
    {
        Task<IEnumerable<BookEntity>> GetAllAuthorBooksByAuthorId(int id);
    }
}
