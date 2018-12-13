using Ws4vn.Microservices.ApplicationCore.Entities;
using System;

namespace ezStore.Product.ApplicationCore.Entities
{
    public class ProductTag : ModelGuidIdEntity
    {
        public string Name { get; set; }
    }
}
