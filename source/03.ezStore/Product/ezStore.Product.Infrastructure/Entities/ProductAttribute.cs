using Microservice.Core.Models;
using System;

namespace ezStore.Product.Infrastructure.Entities
{
    public class ProductAttribute : ModelEntity<Guid>
    {
        public string Name { get; set; }
    }
}
