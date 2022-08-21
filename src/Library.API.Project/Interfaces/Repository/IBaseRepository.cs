using Library.API.Models;

namespace Library.API.Project.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Post(T model);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
