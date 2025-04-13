using Domain.Entities;
using Domain.Entities.System;

namespace Application.Interfaces.Repositories.Hotel
{
    public interface IHotelRepository
    {
        Task<List<HotelEntity>> GetAllAsync(FindCreterias creterias, List<SortCreterias> sortCreterias);
        Task<HotelEntity> GetByIdAsync(string id);
        Task<HotelEntity> AddAsync(HotelEntity entity);
        Task<bool> UpdateAsync(string id, HotelEntity entity);
        Task<bool> DeleteAsync(string id);
    }
}
