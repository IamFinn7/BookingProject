namespace API.DTOs.Hotel
{
    public record UpdateHotelReviewRequest(
        int Cleanliness,
        int Location,
        int Service,
        int Facilities,
        string Comment
    );
}
