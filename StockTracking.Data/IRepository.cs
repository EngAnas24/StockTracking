using StockTracking.Models;
using System.Linq.Expressions;

namespace StockTracking.Data
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id,T entity);
        Task DeleteAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllById(int id);


    }
}
