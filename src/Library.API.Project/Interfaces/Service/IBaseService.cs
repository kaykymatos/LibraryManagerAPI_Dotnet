using FluentValidation.Results;

namespace Library.API.Project.Project.Interfaces.Service
{
    public interface IBaseService<TEntity, TViewModel, TModelDTO> where TEntity : class where TViewModel : class where TModelDTO : class
    {
        Task<IEnumerable<TModelDTO>> GetAllAsync();
        Task<TModelDTO> GetDtoByAsync(int id);
        Task<TEntity> GetEntityById(int id);
        Task<object> DeleteByIdAsync(int id);
        Task<ValidationResult> PostAsync(TViewModel entity);
        Task<object> UpdateByIdAsync(int id, TViewModel entity);
    }
}
