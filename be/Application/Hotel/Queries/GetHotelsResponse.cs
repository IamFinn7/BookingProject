using Domain.Enums;

namespace Application.Hotel.Queries
{
    public class GetHotelsResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Star { get; set; }
        public AccommodationType Type { get; set; }
        public RatingSummary Rating { get; set; }
        public List<string> Amenities { get; set; }
        public List<string> Images { get; set; }
        public string OwnerName { get; set; }

        public class RatingSummary
        {
            public double AverageRating { get; set; }
            public int ReviewCount { get; set; }
            public double Cleanliness { get; set; }
            public double Location { get; set; }
            public double Service { get; set; }
            public double Facilities { get; set; }
        }
    }
}
