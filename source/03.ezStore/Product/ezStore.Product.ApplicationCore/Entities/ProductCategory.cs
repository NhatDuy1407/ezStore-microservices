using Ws4vn.Microservicess.ApplicationCore.Entities;
using System;

namespace ezStore.Product.ApplicationCore.Entities
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
