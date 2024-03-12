using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MapService.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class PointOfInterestProperties
    {
        [BsonElement("population")]
        public int Population { get; set; }
        [BsonElement("characterIdsPresent")]
        public IEnumerable<int> CharacterIdsPresent { get; set; }
    }
}
