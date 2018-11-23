using Microservice.Core;
using System;
using Ws4vn.Core.Models;

namespace ezStore.DomainEvents.Product
{
    [MessageBusRoute(EventRouteConstants.ProductService)]
    public class ProductCategoryUpdated : Event
    {
        public Guid Id { get; set; }
        public ProductCategoryUpdated(Guid id)
        {
            Id = id;
        }
    }
}
