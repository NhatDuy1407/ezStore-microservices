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
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = DateTime.Now
            };
        }

        public static WareHouseDto EntityToDto(Infrastructure.Entities.WareHouse dto)
        {
            return new WareHouseDto
            {
                Id = dto.Id,
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<WareHouseDto> EntityToDtos(IEnumerable<Infrastructure.Entities.WareHouse> dtos)
        {
            return dtos.Select(EntityToDto);
        }
    }
}
