using System;

namespace RKSystem.DataAccess.MongoDB.Interfaces
{
    public interface IReadOnlyUnitOfWork : IDisposable
    {
        IReadOnlyRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}