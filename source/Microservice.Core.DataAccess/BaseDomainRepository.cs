using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.Models;

namespace Microservice.Core.DataAccess
{
    public class BaseDomainRepository<TModel> : ISaveRepository<TModel> where TModel : DomainEntity
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