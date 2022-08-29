using Library.API.Project.Models.Entities;
using Library.API.Project.Project.Interfaces.Repository;

namespace Library.API.Project.Interfaces.Repository
{
    public interface IBookRepository : IBaseRepository<BookEntity>
    {
        Task<IEnumerable<BookEntity>> GetAllAuthorBooksByAuthorId(int id);
    }
}
