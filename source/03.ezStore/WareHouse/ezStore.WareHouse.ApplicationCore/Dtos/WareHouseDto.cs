using Ws4vn.Microservicess.ApplicationCore.Entities;

namespace ezStore.WareHouse.ApplicationCore.Dtos
{
    public class WareHouseDto : ModelGuidIdEntity
    {
        public string Name { get; internal set; }
        public string Address { get; internal set; }
        public string City { get; internal set; }
        public int CountryId { get; internal set; }
        public int ProvinceId { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string PostalCode { get; internal set; }
        public string CountryName { get; set; }
        public string ProvinceName { get; set; }
    }
}
