using Microservice.Core.Models;
using System;

namespace ezStore.WareHouse.Infrastructure.Entities
{
    public class WareHouse : ModelGuidIdEntity
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public int ProvinceId { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
