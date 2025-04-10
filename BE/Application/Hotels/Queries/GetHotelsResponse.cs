namespace Application.Hotels.Queries
{
    public class GetHotelsResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double StarRating { get; set; }
        public List<string> Amenities { get; set; }
        public List<string> Images { get; set; }

        public string OwnerName { get; set; }
    }
}
