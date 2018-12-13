using Ws4vn.Microservices.ApplicationCore.Entities;
using System.Collections.Generic;

namespace Microservice.Setting.ApplicationCore.Dtos
{
    public class CountryDto : ModelStringIdEntity
    {
        public string Name { get; internal set; }

        public ICollection<ProvinceDto> Provinces { get; set; }
    }
}
