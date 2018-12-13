using Ws4vn.Microservices.ApplicationCore.Entities;

namespace Microservice.Setting.ApplicationCore.Dtos
{
    public class ProvinceDto : ModelStringIdEntity
    {
        public string Name { get; internal set; }
    }
}
