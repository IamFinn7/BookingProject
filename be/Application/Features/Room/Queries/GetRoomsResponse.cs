namespace Application.Features.Room.Queries
{
    public class GetRoomsResponse
    {
        public string Id { get; set; }
        public string HotelId { get; set; }
        public string RoomType { get; set; }
        public double BasePricePerNight { get; set; }
        public int Quantity { get; set; }
        public int BedCount { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public List<string> Amenities { get; set; } = new();
        public List<string> Features { get; set; } = new();
        public List<RoomBookingDate> UnavailableDates { get; set; } = new();
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }

        public class RoomBookingDate
        {
            public long Date { get; set; }
            public int BookedCount { get; set; }
        }
    }
}
