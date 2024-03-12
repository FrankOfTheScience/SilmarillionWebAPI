using MongoDB.Driver;

namespace MapService.Repository
{
    public abstract class RepositoryBase<T> : ICrudOperations<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;

        protected RepositoryBase(IMongoCollection<T> collection)
            => _collection = collection;

        public virtual async Task<IEnumerable<T>> GetAsync()
            => await _collection.Find(Builders<T>.Filter.Empty).ToListAsync();

        public virtual async Task<T> GetByIdAsync(string id, FilterDefinition<T> filter)
            => await _collection.Find(filter).FirstOrDefaultAsync();

        public virtual async Task<bool> PostAsync(T entity)
        {
            if (entity == null)
                return false;

            await _collection.InsertOneAsync(entity);
            return true;
        }

        public virtual async Task<bool> UpdateAsync(T entity, FilterDefinition<T> filter)
        {
            if (entity == null)
                return false;

            var updateResult = await _collection.ReplaceOneAsync(filter, entity);
            return updateResult.MatchedCount > 0;
        }

        public virtual async Task<bool> DeleteByIdAsync(string id, FilterDefinition<T> filter)
        {
            var deleteResult = await _collection.DeleteOneAsync(filter);
            return deleteResult.DeletedCount > 0;
        }
    }
}
