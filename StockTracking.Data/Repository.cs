﻿using Microsoft.EntityFrameworkCore;
using StockTracking.Models;
using System.Linq.Expressions;

namespace StockTracking.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly StockTrackingContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(StockTrackingContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return  _dbSet.AsQueryable();
        }

        public IQueryable<T> GetAllById(int id)
        {
            return _dbSet.AsQueryable();
        }
    }
}
