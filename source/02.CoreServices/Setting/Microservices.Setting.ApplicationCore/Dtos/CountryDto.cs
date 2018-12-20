using Ws4vn.Microservices.ApplicationCore.Entities;
using System.Collections.Generic;

namespace Microservices.Setting.ApplicationCore.Dtos
{
    public class CountryDto : ModelIntIdEntity
    {
        public string Name { get; internal set; }

        public ICollection<ProvinceDto> Provinces { get; set; }
    }
}
