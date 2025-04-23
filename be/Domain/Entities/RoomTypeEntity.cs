namespace Domain.Entities
{
    public class RoomTypeEntity : BaseEntity
    {
        public string name { get; set; }

        public int bed_count { get; set; }

        public int area { get; set; }

        public List<string> amenities { get; set; }
    }
}
