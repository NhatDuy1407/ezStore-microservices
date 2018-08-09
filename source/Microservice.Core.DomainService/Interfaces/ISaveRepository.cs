namespace Microservice.Core.DomainService.Interfaces
{
    public interface ISaveRepository<TModel> 
    {
        void Save(TModel entity);
    }
}