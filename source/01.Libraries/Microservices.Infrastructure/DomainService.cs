using Microservices.ApplicationCore.Entities;
using Microservices.ApplicationCore.Interfaces;

namespace Microservices.Infrastructure
{
    public class DomainService : IDomainService
    {
        public DomainService(IDomainContext context, IDataAccessWriteService writeService)
        {
            _context = context;
            WriteService = writeService;
        }

        public IDataAccessWriteService WriteService { get; }

        private IDomainContext _context { get; }

        public void ApplyChanges<TEntity>(TEntity entity) where TEntity : AggregateRoot
        {
            WriteService.SaveChanges();
            _context.SaveEvents(entity);
        }
    }
}