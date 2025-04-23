using Domain.Entities;
using Domain.Entities.System;

namespace Application.Interfaces.Repositories.Room
{
    public interface IRoomRepository
    {
        Task<List<RoomEntity>> GetAllByHotelIdAsync(
            string hotelId,
            FindCreterias creterias,
            List<SortCreterias> sortCreterias
        );
        Task<RoomEntity> GetByIdAsync(string id);
        Task<RoomEntity> AddAsync(RoomEntity entity);
        Task<bool> UpdateAsync(string id, RoomEntity entity);
        Task<bool> DeleteAsync(string id);
    }
}
