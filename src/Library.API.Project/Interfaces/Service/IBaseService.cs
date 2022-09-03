namespace Library.Project.API.Interfaces.Service
{
    public interface IBaseService<TEntity, TModelDTOUpdate, TModelDTOPost, TModelDTOGet>
        where TEntity : class
        where TModelDTOUpdate : class
        where TModelDTOPost : class
        where TModelDTOGet : class
    {
        Task<IEnumerable<TModelDTOGet>> GetAllAsync();
        Task<TEntity> GetEntityById(int id);
        Task<TModelDTOGet> GetDTOModelById(int id);
        Task<object> DeleteByIdAsync(int id);
        Task<object> PostAsync(TModelDTOPost model);
        Task<object> UpdateByIdAsync(int id, TModelDTOUpdate model);
    }
}
