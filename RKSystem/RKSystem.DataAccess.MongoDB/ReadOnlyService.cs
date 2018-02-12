using System;
using System.Collections;
using RKSystem.DataAccess.MongoDB.Interfaces;

namespace RKSystem.DataAccess.MongoDB
{
    public class ReadOnlyService : IReadOnlyService
    {
        private readonly Hashtable _hashRepository;

        public ReadOnlyService(MongoDbContext dbContext)
        {
            _hashRepository = new Hashtable();
            Context = dbContext;
        }

        private MongoDbContext Context { get; }

        public IReadOnlyRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;
            if (!_hashRepository.Contains(key))
            {
                var repositoryType = typeof(BaseRepository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), Context);
                _hashRepository[key] = repository;
            }

            return (IReadOnlyRepository<TEntity>) _hashRepository[key];
        }

        #region disposed

        private bool _disposed;

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                {
                }
            _disposed = true;
        }

        #endregion
    }
}