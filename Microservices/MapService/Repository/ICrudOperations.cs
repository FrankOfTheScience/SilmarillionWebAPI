using MongoDB.Driver;

namespace MapService.Repository
{
    public interface ICrudOperations<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(string id, FilterDefinition<T> filter);
        Task<bool> PostAsync(T entity);
        Task<bool> UpdateAsync(T entity, FilterDefinition<T> filter);
        Task<bool> DeleteByIdAsync(string id, FilterDefinition<T> filter);
    }
}
