using Application.Interfaces.Repositories.Hotel;
using Domain.Entities;
using MongoDB.Driver;
using Shared.Exceptions;

namespace Infrastructure.Repositories.Hotel
{
    public class HotelReviewRepository : IHotelReviewRepository
    {
        private readonly IMongoCollection<HotelReviewEntity> _collection;

        public HotelReviewRepository(MongoDBHelper mongoDBHelper)
        {
            mongoDBHelper.CreateCollectionIfNotExistsAsync("hotel_review").Wait();

            _collection = mongoDBHelper.GetCollection<HotelReviewEntity>("hotel_review");
        }

        public async Task<List<HotelReviewEntity>> GetReviewsByHotelIdAsync(string hotelId)
        {
            try
            {
                var result = await _collection.Find(x => x.hotel_id == hotelId).ToListAsync();
                return result;
            }
            catch
            {
                throw new InternalServerException();
            }
        }

        public async Task<List<HotelReviewEntity>> GetReviewsByUserIdAsync(string userId)
        {
            try
            {
                var result = await _collection.Find(x => x.user_id == userId).ToListAsync();
                return result;
            }
            catch
            {
                throw new InternalServerException();
            }
        }

        public async Task<HotelReviewEntity> AddAsync(HotelReviewEntity entity)
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

        public async Task<bool> UpdateAsync(HotelReviewEntity entity, string id)
        {
            try
            {
                var filter = Builders<HotelReviewEntity>.Filter.Eq(x => x.id, id);

                var review = await _collection.Find(filter).FirstOrDefaultAsync();

                var update = Builders<HotelReviewEntity>
                    .Update.Set(x => x.cleanliness, entity?.cleanliness ?? review.cleanliness)
                    .Set(x => x.location, entity?.location ?? review.location)
                    .Set(x => x.service, entity?.service ?? review.service)
                    .Set(x => x.facilities, entity?.facilities ?? review.facilities)
                    .Set(x => x.comment, entity.comment ?? review.comment)
                    .Set(x => x.updated_at, DateTime.Now.Ticks);

                var updated = await _collection.FindOneAndUpdateAsync(
                    filter,
                    update,
                    new FindOneAndUpdateOptions<HotelReviewEntity>
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

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var filter = Builders<HotelReviewEntity>.Filter.Eq(x => x.id, id);
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
