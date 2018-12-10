using Microservice.Core.Models;

namespace Microservice.Setting.ApplicationCore.Dtos
{
    public class ProvinceDto : ModelStringIdEntity
    {
        public string Name { get; internal set; }
    }
}
