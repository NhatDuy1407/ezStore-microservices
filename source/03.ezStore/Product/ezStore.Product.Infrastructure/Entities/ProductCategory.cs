using Microservice.Core.Models;
using System;

namespace ezStore.Product.Infrastructure.Entities
{
    public class ProductCategory : ModelEntity<Guid>
    {
        public ProductCategory()
        {
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }
    }
}
