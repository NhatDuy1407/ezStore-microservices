using Ws4vn.Microservicess.ApplicationCore.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ezStore.Product.ApplicationCore.Entities
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
