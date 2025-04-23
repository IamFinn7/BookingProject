namespace Application.Features.Hotel.Commands
{
    public class CreateHotelReviewResponse
    {
        public string Id { get; set; }
        public string HotelId { get; set; }
        public string UserId { get; set; }
        public int Cleanliness { get; set; }
        public int Location { get; set; }
        public int Service { get; set; }
        public int Facilities { get; set; }
        public string Comment { get; set; }
    }
}
