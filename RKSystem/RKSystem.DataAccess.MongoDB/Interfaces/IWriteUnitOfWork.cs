using System;

namespace RKSystem.DataAccess.MongoDB.Interfaces
{
    public interface IWriteUnitOfWork : IDisposable
    {
        IWriteRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}