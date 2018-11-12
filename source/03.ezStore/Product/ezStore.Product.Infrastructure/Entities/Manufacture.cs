using Microservice.Core.Models;

using System;

namespace ezStore.Product.Infrastructure.Entities
{
    public class Manufacture : ModelEntity<Guid>
    {
        public string Name { get; set; }
    }
}
