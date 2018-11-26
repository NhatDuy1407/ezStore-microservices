using Microservice.Core.Models;

namespace ezStore.Product.Infrastructure.Entities
{
    public class ProductAttribute : ModelGuidIdEntity
    {
        public string Name { get; set; }
    }
}
