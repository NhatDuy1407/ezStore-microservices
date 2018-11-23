using Ws4vn.Core.Models;
using System;

namespace ezStore.Product.Infrastructure.Entities
{
    public class ProductCategory : ModelGuidIdEntity
    {
        public ProductCategory()
        {
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }
    }
}
