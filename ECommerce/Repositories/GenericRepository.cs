﻿using ECommerce.Helpers;
using ECommerce.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext _dbContext;

        public GenericRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }


        public virtual async Task<T> GetByIdAsync(int id)
        {
            var keyValues = new object[] { id };
            return await _dbContext.Set<T>().FindAsync(keyValues);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task AddRangeAsync(List<T> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateRangeAsync(List<T> entities)
        {
            _dbContext.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        //public async Task<T> PatchAsync(int id, JsonPatchDocument<T> patchDocument)
        //{
        //    var t = await GetByIdAsync(id);
        //    patchDocument.ApplyTo(t);
        //    await _dbContext.SaveChangesAsync();
        //    return t;
        //}

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}