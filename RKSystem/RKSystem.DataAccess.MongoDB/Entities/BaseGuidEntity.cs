using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RKSystem.DataAccess.MongoDB.Entities
{
    public abstract class BaseGuidEntity<T> : DataAccess.Entities.BaseEntityInfo<Guid, T>
    {
        [BsonId]
        public ObjectId _id { get; set; }

        protected abstract override void UpdateDomain(T data, string userId);
    }
}