using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Ws4vn.Microservices.Infrastructure.Sql
{
    public class DataAccessReadOnlyService : IDataAccessReadOnlyService
    {
        private DbContext _context { get; }
        private readonly Hashtable _hashRepository;

        public DataAccessReadOnlyService(DbContext dbContext)
        {
            _hashRepository = new Hashtable();
            _context = dbContext;
        }

        public IDataAccessReadOnlyRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;
            if (!_hashRepository.Contains(key))
            {
                var repositoryType = typeof(BaseModelRepository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _hashRepository[key] = repository;
            }

            return (IDataAccessReadOnlyRepository<TEntity>) _hashRepository[key];
        }
    }
}