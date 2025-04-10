using Domain.Entities;
using Domain.Entities.System;

namespace Domain.Repository
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllAsync(FindCreterias creterias, List<SortCreterias> sortCreterias);
        Task<Hotel> GetByIdAsync(string id);
        Task<Hotel> AddAsync(Hotel entity);
        Task<bool> UpdateAsync(string id, Hotel entity);
        Task<bool> DeleteAsync(string id);
    }
}
