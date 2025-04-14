using Domain.Entities;

namespace Application.Interfaces.Repositories.System
{
    public interface IUserRepository
    {
        Task<string> GetUserNameByIdAsync(string userId);
        Task<UserEntity> GetByEmailAsync(string email);
        Task<UserEntity> RegisterAccountAsync(UserEntity entity);
    }
}
