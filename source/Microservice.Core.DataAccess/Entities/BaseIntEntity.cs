namespace Microservice.Core.DataAccess.Entities
{
    public abstract class BaseIntEntity<T> : BaseEntityInfo<int, T>
    {
        protected abstract override void UpdateDomain(T data, string userId);
    }
}