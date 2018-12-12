using Microservices.ApplicationCore.Entities;

namespace Microservices.ApplicationCore.Interfaces
{
    public interface IDomainService
    {
        IDataAccessWriteService WriteService { get; }

        void ApplyChanges<TEntity>(TEntity entity) where TEntity : AggregateRoot;
    }
}