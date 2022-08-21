using Library.API.Models;
using Library.API.Project.Interfaces.Service;
using Library.API.ViewModels;

namespace Library.API.Interfaces.Service
{
    public interface IAuthorService:IBaseService<AuthorEntityModel>
    {
        AuthorEntityModel Post(AuthorViewModel model);
    }
}
