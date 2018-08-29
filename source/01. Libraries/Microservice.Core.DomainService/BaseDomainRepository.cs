using Microservice.Core.DomainService.Interfaces;
using Microservice.Core.DomainService.Models;

namespace Microservice.Core.DomainService
{
    public class BaseDomainRepository<TModel> : IDomainRepository<TModel> where TModel : DomainEntity
    {
        protected readonly IDomainContext Context;

        public BaseDomainRepository(IDomainContext context)
        {
            Context = context;
        }

        public void Save(TModel entity)
        {
            Context.AddEvents(entity);
        }
    }
}