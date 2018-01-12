using System;

namespace RKSystem.DataAccess.MongoDB.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void Save();
    }
}