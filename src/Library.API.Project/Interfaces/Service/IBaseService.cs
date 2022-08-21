using Library.API.Models;
using Library.API.ViewModels;

namespace Library.API.Project.Interfaces.Service
{
    public interface IBaseService<T>where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
