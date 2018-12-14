using Ws4vn.Microservicess.ApplicationCore.Entities;

namespace ezStore.Product.ApplicationCore.Dtos
{
    public class ProductCategoryDto : ModelGuidIdEntity
    {
        public string Name { get; internal set; }
    }
}
