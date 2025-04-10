using Domain.Entities;
using Domain.Repository;
using MongoDB.Driver;
using Shared.Exceptions;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserEntity> _collection;

        public UserRepository(MongoDBHelper mongoDBHelper)
        {
            // Tạo collection nếu chưa có
            mongoDBHelper.CreateCollectionIfNotExistsAsync("users").Wait();

            // Gán collection
            _collection = mongoDBHelper.GetCollection<UserEntity>("users");
        }

        public async Task<string> GetUserNameByIdAsync(string id)
        {
            try
            {
                var filter = Builders<UserEntity>.Filter.Eq(x => x.id, id);

                var result = await _collection.Find(filter).FirstOrDefaultAsync();

				if (result == null)
					return "unknown";

				return result.full_name;
            }
            catch
            {
                throw new InternalServerException();
            }
        }
    }
}
