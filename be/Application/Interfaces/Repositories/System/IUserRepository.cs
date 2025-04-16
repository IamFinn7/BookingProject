using Domain.Entities;

namespace Application.Interfaces.Repositories.System
{
    public interface IUserRepository
    {
        Task<string> GetUserNameByIdAsync(string id);
        Task<UserEntity> GetByIdAsync(string id);
        Task<UserEntity> GetByEmailAsync(string email);
        Task<UserEntity> RegisterAccountAsync(UserEntity entity);
    }
}
