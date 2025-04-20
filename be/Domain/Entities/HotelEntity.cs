namespace Domain.Entities
{
    public class HotelEntity : BaseEntity
    {
        public string owner_id { get; set; }
        public string name { get; set; }
        public string name_normalized { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public RatingSummary rating { get; set; } = new();
        public List<string> amenities { get; set; } = new();
        public List<string> images { get; set; } = new();

        public class RatingSummary
        {
            public double average_rating { get; set; }
            public int review_count { get; set; }
            public double cleanliness { get; set; }
            public double location { get; set; }
            public double service { get; set; }
            public double facilities { get; set; }
        }
    }
}
