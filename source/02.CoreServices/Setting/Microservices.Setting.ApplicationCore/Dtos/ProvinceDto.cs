using Ws4vn.Microservices.ApplicationCore.Entities;

namespace Microservices.Setting.ApplicationCore.Dtos
{
    public class ProvinceDto : ModelIntIdEntity
    {
        public string Name { get; internal set; }
    }
}
