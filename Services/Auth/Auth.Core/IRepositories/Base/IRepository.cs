
namespace Auth.Core.IRepositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T?>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
