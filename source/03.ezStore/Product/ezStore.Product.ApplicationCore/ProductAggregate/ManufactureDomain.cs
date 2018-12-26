using System;
using System.Linq;
using ezStore.Product.ApplicationCore.Dtos;
using ezStore.Product.ApplicationCore.Entities;
using ezStore.Product.ApplicationCore.Mapper;
using Ws4vn.Microservices.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace ezStore.Product.ApplicationCore.ProductAggregate
{
    public class ManufactureDomain : AggregateRoot
    {
        public ManufactureDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }

        public void Add(ManufactureDto manufacture)
        {
            var newCategory = ManufactureMapper.DtoToEntity(manufacture);
            _dataAccessService.Repository<Manufacture>().Insert(newCategory);

        }

        public void Update(ManufactureDto manufacture)
        {
            var Manufacture2Save = _dataAccessService.Repository<Manufacture>().Get(i => i.Id == manufacture.Id).FirstOrDefault();
            Manufacture2Save.Name = manufacture.Name;
            Manufacture2Save.UpdatedDate = DateTime.Now;
        }

        public void Delete(Guid id)
        {
            _dataAccessService.Repository<Manufacture>().Delete(i => i.Id == id);
        }
    }
}
