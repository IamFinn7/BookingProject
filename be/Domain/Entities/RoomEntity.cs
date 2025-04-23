namespace Domain.Entities
{
    public class RoomEntity : BaseEntity
    {
        public string hotel_id { get; set; }
        public string room_type { get; set; }
        public double base_price_per_night { get; set; }
        public int quantity { get; set; }
        public int bed_count { get; set; }
        public int max_guest { get; set; }
        public List<string> images { get; set; } = new();
        public List<string> amenities { get; set; } = new();
        public List<string> features { get; set; } = new();
        public List<RoomBookingDate> unavailable_dates { get; set; } = new();

        public class RoomBookingDate
        {
            public long date { get; set; }
            public int booked_count { get; set; }
        }
    }
}
