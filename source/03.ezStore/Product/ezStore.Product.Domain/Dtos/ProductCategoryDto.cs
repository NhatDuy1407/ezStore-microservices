using Microservice.Core.Models;

namespace ezStore.Product.Domain.Dtos
{
    public class ProductCategoryDto : ModelGuidIdEntity
    {
        public string Name { get; internal set; }
    }
}
