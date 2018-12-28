using Ws4vn.Microservices.ApplicationCore.Entities;

namespace ezStore.Product.ApplicationCore.Dtos
{
    public class ProductDto : ModelGuidIdEntity
    {
        public string Name { get; internal set; }
    }
}
