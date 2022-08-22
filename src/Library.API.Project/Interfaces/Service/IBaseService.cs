namespace Library.API.Project.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        T GetById(int id);
        bool DeleteById(int id);
    }
}
