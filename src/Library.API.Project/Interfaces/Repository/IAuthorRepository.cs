using Library.Project.API.Models.Entities;

namespace Library.Project.API.Interfaces.Repository
{
    public interface IAuthorRepository : IBaseRepository<AuthorEntity>
    {
        Task<AuthorEntity> GetAuthorByName(string name);
    }
}
