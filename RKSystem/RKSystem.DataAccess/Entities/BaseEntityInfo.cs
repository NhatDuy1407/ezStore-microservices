namespace RKSystem.DataAccess.Entities
{
    public abstract class BaseEntityInfo<T, TY> : BaseEntity<T>
    {
        protected abstract void UpdateDomain(TY data, string userId);

        public void Update(TY data, string userId)
        {
            if (data is BaseGuidModel)
                UpdateId((data as BaseGuidModel).Id, userId);
            else if (data is BaseIntModel)
                UpdateId((data as BaseIntModel).Id, userId);
            else
                UpdateId(null, userId);

            UpdateDomain(data, userId);
        }
    }
}