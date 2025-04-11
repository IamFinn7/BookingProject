namespace API.DTOs.Hotel
{
    public record UpdateHotelRequest(
        string Name,
        string Address,
        string City,
        string Country,
        List<string> Amenities,
        List<string> Images
    );
}
