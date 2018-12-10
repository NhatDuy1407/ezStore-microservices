using Microservice.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ezStore.Product.ApplicationCore.Entities
{
    public class ProductManufactureMapping : ModelGuidIdEntity
    {
        public Guid ManufactureId { get; set; }

        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ManufactureId))]
        public Manufacture Manufacture { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
