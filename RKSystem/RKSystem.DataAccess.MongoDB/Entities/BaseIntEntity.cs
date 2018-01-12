namespace RKSystem.DataAccess.MongoDB.Entities
{
    public abstract class BaseIntEntity<T> : DataAccess.Entities.BaseEntityInfo<int, T>
    {
        protected abstract override void UpdateDomain(T data, string userId);
    }
}