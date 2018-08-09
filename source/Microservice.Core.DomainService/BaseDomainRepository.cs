using Microservice.Core.DomainService.Interfaces;
using Microservice.Core.Models;

namespace Microservice.Core.DomainService
{
    public class BaseDomainRepository<TModel> : IDomainRepository<TModel> where TModel : DomainEntity
    {
        protected readonly DomainContext Context;

        public BaseDomainRepository(DomainContext context)
        {
            Context = context;
        }

        public void Save(TModel entity)
        {
            Context.AddEvents(entity);
        }
    }
}