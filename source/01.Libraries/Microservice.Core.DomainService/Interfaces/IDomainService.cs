using Microservice.Core.DomainService.Models;
using Ws4vn.DataAccess.Core.Interfaces;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IDomainService
    {
        IDataAccessWriteService WriteService { get; }

        void ApplyChanges<TEntity>(TEntity entity) where TEntity : AggregateRoot;

        void SaveChanges();
    }
}