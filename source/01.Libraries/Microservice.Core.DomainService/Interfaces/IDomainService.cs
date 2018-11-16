using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DomainService.Models;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IDomainService
    {
        IDataAccessWriteService WriteService { get; }

        void ApplyChanges<TEntity>(TEntity entity) where TEntity : AggregateRoot;

        void SaveChanges();
    }
}