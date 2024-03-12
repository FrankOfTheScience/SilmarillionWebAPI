using MapService.Models;
using MapService.UtilitiesModels;
using MongoDB.Driver;

namespace MapService
{
    public static class Utilities
    {
        public static MongoClient InitializeMongoClient(IConfiguration configurations)
        {
            var connectionString = string.Format(configurations.GetConnectionString("SilmarillionMapDb"), Environment.GetEnvironmentVariable("DB_HOST"), Environment.GetEnvironmentVariable("DB_NAME"));

            return new MongoClient(MongoUrl.Create(connectionString));
        }

        public static IMongoDatabase InitializeMongoDatabase(MongoClient client)
            => client.GetDatabase(Environment.GetEnvironmentVariable("DB_NAME"));

        public static IEnumerable<PointOfInterestNode> ReconstructPath(PathNode endNode)
        {
            var path = new List<PointOfInterestNode>();
            var currentNode = endNode;

            while (currentNode != null)
            {
                path.Add(currentNode.Node);
                currentNode = currentNode.Previous;
            }

            path.Reverse();
            return path;
        }

        public static float CalculateEuclideanDistance(double[] source, double[] destination)
        {
            var dx = source[0] - destination[0];
            var dy = source[1] - destination[1];

            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public static IEnumerable<PointOfInterestNode> AStarAlgorithm(PointOfInterestNode startPoint, PointOfInterestNode destinationPoint)
        {
            var closedSet = new HashSet<string>();
            var openSet = new PriorityQueue<PathNode, float>();

            openSet.Enqueue(new PathNode(startPoint, 0), 0);

            while (openSet.Count > 0)
            {
                var currentNode = openSet.Dequeue();
                if (currentNode.Node.PointOfInterestsId == destinationPoint.PointOfInterestsId)
                    return ReconstructPath(currentNode);

                closedSet.Add(currentNode.Node.PointOfInterestsId);

                foreach (var neighbor in currentNode.Node.Paths)
                {
                    var totalDistance = currentNode.Cost + neighbor.Weight;
                    var heuristic = CalculateEuclideanDistance(neighbor.DestinationPointOfInterestNode.Coordinates.ToArray(), destinationPoint.Coordinates.ToArray());
                    var priority = totalDistance + heuristic;

                    if (!closedSet.Contains(neighbor.DestinationPointOfInterestNode.PointOfInterestsId))
                        openSet.Enqueue(new PathNode(neighbor.DestinationPointOfInterestNode, totalDistance), priority);
                }
            }
            return new List<PointOfInterestNode>();
        }
    }
}
