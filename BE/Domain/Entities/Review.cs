using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Review
    {
        [BsonElement("user_id")]
        public ObjectId UserId { get; set; }

        [BsonElement("hotel_id")]
        public ObjectId HotelId { get; set; }

        [BsonElement("rating")]
        public double Rating { get; set; }

        [BsonElement("review_text")]
        public string ReviewText { get; set; }
    }
}
