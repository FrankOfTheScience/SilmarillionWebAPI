using MapService.Models;
using MongoDB.Driver;

namespace MapService.Repository
{
    public class PathRepository : RepositoryBase<PathToNode>, IPathRepository
    {
        public PathRepository(IMongoCollection<PathToNode> collection) : base(collection)
        { }
        public async Task<bool> DeletePathByIdAsync(string id)
           => await this.DeleteByIdAsync(id, Builders<PathToNode>.Filter.Eq(p => p.PathId, id));

        public async Task<IEnumerable<PathToNode>> GetPathAsync()
            => await this.GetAsync();

        public async Task<PathToNode> GetPathByIdAsync(string id)
            => await this.GetByIdAsync(id, Builders<PathToNode>.Filter.Eq(p => p.PathId, id));

        public async Task<bool> PostPathAsync(PathToNode newPath)
            => await this.PostAsync(newPath);

        public async Task<bool> UpdatePathAsync(PathToNode updatedPath)
            => await this.UpdateAsync(updatedPath, Builders<PathToNode>.Filter.Eq(p => p.PathId, updatedPath.PathId));
    }
}
