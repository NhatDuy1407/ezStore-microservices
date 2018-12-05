using Microservice.Core;
using Microservice.Core.DomainService.Events;
using System;

namespace ezStore.DomainEvents.Product
{
    [MessageBusRoute(EventRouteConstants.ProductService)]
    public class ProductCategoryUpdated : DomainEvent
    {
        public Guid Id { get; set; }
        public ProductCategoryUpdated(Guid id)
        {
            Id = id;
        }
    }
}
