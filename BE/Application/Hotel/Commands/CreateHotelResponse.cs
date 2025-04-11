namespace Application.Hotel.Commands
{
    public class CreateHotelResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<string> Amenities { get; set; }
        public List<string> Images { get; set; }
    }
}
