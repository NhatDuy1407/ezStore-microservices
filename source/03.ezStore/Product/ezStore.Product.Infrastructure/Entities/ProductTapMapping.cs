using Ws4vn.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ezStore.Product.Infrastructure.Entities
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
