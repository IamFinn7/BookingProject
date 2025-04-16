using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class RoomEntity : BaseEntity
    {
        [BsonElement("hotel_id")]
        public ObjectId HotelId { get; set; } // ref: Hotel.id

        [BsonElement("category_id")]
        public ObjectId CategoryId { get; set; } // ref: RoomCategory.id

        [BsonElement("room_number")]
        public string RoomNumber { get; set; }

        [BsonElement("bed_count")]
        public int BedCount { get; set; }

        [BsonElement("price_per_night")]
        public double PricePerNight { get; set; }

        [BsonElement("max_guests")]
        public int MaxGuests { get; set; }

        [BsonElement("status")]
        public RoomStatus Status { get; set; }

        [BsonElement("amenities")]
        public List<string> Amenities { get; set; } = new List<string>();

        [BsonElement("images")]
        public List<string> Images { get; set; } = new List<string>();
    }

    public enum RoomStatus
    {
        Available,
        Occupied,
        Maintenance,
    }
}
