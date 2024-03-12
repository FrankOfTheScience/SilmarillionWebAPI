using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MapService.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class PathToNode
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string PathId { get; set; }
        [BsonElement("originPointOfInterest")]
        public int OriginPointOfInterestNodeId { get; set; }
        [BsonElement("destinationPointOfInterest")]
        public int DestinationPointOfInterestNodeId { get; set; }
        [BsonElement("weight")]
        public int Weight { get; set; }
        [BsonElement("originPointOfInterestNode")]
        public virtual PointOfInterestNode OriginPointOfInterestNode { get; set; }
        [BsonElement("destinationPointOfInterestNode")]
        public virtual PointOfInterestNode DestinationPointOfInterestNode { get; set; }
        [BsonElement("euristic")]
        public double Euristic { get; set; }
    }
}