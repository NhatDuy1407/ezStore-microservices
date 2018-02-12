using System;

namespace RKSystem.DataAccess.MongoDB.Interfaces
{
    public interface IReadOnlyService : IDisposable
    {
        IReadOnlyRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}