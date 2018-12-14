using ezStore.WareHouse.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using Ws4vn.Microservices.ApplicationCore.ReadModels;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;
using Ws4vn.Microservicess.ApplicationCore.SharedKernel;

namespace ezStore.WareHouse.ApplicationCore.Mapper
{
    public static class WareHouseMapper
    {
        public static Entities.Warehouse DtoToEntity(WareHouseDto dto)
        {
            return new Entities.Warehouse
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                City = dto.City,
                CountryId = dto.CountryId,
                ProvinceId = dto.ProvinceId,
                PhoneNumber = dto.PhoneNumber,
                PostalCode = dto.PostalCode,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = DateTime.Now
            };
        }

        public static WareHouseDto EntityToDto(Entities.Warehouse entity, List<CountryReadModel> countries = null, List<ProvinceReadModel> provinces = null)
        {
            return new WareHouseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address,
                City = entity.City,
                CountryId = entity.CountryId,
                CountryName = countries?.FirstOrDefault(i => i.Id == entity.CountryId)?.Name,
                ProvinceId = entity.ProvinceId,
                ProvinceName = provinces?.FirstOrDefault(i => i.Id == entity.ProvinceId)?.Name,
                PhoneNumber = entity.PhoneNumber,
                PostalCode = entity.PostalCode,
                CreatedBy = entity.CreatedBy,
                UpdatedBy = entity.UpdatedBy,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate,
            };
        }

        public static IEnumerable<WareHouseDto> EntityToDtos(IEnumerable<Entities.Warehouse> entities, List<CountryReadModel> countries, List<ProvinceReadModel> provinces)
        {
            return entities?.Select(i => EntityToDto(i, countries, provinces));
        }
    }
}
