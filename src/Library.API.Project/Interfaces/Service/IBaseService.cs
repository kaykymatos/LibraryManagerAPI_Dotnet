namespace Library.API.Project.Project.Interfaces.Service
{
    public interface IBaseService<TEntity, TViewModel> where TEntity : class where TViewModel : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<TEntity> PostAsync(TViewModel entity);
        Task<TEntity> UpdateByIdAsync(int id, TViewModel entity);
        TEntity ConvertViewModelToModel(TViewModel model);
    }
}
