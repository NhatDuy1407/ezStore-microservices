using System;
using System.Collections;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DataAccess.MongoDB;

namespace Microservice.Member.Infrastructure
{
    public class WriteService : IWriteService
    {
        private readonly Hashtable _hashRepository;

        public WriteService(MemberContext dbContext)
        {
            _hashRepository = new Hashtable();
            Context = dbContext;
        }

        private MemberContext Context { get; }

        public IWriteRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;
            if (!_hashRepository.Contains(key))
            {
                var repositoryType = typeof(BaseRepository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), Context);
                _hashRepository[key] = repository;
            }

            return (IWriteRepository<TEntity>)_hashRepository[key];
        }
    }
}