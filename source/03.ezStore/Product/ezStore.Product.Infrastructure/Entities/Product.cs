using Microservice.Core.Models;
using System;

namespace ezStore.Product.Infrastructure.Entities
{
    public class Product : ModelEntity<Guid>
    {
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public string SKU { get; set; }

        public bool Published { get; set; }
    }
}
