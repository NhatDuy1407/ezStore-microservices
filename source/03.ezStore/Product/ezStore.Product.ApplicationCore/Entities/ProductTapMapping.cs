using Ws4vn.Microservices.ApplicationCore.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ezStore.Product.ApplicationCore.Entities
{
    public class ProductTapMapping : ModelGuidIdEntity
    {
        public Guid ProductTagId { get; set; }

        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductTagId))]
        public ProductTag ProductTag { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
