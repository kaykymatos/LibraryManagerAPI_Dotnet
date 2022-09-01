namespace Library.API.Project.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> PostAsync(TEntity entity);
        Task<TEntity> UpdateAsync(int id, TEntity entitie);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<object> DeleteAsync(TEntity entity);
    }
}
