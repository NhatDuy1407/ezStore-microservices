using System;
using System.Collections;
using Microservice.Core.DomainService.Interfaces;
using Microservice.Core.Models;

namespace Microservice.Core.DomainService
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

        public IDomainRepository<TEntity> Repository<TEntity>() where TEntity : DomainEntity
        {
            var key = typeof(TEntity).Name;
            if (!_hashRepository.Contains(key))
            {
                var repositoryType = typeof(BaseDomainRepository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _hashRepository[key] = repository;
            }

            return (IDomainRepository<TEntity>)_hashRepository[key];
        }


        public void SaveChanges()
        {
            _context.SaveChangesAsync();
        }
    }
}