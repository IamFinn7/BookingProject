using Application.Interfaces.Repositories.Room;
using Domain.Entities;
using Domain.Entities.System;
using MongoDB.Driver;
using Shared.Exceptions;

namespace Infrastructure.Repositories.Room
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IMongoCollection<RoomEntity> _collection;

        public RoomRepository(MongoDBHelper mongoDBHelper)
        {
            mongoDBHelper.CreateCollectionIfNotExistsAsync("room").Wait();

            _collection = mongoDBHelper.GetCollection<RoomEntity>("room");
        }

        public async Task<List<RoomEntity>> GetAllByHotelIdAsync(
            string hotelId,
            FindCreterias creterias,
            List<SortCreterias> sortCreterias
        )
        {
            try
            {
                var builder = Builders<RoomEntity>.Filter;
                var filtered = builder.Empty;

                filtered &= builder.Eq(x => x.hotel_id, hotelId);

                // if (creterias.SearchTerm.Count >= 1)
                // {
                //     var regexFilters = creterias.SearchTerm.Select(keyword =>
                //         builder.Regex(
                //             x => x.name_normalized,
                //             new BsonRegularExpression(keyword, "i")
                //         )
                //     );
                //     filtered &= builder.Or(regexFilters);
                // }

                var query = _collection
                    .Find(filtered)
                    .Skip(creterias.Page * creterias.Limit)
                    .Limit(creterias.Limit);

                var sortBuilder = Builders<RoomEntity>.Sort;
                var sortDefinitions = new List<SortDefinition<RoomEntity>>();

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

        public async Task<RoomEntity> GetByIdAsync(string id)
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

        public async Task<RoomEntity> AddAsync(RoomEntity entity)
        {
            try
            {
                // entity.name_normalized = SystemHelper.RemoveDiacritics(entity.name);
                await _collection.InsertOneAsync(entity);

                return entity;
            }
            catch
            {
                throw new InternalServerException();
            }
        }

        public async Task<bool> UpdateAsync(string id, RoomEntity entity)
        {
            try
            {
                var filter = Builders<RoomEntity>.Filter.Eq(x => x.id, id);

                var room = await _collection.Find(filter).FirstOrDefaultAsync();

                var update = Builders<RoomEntity>
                    .Update.Set(x => x.room_type, entity.room_type ?? room.room_type)
                    .Set(
                        x => x.base_price_per_night,
                        entity?.base_price_per_night ?? room.base_price_per_night
                    )
                    .Set(x => x.quantity, entity?.quantity ?? room.quantity)
                    .Set(x => x.bed_count, entity?.bed_count ?? room.bed_count)
                    .Set(x => x.images, entity.images ?? new List<string>())
                    .Set(x => x.amenities, entity.amenities ?? new List<string>())
                    .Set(x => x.features, entity.features ?? new List<string>())
                    .Set(x => x.updated_at, DateTime.Now.Ticks);

                var updated = await _collection.FindOneAndUpdateAsync(
                    filter,
                    update,
                    new FindOneAndUpdateOptions<RoomEntity>
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
                var filter = Builders<RoomEntity>.Filter.Eq(x => x.id, id);
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
