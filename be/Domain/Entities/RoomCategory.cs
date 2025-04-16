using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class RoomCategory : BaseEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
    }
}
