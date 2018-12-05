using Microservice.Core.Models;
using System.Collections.Generic;

namespace Microservice.Setting.Domain.Dtos
{
    public class CountryDto: ModelStringIdEntity
    {
        public string Name { get; internal set; }

        public ICollection<ProvinceDto> Provinces { get; internal set; }
    }
}
