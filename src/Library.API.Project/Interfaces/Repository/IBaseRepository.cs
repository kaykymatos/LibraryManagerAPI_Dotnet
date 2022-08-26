﻿namespace Library.API.Project.Project.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> PostAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entitie);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
