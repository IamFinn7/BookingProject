using Application.Features.Room.Queries;
using Domain.Entities;

namespace Application.Features.Room
{
    public static class RoomMapper
    {
        public static GetRoomsResponse ToGetRoomsResponse(this RoomEntity rooms)
        {
            return new GetRoomsResponse
            {
                Id = rooms.id,
                HotelId = rooms.hotel_id,
                RoomType = rooms.room_type,
                BasePricePerNight = rooms.base_price_per_night,
                Quantity = rooms.quantity,
                BedCount = rooms.bed_count,
                Images = rooms.images,
                Amenities = rooms.amenities,
                Features = rooms
                    .features.Select(r => new GetRoomsResponse.RoomFeatureReference
                    {
                        FeatureId = r.feature_id,
                        Enabled = r.enabled,
                    })
                    .ToList(),
                UnavailableDates = rooms
                    .unavailable_dates.Select(r => new GetRoomsResponse.RoomBookingDate
                    {
                        Date = r.date,
                        BookedCount = r.booked_count,
                    })
                    .ToList(),
                CreatedAt = rooms.created_at,
                UpdatedAt = rooms.updated_at,
            };
        }
    }
}
