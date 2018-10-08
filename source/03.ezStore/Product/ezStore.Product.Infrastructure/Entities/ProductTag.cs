using Microservice.Core.Models;
using System;

namespace ezStore.Product.Infrastructure.Entities
{
    public class ProductTag : ModelEntity<Guid>
    {
        public string Name { get; set; }
    }
}
