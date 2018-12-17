using ezStore.Product.ApplicationCore.Dtos;
using ezStore.Product.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ezStore.Product.ApplicationCore.Mapper
{
    public static class ManufactureMapper
    {
        public static Manufacture DtoToEntity(ManufactureDto dto)
        {
            return new Manufacture
            {
                Id = dto.Id,
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = DateTime.Now
            };
        }

        public static ManufactureDto EntityToDto(Manufacture dto)
        {
            return new ManufactureDto
            {
                Id = dto.Id,
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<ManufactureDto> EntityToDtos(IEnumerable<Manufacture> entities)
        {
            return entities?.Select(EntityToDto);
        }
    }
}
