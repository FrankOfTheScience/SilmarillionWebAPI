using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MapService.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class PointOfInterestNode
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string PointOfInterestsId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("coordinates")]
        public IEnumerable<double> Coordinates { get; set; }
        [BsonElement("properties")]
        public virtual PointOfInterestProperties Properties { get; set; }
        [BsonElement("paths")]
        public virtual IEnumerable<PathToNode> Paths { get; set; }
        [BsonElement("weight")]
        public int Weight { get; set; }

    }
}
