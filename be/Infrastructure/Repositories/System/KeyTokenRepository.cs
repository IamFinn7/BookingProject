using Application.Interfaces.Repositories.Authentication;
using Domain.Entities.System;
using MongoDB.Driver;
using Shared.Exceptions;

namespace Infrastructure.Repositories.System
{
    public class KeyTokenRepository : IKeyTokenRepository
    {
        private readonly IMongoCollection<KeyTokenEntity> _collection;

        public KeyTokenRepository(MongoDBHelper mongoDBHelper)
        {
            // Tạo collection nếu chưa có
            mongoDBHelper.CreateCollectionIfNotExistsAsync("keys").Wait();

            // Gán collection
            _collection = mongoDBHelper.GetCollection<KeyTokenEntity>("keys");
        }

        public async Task<KeyTokenEntity> GetAsync(string token)
        {
            try
            {
                var filter = Builders<KeyTokenEntity>.Filter.Eq(x => x.token, token);

                var result = await _collection.Find(filter).FirstOrDefaultAsync();

                return result;
            }
            catch
            {
                throw new InternalServerException();
            }
        }

        public async Task<KeyTokenEntity> SaveAsync(KeyTokenEntity entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);

                return entity;
            }
            catch
            {
                throw new InternalServerException();
            }
        }

        public async Task<bool> UpdateAsync(string id, KeyTokenEntity entity)
        {
            try
            {
                var filter = Builders<KeyTokenEntity>.Filter.Eq(x => x.id, id);

                var hotel = await _collection.Find(filter).FirstOrDefaultAsync();

                var update = Builders<KeyTokenEntity>
                    .Update.Set(x => x.token, entity.token ?? hotel.token)
                    .Set(x => x.updated_at, DateTime.Now.Ticks);

                var updated = await _collection.FindOneAndUpdateAsync(
                    filter,
                    update,
                    new FindOneAndUpdateOptions<KeyTokenEntity>
                    {
                        ReturnDocument = ReturnDocument.After,
                    }
                );

                return updated != null;
            }
            catch
            {
                throw new InternalServerException();
            }
        }

        public async Task<bool> DeleteAsync(string token)
        {
            try
            {
                var filter = Builders<KeyTokenEntity>.Filter.Eq(x => x.token, token);
                var delete = await _collection.FindOneAndDeleteAsync(filter);

                return delete != null;
            }
            catch
            {
                throw new InternalServerException();
            }
        }
    }
}
