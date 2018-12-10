using ezStore.WareHouse.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ezStore.WareHouse.ApplicationCore.Mapper
{
    public static class WareHouseMapper
    {
        public static Entities.WareHouse DtoToEntity(WareHouseDto dto)
        {
            return new Entities.WareHouse
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

        public static WareHouseDto EntityToDto(Entities.WareHouse entity)
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

        public static IEnumerable<WareHouseDto> EntityToDtos(IEnumerable<Entities.WareHouse> entities)
        {
            return entities?.Select(EntityToDto);
        }
    }
}
