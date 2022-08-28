using Library.API.Project.Models.Entities;
using Library.API.Project.Project.Interfaces.Repository;

namespace Library.API.Project.Interfaces.Repository
{
    public interface IAuthorRepository : IBaseRepository<AuthorEntity>
    {
        Task<IEnumerable<BookEntity>> GetAllAuthorBooksByAuthorId(int id);
    }
}
