namespace Application.Interfaces.Services
{
    public interface IHotelRatingService
    {
        Task RecalculateRatingAsync(string hotelId);
    }
}
