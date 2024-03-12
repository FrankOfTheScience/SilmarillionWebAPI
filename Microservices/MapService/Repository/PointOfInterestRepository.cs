using MapService.Models;
using MongoDB.Driver;

namespace MapService.Repository
{
    public class PointOfInterestRepository : RepositoryBase<PointOfInterestNode>, IPointOfInterestRepository
    {
        public PointOfInterestRepository(IMongoCollection<PointOfInterestNode> collection) : base(collection)
        { }
        public async Task<bool> DeletePointOfInterestByIdAsync(string id)
            => await this.DeleteByIdAsync(id, Builders<PointOfInterestNode>.Filter.Eq(poi => poi.PointOfInterestsId, id));

        public async Task<IEnumerable<PointOfInterestNode>> GetPointOfInterestAsync()
            => await this.GetAsync();

        public async Task<PointOfInterestNode> GetPointOfInterestByIdAsync(string id)
            => await this.GetByIdAsync(id, Builders<PointOfInterestNode>.Filter.Eq(poi => poi.PointOfInterestsId, id));

        public async Task<bool> PostPointOfInterestAsync(PointOfInterestNode newPointOfInterest)
            => await this.PostAsync(newPointOfInterest);

        public async Task<bool> UpdatePointOfInterestAsync(PointOfInterestNode updatedPointOfInterest)
            => await this.UpdateAsync(updatedPointOfInterest, Builders<PointOfInterestNode>.Filter.Eq(poi => poi.PointOfInterestsId, updatedPointOfInterest.PointOfInterestsId));
    }
}
