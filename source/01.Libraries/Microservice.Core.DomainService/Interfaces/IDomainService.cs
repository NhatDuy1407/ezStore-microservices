using Microservice.Core.DomainService.Models;
using Microservice.DataAccess.Core.Interfaces;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IDomainService
    {
        IDataAccessWriteService WriteService { get; }

        void ApplyChanges<TEntity>(TEntity entity) where TEntity : AggregateRoot;

        void SaveChanges();
    }
}