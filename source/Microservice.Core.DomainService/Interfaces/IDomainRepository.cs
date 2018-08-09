namespace Microservice.Core.DomainService.Interfaces
{
    public interface IDomainRepository<TModel> 
    {
        void Save(TModel entity);
    }
}