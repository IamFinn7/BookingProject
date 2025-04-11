namespace Application.Common.Interfaces
{
    public interface IHotelRatingService
    {
        Task RecalculateRatingAsync(string hotelId);
    }
}
