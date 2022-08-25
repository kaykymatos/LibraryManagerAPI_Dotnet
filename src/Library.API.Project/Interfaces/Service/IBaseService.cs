namespace Library.API.Project.Interfaces.Service
{
    public interface IBaseService<TEntity, TViewModel> where TEntity : class where TViewModel : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        TEntity GetById(int id);
        bool DeleteById(int id);
        TEntity ConvertViewModelToModel(TViewModel model);
    }
}
