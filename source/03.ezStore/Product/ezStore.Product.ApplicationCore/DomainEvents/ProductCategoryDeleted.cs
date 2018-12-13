using Microservices.ApplicationCore.Events;
using System;

namespace ezStore.Product.ApplicationCore.DomainEvents
{
    public class ProductCategoryDeleted : DomainEvent
    {
        public Guid Id { get; set; }
        public ProductCategoryDeleted(Guid id)
        {
            Id = id;
        }
    }
}
