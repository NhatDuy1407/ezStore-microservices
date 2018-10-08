using Microservice.Core.DomainService.Models;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IDomainService
    {
        void ApplyChanges<TEntity>(TEntity entity) where TEntity : AggregateRoot;

        void SaveChanges();
    }
}