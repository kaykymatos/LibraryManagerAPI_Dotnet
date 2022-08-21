using Library.API.Models;

namespace Library.API.Interfaces.Service
{
    public interface IAuthorService
    {
        AuthorEntityModel Post(AuthorEntityModel model);
        Task<IEnumerable<AuthorEntityModel>> GetAll();
        Task<AuthorEntityModel> GetById(int id);
    }
}
