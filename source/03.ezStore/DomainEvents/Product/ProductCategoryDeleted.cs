using Microservice.Core;
using System;
using Ws4vn.Core.Models;

namespace ezStore.DomainEvents.Product
{
    [MessageBusRoute(EventRouteConstants.ProductService)]
    public class ProductCategoryDeleted : Event
    {
        public Guid Id { get; set; }
        public ProductCategoryDeleted(Guid id)
        {
            Id = id;
        }
    }
}
