using Library.API.Models;

namespace Library.API.Interfaces.Repository
{
    public interface IAuthorRepository
    {
        void Post(AuthorEntityModel model);
        Task<IEnumerable<AuthorEntityModel>> GetAll();
        Task<AuthorEntityModel> GetById(int id);
    }
}
