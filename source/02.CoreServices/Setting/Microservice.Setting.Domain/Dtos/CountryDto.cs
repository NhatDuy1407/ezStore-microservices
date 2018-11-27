using Microservice.Core.Models;

namespace Microservice.Setting.Domain.Dtos
{
    public class CountryDto: ModelStringIdEntity
    {
        public string Name { get; internal set; }
    }
}
