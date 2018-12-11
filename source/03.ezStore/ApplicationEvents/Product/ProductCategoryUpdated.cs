using Microservice.Core;
using Microservice.Core.DomainService.Events;
using System;

namespace ezStore.ApplicationEvents.Product
{
    [MessageBusRoute(EventRouteConstants.ProductService)]
    public class ProductCategoryUpdated : ApplicationEvent
    {
        public Guid Id { get; set; }
        public ProductCategoryUpdated(Guid id)
        {
            Id = id;
        }
    }
}
