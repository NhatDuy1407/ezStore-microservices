using Microservices.ApplicationCore.Entities;

namespace ezStore.Product.API.ViewModels
{
    public class ProductCategoryViewModel : ModelGuidIdEntity
    {
        public string Name { get; internal set; }
    }
}
