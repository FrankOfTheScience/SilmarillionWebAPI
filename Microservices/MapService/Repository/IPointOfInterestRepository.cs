using MapService.Models;

namespace MapService.Repository
{
    public interface IPointOfInterestRepository
    {
        Task<bool> DeletePointOfInterestByIdAsync(string id);
        Task<IEnumerable<PointOfInterestNode>> GetPointOfInterestAsync();

        Task<PointOfInterestNode> GetPointOfInterestByIdAsync(string id);

        Task<bool> PostPointOfInterestAsync(PointOfInterestNode newPointOfInterest);

        Task<bool> UpdatePointOfInterestAsync(PointOfInterestNode updatedPointOfInterest);
    }
}
