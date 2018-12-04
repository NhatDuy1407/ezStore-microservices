using Microservice.Core;
using Microservice.Core.DomainService.Events;
using System;

namespace ezStore.DomainEvents.Product
{
    [MessageBusRoute(EventRouteConstants.ProductService)]
    public class ProductCategoryCreated : DomainEvent
    {
        public Guid Id { get; set; }
        public ProductCategoryCreated(Guid id)
        {
            Id = id;
        }
    }
}
