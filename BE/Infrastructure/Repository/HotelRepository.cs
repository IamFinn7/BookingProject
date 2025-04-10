using Domain.Entities;
using Domain.Entities.System;
using Domain.Repository;
using Infrastructure.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;
using Shared.Exceptions;

namespace Infrastructure.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IMongoCollection<Hotel> _collection;

        public HotelRepository(MongoDBHelper mongoDBHelper)
        {
            // Tạo collection nếu chưa có
            mongoDBHelper.CreateCollectionIfNotExistsAsync("hotels").Wait();

            // Gán collection
            _collection = mongoDBHelper.GetCollection<Hotel>("hotels");
        }

        public async Task<List<Hotel>> GetAllAsync(
            FindCreterias creterias,
            List<SortCreterias> sortCreterias
        )
        {
            try
            {
                var builder = Builders<Hotel>.Filter;
                var filtered = builder.Empty;

                if (creterias.SearchTerm.Count >= 1)
                {
                    var regexFilters = creterias.SearchTerm.Select(keyword =>
                        builder.Regex(
                            x => x.name_normalized,
                            new BsonRegularExpression(keyword, "i")
                        )
                    );
                    filtered &= builder.Or(regexFilters);
                }

                var query = _collection
                    .Find(filtered)
                    .Skip(creterias.Page * creterias.Limit)
                    .Limit(creterias.Limit);

                var sortBuilder = Builders<Hotel>.Sort;
                var sortDefinitions = new List<SortDefinition<Hotel>>();

                if (sortCreterias.Count >= 1)
                {
                    foreach (var criterion in sortCreterias)
                    {
                        if (criterion.Field == "created_at")
                        {
                            var fieldSort = criterion.IsDescending
                                ? sortBuilder.Descending(x => x.created_at)
                                : sortBuilder.Ascending(x => x.created_at);
                            sortDefinitions.Add(fieldSort);
                        }
                    }
                }

                if (sortDefinitions.Count >= 1)
                {
                    var combinedSort = sortBuilder.Combine(sortDefinitions);
                    query = query.Sort(combinedSort);
                }

                return await query.ToListAsync();
            }
            catch
            {
                throw new InternalServerException();
            }
        }

        public async Task<Hotel> GetByIdAsync(string id)
        {
            try
            {
                var result = await _collection.Find(x => x.id == id).FirstOrDefaultAsync();
                return result;
            }
            catch
            {
                throw new InternalServerException();
            }
        }

        public async Task<Hotel> AddAsync(Hotel entity)
        {
            try
            {
                entity.name_normalized = SystemHelper.RemoveDiacritics(entity.name);
                await _collection.InsertOneAsync(entity);

                return entity;
            }
            catch
            {
                throw new InternalServerException();
            }
        }

        public async Task<bool> UpdateAsync(string id, Hotel entity)
        {
            try
            {
                var filter = Builders<Hotel>.Filter.Eq(x => x.id, id);

                var hotel = await _collection.Find(filter).FirstOrDefaultAsync();

                var update = Builders<Hotel>
                    .Update.Set(x => x.name, entity.name ?? hotel.name)
                    .Set(x => x.address, entity.address ?? hotel.address)
                    .Set(x => x.city, entity.city ?? hotel.city)
                    .Set(x => x.country, entity.country ?? hotel.country)
                    .Set(x => x.amenities, entity.amenities ?? new List<string>())
                    .Set(x => x.images, entity.images ?? new List<string>())
                    .Set(x => x.updated_at, DateTime.Now.Ticks);

                var updated = await _collection.FindOneAndUpdateAsync(
                    filter,
                    update,
                    new FindOneAndUpdateOptions<Hotel> { ReturnDocument = ReturnDocument.After }
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
                var filter = Builders<Hotel>.Filter.Eq(x => x.id, id);
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
