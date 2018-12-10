using Microservice.Core.Models;

namespace ezStore.WareHouse.ApplicationCore.Entities
{
    public class WareHouse : ModelGuidIdEntity
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public int ProvinceId { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}
