using Library.Project.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Project.API.Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        public readonly LibraryAPIContext _context;
        public BaseRepository(LibraryAPIContext context)
        {
            _context = context;
        }

        public async virtual Task<TEntity> PostAsync(TEntity entity)
        {
            if (entity != null)
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            return null!;
        }
        public async virtual Task<IEnumerable<TEntity>> GetAllAsync() =>
            await _context.Set<TEntity>()!.ToListAsync();
        public async virtual Task<TEntity> GetEntityByIdAsync(int id)
        {
            var response = await _context.Set<TEntity>().FindAsync(id);
            if (response == null)
                return null!;

            return response;
        }
        public async virtual Task<TEntity> UpdateAsync(int id, TEntity entity)
        {
            var findEntity = await this.GetEntityByIdAsync(id);
            if (findEntity != null)
            {
                _context.Entry(findEntity).State = EntityState.Detached;
            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return findEntity!;
        }
        public async virtual Task<object> DeleteAsync(TEntity entity)
        {
            var deleteEntityModel = _context.Set<TEntity>()!.Remove(entity);
            if (deleteEntityModel.State != EntityState.Deleted)
                return $"Ocorreu um probema na Deleção do modelo escolhido";

            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
