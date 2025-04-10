namespace Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public string owner_id { get; set; }
        public string name { get; set; }
        public string name_normalized { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public double star_rating { get; set; }
        public List<string> amenities { get; set; } = new List<string>();
        public List<string> images { get; set; } = new List<string>();
    }
}
