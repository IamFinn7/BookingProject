using Application.Hotel.Commands;
using Application.Hotel.Queries;
using Domain.Entities;

namespace Application.Hotels
{
    public static class HotelMapper
    {
        public static GetHotelsResponse ToGetHotelsResponse(this HotelEntity hotels)
        {
            return new GetHotelsResponse
            {
                Id = hotels.id,
                Name = hotels.name,
                Address = hotels.address,
                City = hotels.city,
                Country = hotels.country,
                Rating = new RatingSummaryResponse
                {
                    AverageRating = hotels.rating.average_rating,
                    ReviewCount = hotels.rating.review_count,
                    Cleanliness = hotels.rating.cleanliness,
                    Location = hotels.rating.location,
                    Service = hotels.rating.service,
                    Facilities = hotels.rating.facilities,
                },
                Amenities = hotels.amenities,
                Images = hotels.images,
            };
        }

        public static CreateHotelResponse ToHotelFromCreate(this HotelEntity hotels)
        {
            return new CreateHotelResponse
            {
                Id = hotels.id,
                Name = hotels.name,
                OwnerId = hotels.owner_id,
                Address = hotels.address,
                City = hotels.city,
                Country = hotels.country,
                Amenities = hotels.amenities,
                Images = hotels.images,
            };
        }

        public static CreateHotelReviewResponse ToHotelReviewFromCreate(
            this HotelReviewEntity review
        )
        {
            return new CreateHotelReviewResponse
            {
                Id = review.id,
                HotelId = review.hotel_id,
                UserId = review.user_id,
                Cleanliness = review.cleanliness,
                Location = review.location,
                Service = review.service,
                Facilities = review.facilities,
                Comment = review.comment,
            };
        }
    }
}
