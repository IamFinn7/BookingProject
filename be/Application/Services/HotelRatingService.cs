using Application.Interfaces.Repositories.Hotel;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class HotelRatingService : IHotelRatingService
    {
        private readonly IHotelReviewRepository _reviewRepository;
        private readonly IHotelRepository _hotelRepository;

        public HotelRatingService(
            IHotelReviewRepository reviewRepository,
            IHotelRepository hotelRepository
        )
        {
            _reviewRepository = reviewRepository;
            _hotelRepository = hotelRepository;
        }

        public async Task RecalculateRatingAsync(string hotelId)
        {
            var reviews = await _reviewRepository.GetReviewsByHotelIdAsync(hotelId);
            if (reviews == null || !reviews.Any())
                return;

            var summary = new RatingSummary
            {
                review_count = reviews.Count,
                cleanliness = reviews.Average(r => r.cleanliness),
                location = reviews.Average(r => r.location),
                service = reviews.Average(r => r.service),
                facilities = reviews.Average(r => r.facilities),
            };

            summary.average_rating = Math.Round(
                (summary.cleanliness + summary.location + summary.service + summary.facilities)
                    / 4.0,
                2
            );

            var hotel = await _hotelRepository.GetByIdAsync(hotelId);
            if (hotel == null)
                return;

            hotel.rating = summary;
            await _hotelRepository.UpdateAsync(hotel.id, hotel);
        }
    }
}
