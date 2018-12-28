using Ws4vn.Microservices.ApplicationCore.Entities;

namespace ezStore.Product.API.ViewModels
{
    public class ProductViewModel : ModelGuidIdEntity
    {
        public string Name { get; internal set; }
    }
}
