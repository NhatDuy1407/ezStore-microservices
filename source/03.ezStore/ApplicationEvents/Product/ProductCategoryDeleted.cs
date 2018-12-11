using Microservice.Core;
using Microservice.Core.DomainService.Events;
using System;

namespace ezStore.ApplicationEvents.Product
{
    [MessageBusRoute(EventRouteConstants.ProductService)]
    public class ProductCategoryDeleted : ApplicationEvent
    {
        public Guid Id { get; set; }
        public ProductCategoryDeleted(Guid id)
        {
            Id = id;
        }
    }
}
