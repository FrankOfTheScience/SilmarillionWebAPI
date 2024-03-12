using MapService.Models;

namespace MapService.Repository
{
    public interface IPathRepository
    {
        Task<bool> DeletePathByIdAsync(string id);

        Task<IEnumerable<PathToNode>> GetPathAsync();

        Task<PathToNode> GetPathByIdAsync(string id);

        Task<bool> PostPathAsync(PathToNode newPath);

        Task<bool> UpdatePathAsync(PathToNode updatedPath);
    }
}
