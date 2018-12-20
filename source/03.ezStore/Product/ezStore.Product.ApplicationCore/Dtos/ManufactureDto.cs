using Ws4vn.Microservices.ApplicationCore.Entities;

namespace ezStore.Product.ApplicationCore.Dtos
{
    public class ManufactureDto : ModelGuidIdEntity
    {
        public string Name { get; internal set; }
    }
}
