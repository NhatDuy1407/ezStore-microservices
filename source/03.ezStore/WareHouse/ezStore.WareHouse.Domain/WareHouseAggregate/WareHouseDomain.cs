using ezStore.DomainEvents.WareHouse;
using Microservice.Core.DomainService.Models;
using System;
using System.Linq;
using Microservice.DataAccess.Core.Interfaces;

namespace ezStore.WareHouse.Domain.ProductAggregate
{
    public class WareHouseDomain : AggregateRoot
    {
        public WareHouseDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }

        public void CreateWareHouse(string name)
        {
            var newWareHouse = new Infrastructure.Entities.WareHouse() { Name = name };
            dataAccessService.Repository<Infrastructure.Entities.WareHouse>().Insert(newWareHouse);

            ApplyEvent(new WareHouseCreated(newWareHouse.Id, newWareHouse.Name));
        }

        public void UpdateWareHouse(Guid id, string name)
        {
            var warehouse = dataAccessService.Repository<Infrastructure.Entities.WareHouse>().Get(i => i.Id == id).FirstOrDefault();
            if (warehouse != null)
            {
                warehouse.Name = name;

                ApplyEvent(new WareHouseUpdated(warehouse.Id));
            }
        }

        public void DeleteWareHouse(Guid id)
        {
            var warehouse = dataAccessService.Repository<Infrastructure.Entities.WareHouse>().Get(i => i.Id == id).FirstOrDefault();
            if (warehouse != null)
            {
                dataAccessService.Repository<Infrastructure.Entities.WareHouse>().Delete(i => i.Id == id);
                ApplyEvent(new WareHouseDeleted(warehouse.Id));
            }
        }
    }
}
