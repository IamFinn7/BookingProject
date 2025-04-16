namespace Domain.Entities
{
    public class HotelReviewEntity : BaseEntity
    {
        public string hotel_id { get; set; }
        public string user_id { get; set; }
        public int cleanliness { get; set; }
        public int location { get; set; }
        public int service { get; set; }
        public int facilities { get; set; }
        public string comment { get; set; }
    }
}
