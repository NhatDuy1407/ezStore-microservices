using Microservice.Core;
using System;
using Ws4vn.Core.Models;

namespace ezStore.DomainEvents.Product
{
    [MessageBusRoute(EventRouteConstants.ProductService)]
    public class ProductCategoryCreated : Event
    {
        public Guid Id { get; set; }
        public ProductCategoryCreated(Guid id)
        {
            Id = id;
        }
    }
}
