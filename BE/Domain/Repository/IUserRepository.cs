namespace Domain.Repository
{
    public interface IUserRepository
    {
        Task<string> GetUserNameByIdAsync(string userId);
    }
}
