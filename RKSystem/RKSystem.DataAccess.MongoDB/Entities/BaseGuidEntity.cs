using System;

namespace RKSystem.DataAccess.MongoDB.Entities
{
    public abstract class BaseGuidEntity<T> : DataAccess.Entities.BaseEntityInfo<Guid, T>
    {
        protected abstract override void UpdateDomain(T data, string userId);
    }
}