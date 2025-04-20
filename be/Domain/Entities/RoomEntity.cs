namespace Domain.Entities
{
    public class RoomEntity : BaseEntity
    {
        public string hotel_id { get; set; }

        public string category_id { get; set; }

        public string room_number { get; set; }

        public int bed_count { get; set; }

        public double price_per_night { get; set; }

        public int max_guest { get; set; }

        public RoomStatus status { get; set; }

        public List<string> amenities { get; set; } = new List<string>();

        public List<string> images { get; set; } = new List<string>();
    }

    public enum RoomStatus
    {
        Available,
        Occupied,
        Maintenance,
    }
}
