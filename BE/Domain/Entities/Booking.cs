using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Booking : BaseEntity
    {
        [BsonElement("user_id")]
        public ObjectId UserId { get; set; } // ref: User.id

        [BsonElement("hotel_id")]
        public ObjectId HotelId { get; set; } // ref: Hotel.id

        [BsonElement("room_id")]
        public ObjectId RoomId { get; set; } // ref: Room.id

        [BsonElement("check_in_date")]
        public DateTime CheckInDate { get; set; }

        [BsonElement("check_out_date")]
        public DateTime CheckOutDate { get; set; }

        [BsonElement("total_price")]
        public double TotalPrice { get; set; }

        [BsonElement("guest_list")]
        public List<Guest> GuestList { get; set; } = new List<Guest>(); // Tên, CMND/Hộ chiếu

        [BsonElement("coupon_code")]
        public string CouponCode { get; set; } // ref: Coupon.code

        [BsonElement("status")]
        public BookingStatus Status { get; set; } // pending, confirmed, cancelled
    }

    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed,
    }

    public class Guest : BaseEntity
    {
        [BsonElement("booking_id")]
        public ObjectId BookingId { get; set; } // ref: Booking.id

        [BsonElement("full_name")]
        public string FullName { get; set; }

        [BsonElement("id_card")]
        public string IdCard { get; set; } // CMND hoặc passport

        [BsonElement("nationality")]
        public string Nationality { get; set; }
    }
}
