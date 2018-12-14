using Ws4vn.Microservicess.ApplicationCore.Entities;

namespace Ws4vn.Microservicess.ApplicationCore.Interfaces
{
    public interface IDomainService
    {
        IDataAccessWriteService WriteService { get; }

        void ApplyChanges<TEntity>(TEntity entity) where TEntity : AggregateRoot;
    }
}