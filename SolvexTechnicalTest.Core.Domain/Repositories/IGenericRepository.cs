namespace SolvexTechnicalTest.Core.Domain.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<int> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
