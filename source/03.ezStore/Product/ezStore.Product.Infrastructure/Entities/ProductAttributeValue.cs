using Microservice.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ezStore.Product.Infrastructure.Entities
{
    public class ProductAttributeValue : ModelGuidIdEntity
    {
        public Guid AttributeId { get; set; }

        public Guid ProductId { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public ProductAttribute ProductAttribute { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public string Value { get; set; }
    }
}
