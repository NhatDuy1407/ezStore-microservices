using Ws4vn.Microservices.ApplicationCore.Entities;

namespace ezStore.Product.ApplicationCore.Dtos
{
    public class ProductCategoryDto : ModelGuidIdEntity
    {
        public string Name { get; internal set; }
    }
}
