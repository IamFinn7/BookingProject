using Domain.Enums;

namespace Application.Features.Hotel.Commands
{
    public class CreateHotelResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Star { get; set; }
        public AccommodationType Type { get; set; }
        public List<string> Amenities { get; set; }
        public List<string> Images { get; set; }
    }
}
