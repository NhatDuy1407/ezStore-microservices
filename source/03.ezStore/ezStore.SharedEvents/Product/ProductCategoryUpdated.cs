using Microservice.Core;
using Microservice.Core.Models;
using System;

namespace ezStore.SharedEvents.Product
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
