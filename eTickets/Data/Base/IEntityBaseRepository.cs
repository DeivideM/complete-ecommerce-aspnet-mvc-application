using eTickets.Models;

namespace eTickets.Data.Base;

public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    Task AddAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task UpdateAsync(int id, T entity);
    Task DeleteAsync(int id);
}
