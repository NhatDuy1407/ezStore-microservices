using ezStore.WareHouse.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ezStore.WareHouse.Domain.Mapper
{
    public static class WareHouseMapper
    {
        public static Infrastructure.Entities.WareHouse DtoToEntity(WareHouseDto dto)
        {
            return new Infrastructure.Entities.WareHouse
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

        public static WareHouseDto EntityToDto(Infrastructure.Entities.WareHouse entity)
        {
            return new WareHouseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address,
                City = entity.City,
                CountryId = entity.CountryId,
                ProvinceId = entity.ProvinceId,
                PhoneNumber = entity.PhoneNumber,
                PostalCode = entity.PostalCode,
                CreatedBy = entity.CreatedBy,
                UpdatedBy = entity.UpdatedBy,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate,
            };
        }

        public static IEnumerable<WareHouseDto> EntityToDtos(IEnumerable<Infrastructure.Entities.WareHouse> entities)
        {
            return entities == null ? null : entities.Select(EntityToDto);
        }
    }
}
