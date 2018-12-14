using Ws4vn.Microservicess.ApplicationCore.Entities;

namespace Microservices.Setting.ApplicationCore.Dtos
{
    public class ProvinceDto : ModelIntIdEntity
    {
        public string Name { get; internal set; }
    }
}
