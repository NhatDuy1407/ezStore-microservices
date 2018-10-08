using Microservice.Core;
using Microservice.Core.Models;
using System;

namespace ezStore.SharedEvents.Product
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
