using Microservice.Core.DomainService.Interfaces;
using Microservice.Core.DomainService.Models;
using Microservice.DataAccess.Core.Interfaces;

namespace Microservice.Core.DomainService
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
            _context.AddEvents(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}