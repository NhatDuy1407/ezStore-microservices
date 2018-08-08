namespace Microservice.Core.DataAccess.Interfaces
{
    public interface ISaveRepository<TModel> 
    {
        void Save(TModel entity);
    }
}