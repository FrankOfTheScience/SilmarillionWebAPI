using MapService.Models;

namespace MapService.UtilitiesModels
{
    public class PathNode
    {
        public PointOfInterestNode Node { get; set; }
        public float Cost { get; set; }
        public PathNode Previous { get; set; }

        public PathNode(PointOfInterestNode node, float cost)
        {
            Node = node;
            Cost = cost;
            Previous = null;
        }
    }
}
