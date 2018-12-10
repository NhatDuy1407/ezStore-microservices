using Microservice.Core.Models;
using System;

namespace ezStore.Product.ApplicationCore.Entities
{
    public class ProductTag : ModelGuidIdEntity
    {
        public string Name { get; set; }
    }
}
