﻿using Library.API.Project.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Project.Repository
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

        public async virtual Task<TEntity> GetByIdAsync(int id)
        {
            var response = await _context.Set<TEntity>()!.FindAsync(id);
            if (response == null)
                return null!;

            return response;
        }

        public async virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updateModel = _context.Update(entity).State = EntityState.Modified;
            if (updateModel != EntityState.Modified)
                return null!;

            await _context.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<bool> DeleteAsync(TEntity entity)
        {
            var deleteEntityModel = _context.Set<TEntity>()!.Remove(entity);
            if (deleteEntityModel.State != EntityState.Deleted)
                return false;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}