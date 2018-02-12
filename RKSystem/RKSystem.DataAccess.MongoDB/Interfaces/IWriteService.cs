using System;

namespace RKSystem.DataAccess.MongoDB.Interfaces
{
    public interface IWriteService : IDisposable
    {
        IWriteRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}