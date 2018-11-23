using ezStore.DomainEvents.WareHouse;
using Microservice.Core.DomainService.Models;
using System;
using System.Linq;
using Ws4vn.DataAccess.Core.Interfaces;

namespace ezStore.WareHouse.Domain.ProductAggregate
{
    public class WareHouseDomain : AggregateRoot
    {
        private readonly IDataAccessWriteService writeService;

        public WareHouseDomain(IDataAccessWriteService writeService)
        {
            this.writeService = writeService;
        }

        public void CreateWareHouse(string name)
        {
            var newWareHouse = new Infrastructure.Entities.WareHouse() { Name = name };
            writeService.Repository<Infrastructure.Entities.WareHouse>().Insert(newWareHouse);
            writeService.SaveChanges();

            ApplyEvent(new WareHouseCreated(newWareHouse.Id, newWareHouse.Name));
        }

        public void UpdateWareHouse(Guid id, string name)
        {
            var warehouse = writeService.Repository<Infrastructure.Entities.WareHouse>().Get(i => i.Id == id).FirstOrDefault();
            if (warehouse != null)
            {
                warehouse.Name = name;
                writeService.SaveChanges();

                ApplyEvent(new WareHouseUpdated(warehouse.Id));
            }
        }

        public void DeleteWareHouse(Guid id)
        {
            var warehouse = writeService.Repository<Infrastructure.Entities.WareHouse>().Get(i => i.Id == id).FirstOrDefault();
            if (warehouse != null)
            {
                writeService.Repository<Infrastructure.Entities.WareHouse>().Delete(i => i.Id == id);
                writeService.SaveChanges();

                ApplyEvent(new WareHouseDeleted(warehouse.Id));
            }
        }
    }
}
