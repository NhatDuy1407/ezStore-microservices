using Ws4vn.Core.Models;
using System;

namespace ezStore.Product.Infrastructure.Entities
{
    public class ProductTag : ModelGuidIdEntity
    {
        public string Name { get; set; }
    }
}
