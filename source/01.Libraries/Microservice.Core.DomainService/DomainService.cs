using System.Collections;
using Microservice.Core.DomainService.Interfaces;
using Microservice.Core.DomainService.Models;

namespace Microservice.Core.DomainService
{
    public class DomainService: IDomainService
    {
        public DomainService(IDomainContext Context)
        {
            _context = Context;
        }
        private IDomainContext _context { get; }

        public void ApplyChanges<TEntity>(TEntity entity) where TEntity : AggregateRoot
        {
            _context.AddEvents(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}