using Domain.Entities.System;

namespace Application.Interfaces.Repositories.Authentication
{
    public interface IKeyTokenRepository
    {
        Task<KeyTokenEntity> SaveAsync(KeyTokenEntity entity);
        Task<KeyTokenEntity> GetAsync(string token);
        Task<bool> UpdateAsync(string id, KeyTokenEntity entity);
        Task<bool> DeleteAsync(string token);
    }
}
