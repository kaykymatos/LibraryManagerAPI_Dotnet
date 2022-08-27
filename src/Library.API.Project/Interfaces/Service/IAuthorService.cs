using Library.API.Project.Models.Entities;
using Library.API.Project.Models.ViewModels;
using Library.API.Project.Project.Interfaces.Service;

namespace Library.API.Project.Interfaces.Service
{
    public interface IAuthorService : IBaseService<AuthorEntity, AuthorModel>
    {
    }
}
