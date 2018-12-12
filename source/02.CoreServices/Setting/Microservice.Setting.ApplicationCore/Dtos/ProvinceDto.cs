using Microservices.ApplicationCore.Entities;

namespace Microservice.Setting.Domain.Dtos
{
    public class ProvinceDto : ModelStringIdEntity
    {
        public string Name { get; internal set; }
    }
}
