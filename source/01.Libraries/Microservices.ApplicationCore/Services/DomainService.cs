using Ws4vn.Microservices.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Ws4vn.Microservices.ApplicationCore.Services
{
    public class DomainService : IDomainService
    {
        private IDomainContext _context { get; }
        public IDataAccessWriteService WriteService { get; }

        public DomainService(IDomainContext context, IDataAccessWriteService writeService)
        {
            _context = context;
            WriteService = writeService;
        }

        public void ApplyChanges<TEntity>(TEntity entity) where TEntity : AggregateRoot
        {
            WriteService.SaveChanges();
            _context.SaveEvents(entity);
        }
    }
}