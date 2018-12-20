using ezStore.WareHouse.ApplicationCore.DomainEvents;
using Ws4vn.Microservices.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System;
using System.Linq;

namespace ezStore.WareHouse.ApplicationCore.WareHouseAggregate
{
    public class WareHouseDomain : AggregateRoot
    {
        public WareHouseDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }

        public void CreateWareHouse(string name, int countryId, int provinceId, string address, string city, string phoneNumber, string postalCode)
        {
            var newWareHouse = new Entities.Warehouse()
            {
                Name = name,
                CountryId = countryId,
                ProvinceId = provinceId,
                Address = address,
                City = city,
                PhoneNumber = phoneNumber,
                PostalCode = postalCode
            };
            dataAccessService.Repository<Entities.Warehouse>().Insert(newWareHouse);

            AddEvent(new WareHouseCreated(newWareHouse.Id, newWareHouse.Name));
        }

        public void UpdateWareHouse(Guid id, string name)
        {
            var warehouse = dataAccessService.Repository<Entities.Warehouse>().Get(i => i.Id == id).FirstOrDefault();
            if (warehouse != null)
            {
                warehouse.Name = name;

                AddEvent(new WareHouseUpdated(warehouse.Id));
            }
        }

        public void DeleteWareHouse(Guid id)
        {
            var warehouse = dataAccessService.Repository<Entities.Warehouse>().Get(i => i.Id == id).FirstOrDefault();
            if (warehouse != null)
            {
                dataAccessService.Repository<Entities.Warehouse>().Delete(i => i.Id == id);
                AddEvent(new WareHouseDeleted(warehouse.Id));
            }
        }
    }
}
