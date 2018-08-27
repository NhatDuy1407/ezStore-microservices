using System;
using System.Collections;
using Microservice.Core.DataAccess.Interfaces;

namespace Microservice.Core.DataAccess.MongoDB
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
                var repositoryType = typeof(BaseModelRepository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), Context);
                _hashRepository[key] = repository;
            }

            return (IReadOnlyRepository<TEntity>) _hashRepository[key];
        }
    }
}