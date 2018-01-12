using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RKSystem.DataAccess.MongoDB.Entities
{
    public abstract class BaseIntEntity<T> : DataAccess.Entities.BaseEntityInfo<int, T>
    {
        [BsonId]
        public ObjectId _id { get; set; }

        protected abstract override void UpdateDomain(T data, string userId);
    }
}