using Domain.Entities;

namespace Application.Interfaces.Repositories.Hotel
{
    public interface IHotelReviewRepository
    {
        Task<List<HotelReviewEntity>> GetReviewsByHotelIdAsync(string hotelId);
        Task<List<HotelReviewEntity>> GetReviewsByUserIdAsync(string userId);
        // Task<HotelReviewEntity> GetByIdAsync(string id);
        Task<HotelReviewEntity> AddAsync(HotelReviewEntity entity);
        Task<bool> UpdateAsync(HotelReviewEntity entity, string id);
        Task<bool> DeleteAsync(string id);
    }
}
