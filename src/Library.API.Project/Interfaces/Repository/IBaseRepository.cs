namespace Library.API.Project.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Post(T entity);
        Task<IEnumerable<T>> GetAll();
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
    }
}
