using Ws4vn.Microservicess.ApplicationCore.Commands;
using System;

namespace ezStore.WareHouse.ApplicationCore.Services.Commands
{
    public class UpdateWareHouseCommand : ValidationDecoratorCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }

        public UpdateWareHouseCommand(Guid id, string name, int countryId, int provinceId, string address, string city, string phoneNumber, string postalCode)
            : base(new NameValidatorCommand(name))
        {
            this.Id = id;
            this.Name = name;
            this.CountryId = countryId;
            this.ProvinceId = provinceId;
            this.Address = address;
            this.City = city;
            this.PhoneNumber = phoneNumber;
            this.PostalCode = postalCode;
        }

        public override bool SelfValidate()
        {
            return true;
        }
    }
}
