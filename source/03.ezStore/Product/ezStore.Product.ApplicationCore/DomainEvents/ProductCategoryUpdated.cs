using Ws4vn.Microservicess.ApplicationCore.Events;
using System;

namespace ezStore.Product.ApplicationCore.DomainEvents
{
    public class ProductCategoryUpdated : DomainEvent
    {
        public Guid Id { get; set; }
        public ProductCategoryUpdated(Guid id)
        {
            Id = id;
        }
    }
}
