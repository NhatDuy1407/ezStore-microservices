using Microservices.ApplicationCore.Events;
using System;

namespace ezStore.Product.ApplicationCore.DomainEvents
{
    public class ProductCategoryCreated : DomainEvent
    {
        public Guid Id { get; set; }
        public ProductCategoryCreated(Guid id)
        {
            Id = id;
        }
    }
}
