namespace Application.Interfaces.Repositories.Common
{
    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
