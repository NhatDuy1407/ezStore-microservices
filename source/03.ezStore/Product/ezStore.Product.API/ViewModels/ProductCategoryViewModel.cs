using Microservice.Core.Models;

namespace ezStore.Product.API.ViewModels
{
    public class ProductCategoryViewModel : ModelGuidIdEntity
    {
        public string Name { get; internal set; }
    }
}
