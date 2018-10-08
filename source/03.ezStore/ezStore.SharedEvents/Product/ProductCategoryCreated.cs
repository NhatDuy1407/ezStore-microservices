using Microservice.Core;
using Microservice.Core.Models;
using System;

namespace ezStore.SharedEvents.Product
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
