using System;
using System.Collections;
using Microservice.DataAccess.Core.Interfaces;

namespace Microservice.DataAccess.MongoDB
{
    public class DataAccessWriteService : IDataAccessWriteService
    {
        private readonly Hashtable _hashRepository;

        public DataAccessWriteService(MongoDbContext dbContext)
        {
            _hashRepository = new Hashtable();
            Context = dbContext;
        }

        private MongoDbContext Context { get; }

        public IDataAccessWriteRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;
            if (!_hashRepository.Contains(key))
            {
                var repositoryType = typeof(BaseModelRepository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), Context);
                _hashRepository[key] = repository;
            }

            return (IDataAccessWriteRepository<TEntity>)_hashRepository[key];
        }


        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}