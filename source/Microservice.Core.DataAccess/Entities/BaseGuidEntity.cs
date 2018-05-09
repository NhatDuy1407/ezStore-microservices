using System;

namespace Microservice.Core.DataAccess.Entities
{
    public abstract class BaseGuidEntity<T> : BaseEntityInfo<Guid, T>
    {
        protected abstract override void UpdateDomain(T data, string userId);
    }
}