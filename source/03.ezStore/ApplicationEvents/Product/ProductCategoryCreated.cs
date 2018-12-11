using Microservice.Core;
using Microservice.Core.DomainService.Events;
using System;

namespace ezStore.ApplicationEvents.Product
{
    [MessageBusRoute(EventRouteConstants.ProductService)]
    public class ProductCategoryCreated : ApplicationEvent
    {
        public Guid Id { get; set; }
        public ProductCategoryCreated(Guid id)
        {
            Id = id;
        }
    }
}
