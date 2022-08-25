using Library.API.Models;
using Library.API.Project.Interfaces.Service;
using Library.API.ViewModels;

namespace Library.API.Interfaces.Service
{
    public interface IAuthorService : IBaseService<AuthorEntityModel, AuthorModel>
    {
        AuthorEntityModel Post(AuthorModel entity);
        AuthorEntityModel UpdateById(int id, AuthorModel entity);
    }
}
