using Ws4vn.Microservices.ApplicationCore.Entities;
using System;

namespace ezStore.WareHouse.API.ViewModels
{
    public class WareHouseViewModel : ViewModelEntity<Guid>
    {
        public string Name { get; internal set; }
        public string Address { get; internal set; }
        public string City { get; internal set; }
        public int CountryId { get; internal set; }
        public int CountryName { get; internal set; }
        public int ProvinceId { get; internal set; }
        public string ProvinceName { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string PostalCode { get; internal set; }
    }
}
