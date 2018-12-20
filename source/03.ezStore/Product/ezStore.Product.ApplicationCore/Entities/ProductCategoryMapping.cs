using Ws4vn.Microservices.ApplicationCore.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ezStore.Product.ApplicationCore.Entities
{
    public class ProductCategoryMapping : ModelGuidIdEntity
    {
        public Guid CategoryId { get; set; }

        public Guid ProductId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public ProductCategory Category { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
