using Domain.Entities;

namespace Application.Interfaces.Repositories.System
{
    public interface IUserRepository
    {
        Task<string> GetUserNameByIdAsync(string userId);
        Task<UserEntity> RegisterAccountAsync(UserEntity entity);
    }
}
