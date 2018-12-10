﻿using ezStore.DomainEvents.WareHouse;
using Microservice.Core.DomainService.Models;
using System;
using System.Linq;
using Microservice.DataAccess.Core.Interfaces;

namespace ezStore.WareHouse.ApplicationCore.WareHouseAggregate
{
    public class WareHouseDomain : AggregateRoot
    {
        public WareHouseDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }

        public void CreateWareHouse(string name)
        {
            var newWareHouse = new Entities.WareHouse() { Name = name };
            dataAccessService.Repository<Entities.WareHouse>().Insert(newWareHouse);

            ApplyEvent(new WareHouseCreated(newWareHouse.Id, newWareHouse.Name));
        }

        public void UpdateWareHouse(Guid id, string name)
        {
            var warehouse = dataAccessService.Repository<Entities.WareHouse>().Get(i => i.Id == id).FirstOrDefault();
            if (warehouse != null)
            {
                warehouse.Name = name;

                ApplyEvent(new WareHouseUpdated(warehouse.Id));
            }
        }

        public void DeleteWareHouse(Guid id)
        {
            var warehouse = dataAccessService.Repository<Entities.WareHouse>().Get(i => i.Id == id).FirstOrDefault();
            if (warehouse != null)
            {
                dataAccessService.Repository<Entities.WareHouse>().Delete(i => i.Id == id);
                ApplyEvent(new WareHouseDeleted(warehouse.Id));
            }
        }
    }
}