using System;
using System.Collections;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.Models;

namespace Microservice.Core.DataAccess
{
    public class DomainService: IDomainService
    {
        private readonly Hashtable _hashRepository;

        public DomainService(IDomainContext Context)
        {
            _hashRepository = new Hashtable();
            _context = Context;
        }
        private IDomainContext _context { get; }

        public ISaveRepository<TEntity> Repository<TEntity>() where TEntity : DomainEntity
        {
            var key = typeof(TEntity).Name;
            if (!_hashRepository.Contains(key))
            {
                var repositoryType = typeof(BaseDomainRepository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _hashRepository[key] = repository;
            }

            return (ISaveRepository<TEntity>)_hashRepository[key];
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}