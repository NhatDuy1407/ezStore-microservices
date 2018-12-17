using System;
using ezStore.Product.ApplicationCore.Dtos;
using ezStore.Product.ApplicationCore.Entities;
using ezStore.Product.ApplicationCore.Mapper;
using Ws4vn.Microservicess.ApplicationCore.Entities;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;

namespace ezStore.Product.ApplicationCore.ProductAggregate
{
    public class ManufactureDomain : AggregateRoot
    {
        public ManufactureDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }

        internal void Add(ManufactureDto manufatureDto)
        {
            var newCategory = ManufactureMapper.DtoToEntity(manufatureDto);
            dataAccessService.Repository<Manufacture>().Insert(newCategory);
        }
    }
}
