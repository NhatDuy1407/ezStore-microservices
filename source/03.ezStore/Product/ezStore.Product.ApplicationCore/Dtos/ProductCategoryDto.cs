using Microservice.Core.Models;

namespace ezStore.Product.ApplicationCore.Dtos
{
    public class ProductCategoryDto : ModelGuidIdEntity
    {
        public string Name { get; internal set; }
    }
}
